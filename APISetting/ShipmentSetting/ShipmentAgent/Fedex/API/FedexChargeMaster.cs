using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;
using WEB_API_2024.Models.Database.ShipServices.Table;
using Newtonsoft.Json;
using RestSharp;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentCharge;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Response.FedexChargeMasterResponse;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Request;
using Microsoft.AspNetCore.Mvc.Razor;
using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API
{
    public class FedexChargeMaster
    {
        public static LogMaster FedexShippingChargeCreate(bool Livestatus, string wwwPath, FinalAgentMaster finalAgentMaster, ChargesRootobject chargesRootobject)
        {
            LogMaster logMaster = new LogMaster();
            MasterChargeResponse masterChargeResponse = new MasterChargeResponse();
            FCR_ChargeResponse fCR_ChargeResponse = new FCR_ChargeResponse();
            try
            {
                logMaster.APIName = "Charge";
                logMaster.MasterJson = JsonConvert.SerializeObject(chargesRootobject);
                logMaster.AgentCode = "FEDEX";
                logMaster.InvoiceNo = chargesRootobject.Charges.Header.InvoiceNumber;

               
                var FedexTokenResult = FedexTokenMaster.GetTokenNo(Livestatus, finalAgentMaster);

                

                var FedexRequestData = FedexChargeRequestSetting.GetFedexChargeRequestData(finalAgentMaster, chargesRootobject);
                var FedexFinalJsonData = JsonConvert.SerializeObject(FedexRequestData);

                logMaster.AgentJson = FedexFinalJsonData;

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
                var request = new RestRequest("/rate/v1/rates/quotes", Method.Post);
                request.AddHeader("content-type", "application/json");
                if (FedexTokenResult != null && FedexTokenResult.access_token != null)
                {
                    request.AddHeader("Authorization", "Bearer " + FedexTokenResult.access_token);
                }
                request.AddStringBody(FedexRequestData, DataFormat.Json);
                RestResponse response = client.Execute(request);
                var FedexResult = response.Content;

                

                FCR_Rootobject fCR_Rootobject = new FCR_Rootobject();
                fCR_Rootobject = JsonConvert.DeserializeObject<FCR_Rootobject>(FedexResult);

                
                logMaster.AgentJson = FedexRequestData;
                logMaster.AgentResult = JsonConvert.SerializeObject(fCR_Rootobject);
             
                logMaster.TrackingNo = "";
                if (fCR_Rootobject == null || fCR_Rootobject.output == null || fCR_Rootobject.errors != null)
                {
                    string errormess = "";
                    foreach (var error in fCR_Rootobject.errors)
                    {
                        errormess += error.code + " : " + error.message + "<br/>";
                    }

                    fCR_ChargeResponse.message = errormess;

                }

                List<ChargeResponseDatum> DataList = new List<ChargeResponseDatum>();

                if (fCR_Rootobject.output != null)
                {
                    var Find_price_FEDEX_INTERNATIONAL_PRIORITY = fCR_Rootobject.output.rateReplyDetails.Find(x => x.serviceType == "FEDEX_INTERNATIONAL_PRIORITY" || x.serviceType == "INTERNATIONAL_PRIORITY_FREIGHT");

                    if (Find_price_FEDEX_INTERNATIONAL_PRIORITY == null)
                    {
                        fCR_ChargeResponse.message = "Price not found for service type : FEDEX_INTERNATIONAL_PRIORITY";
                    }
                    else
                    {
                        fCR_ChargeResponse.success = true;
                    }


                    if (fCR_ChargeResponse.success)
                    {
                        string customerMessage = "";

                        if (Find_price_FEDEX_INTERNATIONAL_PRIORITY.customerMessages != null)
                        {
                            foreach (var customerMessages in Find_price_FEDEX_INTERNATIONAL_PRIORITY.customerMessages)
                            {
                                customerMessage += customerMessages.message + "<br/>";
                            }
                        }
                        foreach (var ratedShipmentDetails_obj in Find_price_FEDEX_INTERNATIONAL_PRIORITY.ratedShipmentDetails)
                        {

                            fCR_ChargeResponse.currency = ratedShipmentDetails_obj.currency;
                            fCR_ChargeResponse.customerMessages = customerMessage;
                            fCR_ChargeResponse.serviceName = Find_price_FEDEX_INTERNATIONAL_PRIORITY.serviceName;
                            fCR_ChargeResponse.totalAncillaryFeesAndTaxes = ratedShipmentDetails_obj.totalAncillaryFeesAndTaxes;
                            fCR_ChargeResponse.totalBaseCharge = ratedShipmentDetails_obj.totalBaseCharge;
                            fCR_ChargeResponse.totalBillingWeight = ratedShipmentDetails_obj.shipmentRateDetail.totalBillingWeight.value + " " + ratedShipmentDetails_obj.shipmentRateDetail.totalBillingWeight.units;
                            fCR_ChargeResponse.totalDiscounts = ratedShipmentDetails_obj.totalDiscounts;
                            fCR_ChargeResponse.totalDutiesAndTaxes = ratedShipmentDetails_obj.totalDutiesAndTaxes;
                            fCR_ChargeResponse.totalDutiesTaxesAndFees = ratedShipmentDetails_obj.totalDutiesTaxesAndFees;
                            fCR_ChargeResponse.totalNetCharge = ratedShipmentDetails_obj.totalNetCharge;
                            fCR_ChargeResponse.totalNetChargeWithDutiesAndTaxes = ratedShipmentDetails_obj.totalNetChargeWithDutiesAndTaxes;
                            fCR_ChargeResponse.totalNetFedExCharge = ratedShipmentDetails_obj.totalNetFedExCharge;


                        }

                        foreach (var ratedShipmentDetails_obj in Find_price_FEDEX_INTERNATIONAL_PRIORITY.ratedShipmentDetails)
                        {
                            if (ratedShipmentDetails_obj.currency.ToUpper().Equals("INR"))
                            {
                                foreach (var Data in ratedShipmentDetails_obj.ratedPackages)
                                {
                                    double DDPCharges = 0;
                                    if (chargesRootobject.Charges.Header.DeliveryTerms.ToUpper().Equals("DDP"))
                                    {
                                        DDPCharges = 500;
                                    }                                   
                                    DataList.Add(new ChargeResponseDatum()
                                    {
                                        AgentCode = "FEDEX",
                                        Currency = ratedShipmentDetails_obj.currency,

                                        netFreight= Data.packageRateDetail.netFreight,
                                        FuelSurcharges= Convert.ToDouble(Data.packageRateDetail.totalSurcharges),
                                        OverSizePiece=0,
                                        ExportDeclaration=0,
                                        DDPCharges= DDPCharges,
                                        GST= Data.packageRateDetail.totalTaxes,
                                        FinalFreight= Convert.ToDouble(Data.packageRateDetail.netCharge)+ DDPCharges,


                                        AgentStatus = true,
                                        Description= JsonConvert.SerializeObject(Data.packageRateDetail),
                                        Message = "Available-" + chargesRootobject.Charges.Header.Currency
                                    });
                                    masterChargeResponse.success = fCR_ChargeResponse.success;
                                }
                            }
                        }

                        //DataList.Add(new ChargeResponseDatum()
                        //{
                        //    AgentCode = "FEDEX",
                        //    Currency = fCR_ChargeResponse.currency,
                        //    TotalCharges = fCR_ChargeResponse.totalNetFedExCharge,
                        //    TotalDuitableCharges = fCR_ChargeResponse.totalDutiesTaxesAndFees,
                        //    TotalTax = fCR_ChargeResponse.totalDutiesAndTaxes,
                        //    AgentStatus = true,
                        //    Message = "Available"
                        //});
                        //masterChargeResponse.success = fCR_ChargeResponse.success;
                    }
                    else
                    {
                        DataList.Add(new ChargeResponseDatum()
                        {
                            AgentCode = "FEDEX",
                            Currency = chargesRootobject.Charges.Header.Currency,                          
                            AgentStatus = false,
                            Message = fCR_ChargeResponse.message
                        });
                    }
                }
                else
                {
                    DataList.Add(new ChargeResponseDatum()
                    {
                        AgentCode = "FEDEX",
                        Currency = chargesRootobject.Charges.Header.Currency,                       
                        AgentStatus = false,
                        Message = fCR_ChargeResponse.message
                    });
                }             


                masterChargeResponse.errormessage = fCR_ChargeResponse.message;
                masterChargeResponse.data = DataList;
            }
            catch (Exception ex)
            {
                masterChargeResponse.errormessage = ex.Message;
            }
            logMaster.MasterResult = JsonConvert.SerializeObject(masterChargeResponse);
            logMaster.CreateDate = DateTime.Now;
            logMaster.ModifyDate = DateTime.Now;
            logMaster.APIName = "Charge";
            return logMaster;
        }
    }
}
