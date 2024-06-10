using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using WEB_API_2024.Models;
using WEB_API_2024.Models.Database.ERP;
using WEB_API_2024.Models.Database.Website.Master;

namespace WEB_API_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteMasterController : ControllerBase
    {
        private readonly DBMaster dBMaster;

        public WebsiteMasterController(DBMaster dBMaster)
        {
            this.dBMaster = dBMaster;
        }


        [HttpPost]
        [Route("test/whatmore-product")]
        [Authorize(Roles = "Web")]
        [Tags("Test Whatmore Notion Product Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult DemoGetWebProduct()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                //IEnumerable<Claim> claims = identity.Claims;
                var APITokenNo = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.PrimaryGroupSid).Value;
                var UserEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                var LiveStatus = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid).Value;
                var Result = dBMaster.FinalProductDataWahtmoreAPIs.ToList();              

                return Ok(Result);
            }
            else
            {
                return Ok("Request terminated. Unauthorized access to protected resource. Please recreate token.");
            }
           
        }

        [HttpPost]
        [Route("test/whatmore-product-detail")]
        [Authorize(Roles = "Web")]
        [Tags("Test Whatmore Notion Product Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult DemoGetWebProductDetail(Condition condition)
        {

            try
            {
                List<ProductId> productIds = new List<ProductId>();

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return Ok("Data not found. Please try again.");
                    }
                    else
                    {
                        //productIds = condition.ProductIds.ToList();
                        //IEnumerable<Claim> claims = identity.Claims;
                        var APITokenNo = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.PrimaryGroupSid).Value;
                        var UserEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                        var LiveStatus = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid).Value;

                       
                        var Result = dBMaster.FinalProductDataWahtmoreAPIs.Where(x=>x.product_id.ToLower().Equals(condition.product_id)).Select(x => new ProductDetail()
                        {
                            id = x.id,
                            product_title = x.product_title,
                            product_id = x.product_id,
                            discount_percentage = x.discount_percentage,
                            price = x.price,
                            mrp = x.mrp,
                            country_name = x.country_name,
                            quantity = x.quantity,
                            Stock_status = x.Stock_status,
                            product_url = x.product_url,
                            currency_code = x.currency_code,
                            description = x.description,
                            thumbnail_image = x.thumbnail_image,
                            options = x.options,
                        });
                        return Ok(Result);
                    }
                }
                else
                {
                    return Ok("Request terminated. Unauthorized access to protected resource. Please recreate token.");
                }
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
