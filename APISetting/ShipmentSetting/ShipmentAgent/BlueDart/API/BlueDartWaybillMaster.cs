using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using RestSharp;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;
using Microsoft.AspNetCore.Hosting.Server;
using WEB_API_2024.ConfigureServices;
using WEB_API_2024.Models.Database.ShipServices.Table;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.Waybill.Request;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.Waybill.Response;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.API
{
    public static class BlueDartWaybillMaster
    {
        public static string GetFinalWaybillNo(string str)
        {
            string FinalResult = "";
            try
            {

                foreach (string s in str.Split(' '))
                {
                    try
                    {
                        FinalResult = Convert.ToString(long.Parse(s.Trim()));
                        break;
                    }
                    catch
                    {

                    }
                }

                return FinalResult;

            }
            catch (FormatException)
            {
                return "";
            }
        }
        public static LogMaster BlueDartWaybillCreate(bool Livestatus, string wwwPath, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            MasterResponse masterResponse = new MasterResponse();
            LogMaster logMaster = new LogMaster();


            var FileName = shippment.ShipmentMaster.Header.InvoiceNumber.Replace("/", "-").Replace(" ", "-") + ".pdf";
            var FinalWaybillLocalPath = wwwPath + "\\data\\waybill\\" + shippment.ShipmentMaster.Header.AgentCode + "\\";
            var FinalWaybillWebPath = "data/waybill/" + shippment.ShipmentMaster.Header.AgentCode + "/";
            if (!Directory.Exists(FinalWaybillLocalPath))
            {
                Directory.CreateDirectory(FinalWaybillLocalPath);
            }
            var FinalWayBillFileLocation = FinalWaybillLocalPath + FileName;
            var FinalWayBillURL = GlobalConfig.GetHostURL() + FinalWaybillWebPath + FileName;


            BlueDartWaybillMasterResponse.BlueDartResponseRootobject ResponseBlueDart = new BlueDartWaybillMasterResponse.BlueDartResponseRootobject();
            var TokenNo = CreateTokenNo(Livestatus);
            if (TokenNo != "" && TokenNo.Length > 100)
            {
                var FinalJson = "";

                if (Livestatus)
                {
                    FinalJson = BlueDartWaybillRequestSetting.GetBluedartWaybillRequestData(Livestatus, finalAgentMaster, shippment);
                }
                else
                {
                    //FinalJson = BlueDartWaybillRequestSetting.GetBluedartRequestTestData(Livestatus, finalAgentMaster, shippment);
                    FinalJson = BlueDartWaybillRequestSetting.GetBluedartWaybillRequestData(Livestatus, finalAgentMaster, shippment);
                }


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string EndPointURL = "https://apigateway-sandbox.bluedart.com/in/transportation/waybill/v1/GenerateWayBill";
                if (Livestatus)
                {
                    EndPointURL = "https://apigateway.bluedart.com/in/transportation/waybill/v1/GenerateWayBill";
                }
                var client = new RestClient(EndPointURL);
                var request = new RestRequest(EndPointURL, Method.Post);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("JWTToken", TokenNo);
                request.AddParameter("application/json", FinalJson, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                ResponseBlueDart = JsonConvert.DeserializeObject<BlueDartWaybillMasterResponse.BlueDartResponseRootobject>(response.Content);


                logMaster.AgentCode = shippment.ShipmentMaster.Header.AgentCode;
                logMaster.InvoiceNo = shippment.ShipmentMaster.Header.CustomerRefrence;
                string strJson = JsonConvert.SerializeObject(shippment);
                logMaster.MasterJson = strJson;
                logMaster.AgentJson = FinalJson;
                logMaster.AgentResult = JsonConvert.SerializeObject(ResponseBlueDart);
                logMaster.TrackingNo = "";
                if (ResponseBlueDart != null)
                {
                    if (ResponseBlueDart.errorresponse != null && ResponseBlueDart.errorresponse.Count > 0)
                    {
                        masterResponse.errormessage = ResponseBlueDart.errorresponse[0].Status[0].StatusInformation;

                        if (masterResponse.errormessage.ToLower().Contains("creditreferenceno"))
                        {
                            string AWBNo = GetFinalWaybillNo(masterResponse.errormessage);
                            if (AWBNo.Length > 4)
                            {
                                masterResponse.data = new List<MasterShippmentResponse>()
                                {
                                    new MasterShippmentResponse()
                                    {
                                        AgentCode=shippment.ShipmentMaster.Header.AgentCode,
                                        AWBNumber=AWBNo,
                                        LabelUrl=FinalWayBillURL
                                    }
                                };
                                masterResponse.success = false;
                            }
                        }

                    }
                    else if (ResponseBlueDart.GenerateWayBillResult != null && ResponseBlueDart.GenerateWayBillResult.AWBNo != "")
                    {
                        var AWBNo = ResponseBlueDart.GenerateWayBillResult.AWBNo;
                        var AWBPrintContent = ResponseBlueDart.GenerateWayBillResult.AWBPrintContent;
                        var DestinationArea = ResponseBlueDart.GenerateWayBillResult.DestinationArea;
                        var DestinationLocation = ResponseBlueDart.GenerateWayBillResult.DestinationLocation;
                        var ClusterCode = ResponseBlueDart.GenerateWayBillResult.ClusterCode;
                        logMaster.TrackingNo = AWBNo;


                        Stream sm = null;
                        try
                        {

                            sm = new MemoryStream(AWBPrintContent);
                            using (Stream destination = File.Create(FinalWayBillFileLocation))
                            {
                                for (int a = sm.ReadByte(); a != -1; a = sm.ReadByte())
                                {
                                    destination.WriteByte((byte)a);
                                }
                            }

                            masterResponse.data = new List<MasterShippmentResponse>()
                            {
                                new MasterShippmentResponse()
                                {
                                    AgentCode=shippment.ShipmentMaster.Header.AgentCode,
                                    AWBNumber=AWBNo,
                                    DestinationArea=DestinationArea,
                                    DestinationLocation=DestinationLocation,
                                    ClusterCode=ClusterCode,
                                    LabelUrl=FinalWayBillURL
                                }
                            };
                            masterResponse.success = true;


                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else
                    {
                        masterResponse.errormessage = "API result not found.";
                    }

                }
                else
                {
                    masterResponse.errormessage = "100-API not working";
                }


            }

            logMaster.MasterResult = JsonConvert.SerializeObject(masterResponse);
            logMaster.CreateDate = DateTime.Now;
            logMaster.ModifyDate = DateTime.Now;
            logMaster.APIName = "Waybill";
            return logMaster;
        }



        public static string CreateTokenNo(bool Livestatus)
        {
            string FinalResult = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            string EndPointURL = "https://apigateway-sandbox.bluedart.com/in/transportation/token/v1/login";
            if (Livestatus)
            {
                EndPointURL = "https://apigateway.bluedart.com/in/transportation/token/v1/login";
            }

            var client = new RestClient(EndPointURL);
            //client.Timeout = -1;
            var request = new RestRequest(EndPointURL, Method.Get);
            request.AddHeader("ClientID", "4edHSzz4PKqWbF1NvZgFhQ4xaFHUZX9a");
            request.AddHeader("clientSecret", "qDS7s7R0wxPMuhzA");
            request.AlwaysMultipartFormData = true;
            RestResponse response = client.Execute(request);
            var Result = response.Content;
            dynamic stuff = JObject.Parse(Result);
            FinalResult = Convert.ToString(stuff.JWTToken);

            return FinalResult;
        }
    }
}
