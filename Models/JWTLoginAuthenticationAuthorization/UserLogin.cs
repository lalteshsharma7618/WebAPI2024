using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_2024.Models.JWTLoginAuthenticationAuthorization
{
    public class UserLogin
    {
        [StringLength(100), Required]
        [SwaggerSchema(
            Title = "Total Order Value",
            Description = "Sub. Total Value for order placed by customer. Should have been a double :)",
            Format = "string")]
        public string username { get; set; }


        [StringLength(100), Required]
        //[SwaggerSchema(
        //    Title = "Total Order Value",
        //    Description = "Sub. Total Value for order placed by customer. Should have been a double :)",
        //    Format = "string")]
        public string Password { get; set; }


        [StringLength(100), Required]
        public string client_id { get; set; }


        [StringLength(100), Required]
        public string client_secret { get; set; }


        [StringLength(100), Required]
        public string grant_type { get; set; }
    }
}
