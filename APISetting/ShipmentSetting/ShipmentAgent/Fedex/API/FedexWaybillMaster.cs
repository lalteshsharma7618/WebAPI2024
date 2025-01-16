using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;
using RestSharp;
using Newtonsoft.Json;
using WEB_API_2024.Models.Database.ShipServices.Table;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Request;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Response;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API
{
    public class FedexWaybillMaster
    {
        public static LogMaster FedexWaybillCreate(bool Livestatus, string wwwPath, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            LogMaster logMaster = new LogMaster();
            MasterResponse masterResponse = new MasterResponse();

            try
            {
                var FedexTokenResult = FedexTokenMaster.GetTokenNo(Livestatus, finalAgentMaster, shippment.ShipmentMaster.Header.LocationCode);

                var DocumentResult = FedexDocumentMaster.FedexDocumentCreate(FedexTokenResult.access_token, Convert.ToBoolean(Livestatus), wwwPath, finalAgentMaster, shippment);

                if (DocumentResult.success)
                {
                    var FedexRequestData = FedexWaybillRequestSetting.GetFedexWaybillRequestData(Livestatus, DocumentResult.docname, DocumentResult.docid, finalAgentMaster, shippment);

                    var FedexFinalJsonData = JsonConvert.SerializeObject(FedexRequestData);

                    var FinalPostURL = "https://apis-sandbox.fedex.com";
                    if (Livestatus)
                    {
                        FinalPostURL = "https://apis.fedex.com";
                    }
                    var options = new RestClientOptions(FinalPostURL)
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest("/ship/v1/shipments", Method.Post);
                    request.AddHeader("x-customer-transaction-id", "");
                    request.AddHeader("x-locale", "en_US");
                    request.AddHeader("content-type", "application/json");
                    if (FedexTokenResult != null && FedexTokenResult.access_token != null)
                    {
                        request.AddHeader("Authorization", "Bearer " + FedexTokenResult.access_token);
                    }
                    request.AddStringBody(FedexRequestData, DataFormat.Json);
                    RestResponse response = client.Execute(request);
                    var FedexResult = response.Content;


                    var FinalResult = JsonConvert.DeserializeObject<FedexWaybillMasterResponse.FDWMR_Rootobject>(FedexResult);

                    logMaster.AgentCode = shippment.ShipmentMaster.Header.AgentCode;
                    logMaster.InvoiceNo = shippment.ShipmentMaster.Header.CustomerRefrence;
                    var MasterJsonData = shippment;
                    MasterJsonData.ShipmentMaster.Header.DocumentPdfInByte = "";
                    string strJson = JsonConvert.SerializeObject(MasterJsonData);
                    logMaster.MasterJson = strJson;
                    logMaster.AgentJson = FedexRequestData;
                    logMaster.AgentResult = JsonConvert.SerializeObject(FinalResult);
                    logMaster.TrackingNo = "";
                    if (FinalResult == null || FinalResult.output == null || FinalResult.errors != null && FinalResult.errors.Count > 0)
                    {
                        string errormess = "";
                        if (FinalResult.errors != null)
                        {
                            foreach (var error in FinalResult.errors)
                            {
                                errormess += error.code + " : " + error.message + "\n";
                            }
                        }
                        masterResponse.errormessage = errormess;

                    }
                    else
                    {
                        if (FinalResult.output.transactionShipments != null && FinalResult.output.transactionShipments.Count > 0)
                        {
                            if (FinalResult.output.transactionShipments[0].shipmentDocuments != null && FinalResult.output.transactionShipments[0].shipmentDocuments.Count > 0)
                            {
                                string pdf_url = "";
                                string trackingNumber = "";
                                pdf_url = FinalResult.output.transactionShipments[0].shipmentDocuments[0].url;
                                trackingNumber = FinalResult.output.transactionShipments[0].shipmentDocuments[0].trackingNumber;

                                MasterShippmentResponse masterShippmentResponse = new MasterShippmentResponse();
                                masterShippmentResponse.AWBNumber = trackingNumber;
                                masterShippmentResponse.LabelUrl = pdf_url;
                                masterShippmentResponse.AgentCode = shippment.ShipmentMaster.Header.AgentCode;
                                masterResponse.data = new List<MasterShippmentResponse>() { masterShippmentResponse };
                                masterResponse.success = true;
                                masterResponse.errormessage = "";
                                logMaster.TrackingNo = trackingNumber;

                            }
                            else if (FinalResult.output.transactionShipments[0].pieceResponses != null && FinalResult.output.transactionShipments[0].pieceResponses.Count > 0)
                            {
                                string pdf_url = "";
                                string trackingNumber = "";
                                pdf_url = FinalResult.output.transactionShipments[0].pieceResponses[0].packageDocuments[0].url;
                                trackingNumber = FinalResult.output.transactionShipments[0].pieceResponses[0].trackingNumber;

                                MasterShippmentResponse masterShippmentResponse = new MasterShippmentResponse();
                                masterShippmentResponse.AWBNumber = trackingNumber;
                                masterShippmentResponse.LabelUrl = pdf_url;
                                masterShippmentResponse.AgentCode = shippment.ShipmentMaster.Header.AgentCode;
                                masterResponse.data = new List<MasterShippmentResponse>() { masterShippmentResponse };
                                masterResponse.success = true;
                                masterResponse.errormessage = "";
                                logMaster.TrackingNo = trackingNumber;
                            }
                        }
                    }
                }
                else
                {
                    masterResponse.errormessage = DocumentResult.message;
                }
            }
            catch (Exception ex)
            {
                masterResponse.errormessage = ex.Message;
            }
            logMaster.MasterResult = JsonConvert.SerializeObject(masterResponse);
            logMaster.CreateDate = DateTime.Now;
            logMaster.ModifyDate = DateTime.Now;
            logMaster.APIName = "Waybill";
            return logMaster;
        }
    }
}
