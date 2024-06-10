using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using WEB_API_2024.ConfigureServices;
using WEB_API_2024.Models;
using WEB_API_2024.Repository.InterfaceRepository;
using WEB_API_2024.Repository.SQLRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//var devCorsPolicy = "devCorsPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(devCorsPolicy, builder => {
//       // builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
//        //builder.SetIsOriginAllowed(origin => true);
//    });
//});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web API Services API",
        Contact = new OpenApiContact
        {
            Name = "Pixxel Digital Support",
            Email = "programmer@pixxeldigital.com",

        }
        ,
        License = new OpenApiLicense
        {
            Name = "Download Document",
            Url = new Uri("https://api-v1.jaipurrugs.com/document/API-document.pdf"),
        }
    });

    c.EnableAnnotations();


    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<DBMaster>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("APIDbConnecion"), sqlServerOptionsAction: sqloptions =>
{
    sqloptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
}));


builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddScoped<IServices, DBServices>();
builder.Services.AddScoped<IERP, DBERP>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
    c.InjectStylesheet("/content/css/swagger-mycustom.css");
    c.RoutePrefix = "";

});


app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404 || context.Response.StatusCode == 405)
    {
        // Set the status code to 404 Not Found
        context.Response.StatusCode = 404;

        // Create a JSON response
        var jsonResponse = new
        {
            success = false,
            errormessage = "Resource not found",
            data = "null"
        };

        // Convert the object to JSON and write it to the response body
        var json = JsonSerializer.Serialize(jsonResponse);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(json);
    }
    if (context.Response.StatusCode == 500)
    {
        // Set the status code to 404 Not Found
        context.Response.StatusCode = 405;

        // Create a JSON response
        var jsonResponse = new
        {
            success = false,
            errormessage = "Internal server error.",
            data = "null"
        };

        // Convert the object to JSON and write it to the response body
        var json = JsonSerializer.Serialize(jsonResponse);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(json);
    }
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


//dotnet dev-certs https --clean
//dotnet dev-certs https --trust
//Restart VS

IHttpContextAccessor httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
IWebHostEnvironment webHostEnvironment = app.Services.GetRequiredService<IWebHostEnvironment>();
GlobalConfig.Configure(httpContextAccessor, webHostEnvironment);
