using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;
using WEB_API_2024.Models;
using WEB_API_2024.Models.Database;
using WEB_API_2024.Models.JWTLoginAuthenticationAuthorization;

namespace WEB_API_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class oauthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DBMaster dBMaster;
        public oauthController(IConfiguration config, DBMaster dBMaster)
        {
            _config = config;
            this.dBMaster = dBMaster;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("access_token")]
        [Tags("Authentication")]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                MasterResponse ss1 = new MasterResponse();
                var message1 = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ss1.errormessage = message1;
                return Ok(ss1);
            }

            var user = Authenticate(userLogin);

            if (user != null && user.Count > 0)
            {
                // var token = GenerateToken(user);
                //return Ok(token);

                var Expirexpires_in = DateTime.Now.AddMinutes(15);

                var TotalExpirexpires_in = 15 * 60000;

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,user[0].UserName),
                new Claim(ClaimTypes.GroupSid,user[0].LiveStatus.ToString()),
                new Claim(ClaimTypes.PrimaryGroupSid,user[0].TokenNo),
                new Claim(ClaimTypes.Role,user[0].Role)
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                    expires: Expirexpires_in,
                    signingCredentials: credentials);


                return Ok(new JWTTokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), Expirexpires_in = TotalExpirexpires_in.ToString(), token_type = "bearer" });
            }

            MasterResponse ss = new MasterResponse();
            var message = "user not found";
            ss.errormessage = message;
            return Ok(ss);
        }


        private string GenerateToken(List<APIUserMaster> user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user[0].UserName),
                new Claim(ClaimTypes.GroupSid,user[0].ClientId),
                new Claim(ClaimTypes.PrimaryGroupSid,user[0].ClientSecret),
                new Claim(ClaimTypes.Role,user[0].Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private List<APIUserMaster> Authenticate(UserLogin userLogin)
        {
            //var currentUser = UserConstants.Users.FirstOrDefault(x => x.Username.ToLower() == userLogin.Username.ToLower() && x.Password == userLogin.Password);
            var currentUser = dBMaster.APIUserMasters.Where(x => x.UserName.ToLower() == userLogin.username.ToLower() && x.Password == userLogin.Password && x.ClientId == userLogin.client_id && x.ClientSecret == userLogin.client_secret && x.GrantType == userLogin.grant_type && x.Active == true).ToList();
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}

