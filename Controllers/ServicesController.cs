using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.API;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API;
using WEB_API_2024.Models;
using WEB_API_2024.Models.Database.ShipServices.Master;
using WEB_API_2024.Models.Database.ShipServices.Table;
using WEB_API_2024.Repository.InterfaceRepository;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Response.FedexChargeMasterResponse;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentCharge;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentPickup;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.ShippmentCharge.API;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.Waybill.API;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.Tracking;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentTrack;

namespace WEB_API_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServices services;
        private readonly IHostingEnvironment hostingEnv;
        public ServicesController(IHostingEnvironment env, IServices services)
        {            
            this.hostingEnv = env;
            this.services = services;
        }

        [HttpPost]
        [Route("shippment")]
        [Authorize(Roles = "Logistics")]
        [Tags("Shippment Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult Shippment(ShippmentRootobject shippment)
        {

           

            MasterResponse Result = new MasterResponse();
            LogMaster logMaster = new LogMaster();
            var APITokenNo = "";
            var UserEmail = "";
            var LiveStatus = "";
            bool ActiveAPI = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    var message1 = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    Result.errormessage = message1;
                }
                else
                {
                    
                    string wwwPath = this.hostingEnv.WebRootPath;
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    if (identity != null)
                    {
                         APITokenNo = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.PrimaryGroupSid).Value;
                         UserEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                         LiveStatus = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid).Value;

                        FinalAgentMaster finalAgentMaster = new FinalAgentMaster();


                        finalAgentMaster.GetAgentMasters = services.GetAgentMasters(shippment.ShipmentMaster.Header.AgentCode);

                        finalAgentMaster.GetAgentSubMasters = services.GetSubAgents(APITokenNo, finalAgentMaster.GetAgentMasters[0].TokenNo);

                        if (finalAgentMaster.GetAgentSubMasters.Count > 0)
                        {
                            finalAgentMaster.GetAgentDetails = services.GetAgentDetails(finalAgentMaster.GetAgentSubMasters[0].TokenNo);
                            if (finalAgentMaster.GetAgentDetails.Count > 0)
                            {
                                finalAgentMaster.GetAccountMasters = services.GetAccountMasters(APITokenNo, shippment.ShipmentMaster.Header.AccountNo);
                                if (finalAgentMaster.GetAccountMasters.Count > 0)
                                {
                                    ActiveAPI = true;                                    
                                }
                                else
                                {
                                    Result.errormessage = "Request terminated. Account no not found.Please check account no.";
                                }
                            }
                            else
                            {
                                Result.errormessage = "Request terminated. Agent Details not found.Please check agent details.";
                            }
                        }
                        else
                        {
                            Result.errormessage = "Request terminated. Agent not found.Please check agent code.";
                        }

                        if(ActiveAPI)
                        {
                            if (shippment.ShipmentMaster.Header.AgentCode.ToUpper().Equals("BLD"))
                            {
                                logMaster = BlueDartWaybillMaster.BlueDartWaybillCreate
                                (Convert.ToBoolean(LiveStatus), wwwPath, finalAgentMaster, shippment);
                                Result = JsonConvert.DeserializeObject<MasterResponse>(logMaster.MasterResult);
                            }
                            else if(shippment.ShipmentMaster.Header.AgentCode.ToUpper().Equals("FEDSW") ||shippment.ShipmentMaster.Header.AgentCode.ToUpper().Equals("FEDLW"))
                            {
                                logMaster = FedexWaybillMaster.FedexWaybillCreate
                                (Convert.ToBoolean(LiveStatus), wwwPath, finalAgentMaster, shippment);
                                Result = JsonConvert.DeserializeObject<MasterResponse>(logMaster.MasterResult);
                            }
                            else if (shippment.ShipmentMaster.Header.AgentCode.ToUpper().Equals("DHL"))
                            {
                                logMaster = DHLWaybillMaster.DHLWaybillCreate
                               (Convert.ToBoolean(LiveStatus), wwwPath, finalAgentMaster, shippment);
                                Result = JsonConvert.DeserializeObject<MasterResponse>(logMaster.MasterResult);
                            }
                            else
                            {
                                Result.errormessage = "Request terminated. Agent code not found.Please check agent code.";
                            }
                        }

                        logMaster.UserTokenNo = APITokenNo;
                        services.InsertLogMaster(logMaster);
                    }
                    else
                    {
                        Result.errormessage = "Request terminated. Unauthorized access to protected resource. Please recreate token.";
                    }

                   
                }
            }
            catch(Exception ex)
            {
                Result.errormessage = "Request terminated." + ex.Message;
            }

            

            return Ok(Result);
        }

        [HttpPost]
        [Route("shippment-charge")]
        [Authorize(Roles = "Logistics")]
        [Tags("Shippment Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult ShippmentCharge(ChargesRootobject shippmentCharge)
        {
            MasterChargeResponse Result = new MasterChargeResponse();
            LogMaster logMaster = new LogMaster();
            var APITokenNo = "";
            var UserEmail = "";
            var LiveStatus = "";
            MasterChargeResponse ss1 = new MasterChargeResponse();
            bool ActiveAPI = false;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                if (!ModelState.IsValid)
                {
                   
                    var message1 = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    ss1.errormessage = message1;
                    return Ok(ss1);
                }
                string wwwPath = this.hostingEnv.WebRootPath;
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    APITokenNo = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.PrimaryGroupSid).Value;
                    UserEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                    LiveStatus = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid).Value;

                    FinalAgentMaster finalAgentMaster = new FinalAgentMaster();

                    string AgentList = "";

                    if (shippmentCharge.Charges.Header.AgentCode != null && shippmentCharge.Charges.Header.AgentCode != "")
                    {
                        AgentList = shippmentCharge.Charges.Header.AgentCode;
                    }
                    else
                    {
                        if (shippmentCharge.Charges.Header.ShipmentType.ToUpper().Equals("EXPORT"))
                        {
                            AgentList = "FEDSW,DHL";
                        }
                    }
                    if (AgentList != "")
                    {
                        List<ChargeResponseDatum> DataList = new List<ChargeResponseDatum>();

                        foreach (var AgentCode in AgentList.Split(","))
                        {
                            finalAgentMaster.GetAgentMasters = services.GetAgentMasters(AgentCode);

                            finalAgentMaster.GetAgentSubMasters = services.GetSubAgents(APITokenNo, finalAgentMaster.GetAgentMasters[0].TokenNo);

                            if (finalAgentMaster.GetAgentSubMasters.Count > 0)
                            {
                                finalAgentMaster.GetAgentDetails = services.GetAgentDetails(finalAgentMaster.GetAgentSubMasters[0].TokenNo);
                                if (finalAgentMaster.GetAgentDetails.Count > 0)
                                {
                                    finalAgentMaster.GetAccountMasters = services.GetAccountMasters(APITokenNo, shippmentCharge.Charges.Header.AccountNo);
                                    if (finalAgentMaster.GetAccountMasters.Count > 0)
                                    {
                                        ActiveAPI = true;
                                    }
                                    else
                                    {
                                        Result.errormessage = "Request terminated. Account no not found.Please check account no.";
                                    }
                                }
                                else
                                {
                                    Result.errormessage = "Request terminated. Agent Details not found.Please check agent details.";
                                }
                            }
                            else
                            {
                                Result.errormessage = "Request terminated. Agent not found.Please check agent code.";
                            }

                            if (ActiveAPI)
                            {
                                if (AgentCode.ToUpper().Equals("BLD"))
                                {

                                }
                                else if (AgentCode.ToUpper().Equals("FEDSW") || AgentCode.ToUpper().Equals("FEDLW"))
                                {
                                    logMaster = FedexChargeMaster.FedexShippingChargeCreate(Convert.ToBoolean(LiveStatus), wwwPath, finalAgentMaster, shippmentCharge);
                                    var FinalResult = JsonConvert.DeserializeObject<MasterChargeResponse>(logMaster.MasterResult);

                                    DataList.Add(new ChargeResponseDatum()
                                    {
                                        AgentCode = FinalResult.data[0].AgentCode,
                                        Currency = FinalResult.data[0].Currency,
                                        TotalCharges = FinalResult.data[0].TotalCharges,
                                        TotalDuitableCharges = FinalResult.data[0].TotalDuitableCharges,
                                        TotalTax = FinalResult.data[0].TotalTax,
                                        AgentStatus = FinalResult.data[0].AgentStatus,
                                        Message = FinalResult.data[0].Message
                                    });
                                    Result.success = FinalResult.data[0].AgentStatus;
                                }
                                else if (AgentCode.ToUpper().Equals("DHL"))
                                {
                                    logMaster = DHLChargeMaster.DHLShippingChargeCreate(Convert.ToBoolean(LiveStatus), wwwPath, finalAgentMaster, shippmentCharge);
                                    var FinalResult = JsonConvert.DeserializeObject<MasterChargeResponse>(logMaster.MasterResult);

                                    DataList.Add(new ChargeResponseDatum()
                                    {
                                        AgentCode = FinalResult.data[0].AgentCode,
                                        Currency = FinalResult.data[0].Currency,
                                        TotalCharges = FinalResult.data[0].TotalCharges,
                                        TotalDuitableCharges = FinalResult.data[0].TotalDuitableCharges,
                                        TotalTax = FinalResult.data[0].TotalTax,
                                        AgentStatus = FinalResult.data[0].AgentStatus,
                                        Message = FinalResult.data[0].Message
                                    });
                                    Result.success = FinalResult.data[0].AgentStatus;
                                }
                                else
                                {
                                    Result.errormessage = "Request terminated. Agent code not found.Please check agent code.";
                                }
                            }

                            logMaster.UserTokenNo = APITokenNo;
                            services.InsertLogMaster(logMaster);
                        }
                        Result.data = DataList;
                        var DataOutput = DataList.Where(x => x.AgentStatus == true).ToList();
                        if (DataOutput.Count > 0)
                        {
                            Result.success = true;
                            Result.errormessage = DataOutput[0].Message;
                        }
                    }
                    else
                    {
                        Result.errormessage = "Shipment type does not match.";
                    }

                }
                else
                {
                    Result.errormessage = "Request terminated. Unauthorized access to protected resource. Please recreate token.";
                }
            }
            catch (Exception ex)
            {
                Result.errormessage = "Request terminated." + ex.Message;
            }

            return Ok(Result);
        }

        [HttpPost]
        [Route("shippment-pickup")]
        [Authorize(Roles = "Logistics")]
        [Tags("Shippment Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult ShippmentPickup(PickupRootobject shippmentPickup)
        {
            if (!ModelState.IsValid)
            {
                MasterResponse ss1 = new MasterResponse();
                var message1 = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ss1.errormessage = message1;
                return Ok(ss1);
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Ok("Success");
            }
            else
            {
                return Ok("Request terminated. Unauthorized access to protected resource. Please recreate token.");
            }
        }


        [HttpPost]
        [Route("shippment-track")]
        [Authorize(Roles = "Logistics")]
        [Tags("Shippment Services")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult ShippmentTrack(ShippmentTrack shippmentTrack)
        {
            if (!ModelState.IsValid)
            {
                MasterResponse ss1 = new MasterResponse();
                var message1 = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ss1.errormessage = message1;
                return Ok(ss1);
            }
            bool ActiveAPI = false;
            LogMaster logMaster = new LogMaster();
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {

                var APITokenNo = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.PrimaryGroupSid).Value;
                var UserEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                var LiveStatus = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid).Value;

                FinalAgentMaster finalAgentMaster = new FinalAgentMaster();

                //var SS = DHLTrackingMaster.GetDHLTrackAWBNumber("1497388362");

                // var ss = FedexTrackingMaster.GetFedexTrackRequestData(true, "1497388362");

                foreach (var AgentCode in shippmentTrack.AgentCode.Split(","))
                {
                    finalAgentMaster.GetAgentMasters = services.GetAgentMasters(AgentCode);

                    finalAgentMaster.GetAgentSubMasters = services.GetSubAgents(APITokenNo, finalAgentMaster.GetAgentMasters[0].TokenNo);

                    if (finalAgentMaster.GetAgentSubMasters.Count > 0)
                    {
                        finalAgentMaster.GetAgentDetails = services.GetAgentDetails(finalAgentMaster.GetAgentSubMasters[0].TokenNo);
                        if (finalAgentMaster.GetAgentDetails.Count > 0)
                        {
                            ActiveAPI = true;
                        }
                        else
                        {
                            //Result.errormessage = "Request terminated. Agent Details not found.Please check agent details.";
                        }
                    }
                    else
                    {
                       // Result.errormessage = "Request terminated. Agent not found.Please check agent code.";
                    }

                    if (ActiveAPI)
                    {
                        if (AgentCode.ToUpper().Equals("BLD"))
                        {

                        }
                        else if (AgentCode.ToUpper().Equals("FEDSW") || AgentCode.ToUpper().Equals("FEDLW"))
                        {
                            var ss = FedexTrackingMaster.GetFedexTrackRequestData(true, finalAgentMaster, "1497388362");
                        }
                        else if (AgentCode.ToUpper().Equals("DHL"))
                        {
                            var ss = DHLTrackingMaster.GetDHLTrackAWBNumber(true, "1497388362");
                        }
                        else
                        {
                            //Result.errormessage = "Request terminated. Agent code not found.Please check agent code.";
                        }
                    }

                    logMaster.UserTokenNo = APITokenNo;
                    services.InsertLogMaster(logMaster);
                }

                return Ok("Success");
            }
            else
            {
                return Ok("Request terminated. Unauthorized access to protected resource. Please recreate token.");
            }
        }
    }
}
