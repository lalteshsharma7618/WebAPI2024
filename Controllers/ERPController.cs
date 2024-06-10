using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Claims;
using WEB_API_2024.APISetting.ERP.POSPortal;
using WEB_API_2024.Models;
using WEB_API_2024.Models.Database.ERP.Master;
using WEB_API_2024.Repository.InterfaceRepository;
using static WEB_API_2024.APISetting.ERP.POSPortal.POSpatrolMaster;

namespace WEB_API_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERPController : ControllerBase
    {
        private readonly IERP ERP;

        public ERPController(IERP ERP)
        {
            this.ERP = ERP;
        }

        [HttpPost]
        [Route("pos-product")]
        [Authorize(Roles = "ERP")]
        [Tags("POS Patrol Product Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult GetPosProduct(POSPortalMaster Condition)
        {
            try
            {
               
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                   
                    if (!ModelState.IsValid)
                    {
                        var message1 = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                        return Ok(message1);
                    }
                    else
                    {
                        if (Condition.StartDate != null && Condition.StartDate != "" && Condition.EndDate != null && Condition.EndDate != "")
                        {
                            //IEnumerable<Claim> claims = identity.Claims;
                            var APITokenNo = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.PrimaryGroupSid).Value;
                            var UserEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                            var LiveStatus = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid).Value;

                            // var Result = dBMaster.FinalProductDataWahtmoreAPIs.ToList();

                            DateTime StartDate = DateTime.ParseExact(Condition.StartDate, "dd/MM/yyyy", null);
                            DateTime EndDate = DateTime.ParseExact(Condition.EndDate, "dd/MM/yyyy", null);

                            var PosPortalData = ERP.GetNAVPosPortalDatas().Where(x =>
                            Convert.ToDateTime(x.RCPT_DT) >= Convert.ToDateTime(StartDate) && Convert.ToDateTime(x.RCPT_DT) <= Convert.ToDateTime(EndDate)).ToList();

                            POSpatrolMaster.POS_Rootobject pOS_Rootobject = new POSpatrolMaster.POS_Rootobject();

                            if (PosPortalData != null && PosPortalData.Count > 0)
                            {
                                var TransactionsData = PosPortalData.GroupBy(x => new { x.LOCATION_CODE, x.TERMINAL_ID, x.SHIFT_NO, x.RCPT_NUM, x.RCPT_DT, x.BUSINESS_DT, x.RCPT_TM, x.INV_AMT, x.TAX_AMT, x.RET_AMT, x.TRAN_STATUS, x.OP_CUR, x.BC_EXCH, x.DISCOUNT }).Select(y => new POS_Transaction()
                                {
                                    LOCATION_CODE = y.Key.LOCATION_CODE,
                                    TERMINAL_ID = y.Key.TERMINAL_ID,
                                    SHIFT_NO = y.Key.SHIFT_NO,
                                    RCPT_NUM = y.Key.RCPT_NUM,
                                    RCPT_DT = Convert.ToDateTime(y.Key.RCPT_DT).ToString("dd/MM/yyyy"),
                                    BUSINESS_DT = Convert.ToDateTime(y.Key.BUSINESS_DT).ToString("dd/MM/yyyy"),                                    
                                    RCPT_TM = y.Key.RCPT_TM,
                                    INV_AMT = y.Key.INV_AMT.ToString(),
                                    TAX_AMT = y.Key.TAX_AMT.ToString(),
                                    RET_AMT = y.Key.RET_AMT.ToString(),
                                    TRAN_STATUS = y.Key.TRAN_STATUS,
                                    OP_CUR = y.Key.OP_CUR,
                                    BC_EXCH = y.Key.BC_EXCH.ToString(),
                                    DISCOUNT = y.Key.DISCOUNT.ToString()
                                }).ToList();

                                var ItemData = PosPortalData.Select(x => new POS_Itemdetail()
                                {
                                    REC_TYPE = x.REC_TYPE,
                                    RCPT_NUM = x.RCPT_NUM,
                                    RCPT_DT = Convert.ToDateTime(x.RCPT_DT).ToString("dd/MM/yyyy"),
                                    ITEM_CODE = x.ITEM_CODE,
                                    ITEM_NAME = x.ITEM_NAME,
                                    ITEM_QTY = x.ITEM_QTY.ToString(),
                                    ITEM_PRICE = x.ITEM_PRICE.ToString(),
                                    ITEM_CAT = x.ITEM_CAT.ToString(),
                                    ITEM_TAX = x.ITEM_TAX.ToString(),
                                    ITEM_TAX_TYPE = x.ITEM_TAX_TYPE,
                                    ITEM_NET_AMT = x.ITEM_NET_AMT.ToString(),
                                    OP_CUR = x.OP_CUR,
                                    BC_EXCH = x.BC_EXCH.ToString(),
                                    ITEM_STATUS = x.ITEM_STATUS,
                                    ITEM_DISCOUNT = x.ITEM_DISCOUNT.ToString()
                                }).ToList();

                                var PaymentDetail = PosPortalData.Select(x => new POS_Paymentdetail()
                                {
                                    RCPT_NUM = x.RCPT_NUM,
                                    RCPT_DT = Convert.ToDateTime(x.RCPT_DT).ToString("dd/MM/yyyy"),
                                    PAYMENT_NAME = x.PAYMENT_NAME,
                                    CURRENCY_CODE = x.CURRENCY_CODE,
                                    EXCHANGE_RATE = x.EXCHANGE_RATE.ToString(),
                                    TENDER_AMOUNT = x.TENDER_AMOUNT.ToString(),
                                    OP_CUR = x.OP_CUR,
                                    BC_EXCH = x.BC_EXCH.ToString(),
                                    PAYMENT_STATUS = x.PAYMENT_STATUS

                                }).ToList();

                                pOS_Rootobject.Transactions = TransactionsData;
                                pOS_Rootobject.ItemDetail = ItemData;
                                pOS_Rootobject.PaymentDetail = PaymentDetail;

                            }



                            return Ok(pOS_Rootobject);
                        }
                        else
                        {
                            return Ok("Request terminated. Please fil start date and end date proper format.");
                        }
                    }
                }
                else
                {
                    return Ok("Request terminated. Unauthorized access to protected resource. Please recreate token.");
                }

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

       
    }
}
