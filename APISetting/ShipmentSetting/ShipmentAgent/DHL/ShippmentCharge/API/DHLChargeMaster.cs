using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentCharge;
using WEB_API_2024.Models.Database.ShipServices.Master;
using WEB_API_2024.Models.Database.ShipServices.Table;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.ShippmentCharge.Response.DHLResponse;
using System.Xml.Serialization;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Response.FedexChargeMasterResponse;
using Newtonsoft.Json;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.ShippmentCharge.API
{
    public class DHLChargeMaster
    {
        public static LogMaster DHLShippingChargeCreate(bool Livestatus, string wwwPath, FinalAgentMaster finalAgentMaster, ChargesRootobject chargesRootobject)
        {
            LogMaster logMaster = new LogMaster();
            MasterChargeResponse masterChargeResponse = new MasterChargeResponse();

            DHL_ChargeResponse dHL_ChargeResponse = new DHL_ChargeResponse();

            try
            {

                string ShipperPostCode = finalAgentMaster.GetAccountMasters[0].PostalCode;
                string fromCity = finalAgentMaster.GetAccountMasters[0].City;

                string ReceiverCountryCode = chargesRootobject.Charges.Header.DropCountryCode;
                string PostCode = chargesRootobject.Charges.Header.DropPostalCode;
                string toCity = chargesRootobject.Charges.Header.DropCity;

                //string DeclaredCurrency = chargesRootobject.Charges.Header.Currency;
                //string DeclaredValue = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("DeclaredValue").ToLower())).First().Value;

                bool INRStatus = false;

                string DeclaredValue = chargesRootobject.Charges.Header.TotalDutiableDeclaredvalue.ToString();
                string DeclaredCurrency = chargesRootobject.Charges.Header.DutiableDeclaredCurrency;

                if (chargesRootobject.Charges.Line.Where(x => x.CGSTAmount_INR > 0 || x.IGSTAmount_INR > 0 || x.SGSTAmount_INR > 0).ToList().Count > 0)
                {
                    INRStatus = true;

                }

                if (INRStatus)
                {
                    DeclaredCurrency = "INR";
                    DeclaredValue = chargesRootobject.Charges.Line.Sum(x => x.FinalPrice_INR).ToString();
                }

                string IsDutiable = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsDutiable").ToLower())).First().Value;
                string PickupHours = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupHours").ToLower())).First().Value;
                string PickupMinutes = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupMinutes").ToLower())).First().Value;
                
                string NetworkTypeCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("NetworkTypeCode").ToLower())).First().Value;
                string GlobalProductCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("GlobalProductCode").ToLower())).First().Value;
                string LocalProductCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LocalProductCode").ToLower())).First().Value;
                string PaymentAccountNumber = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PaymentAccountNumber").ToLower())).First().Value;
                int pieces = chargesRootobject.Charges.Line.Count;
                string ShipPieceWt = "";
                string ShipPieceDepth = "";
                string ShipPieceWidth = "";
                string ShipPieceHeig = "";

                foreach (var Line in chargesRootobject.Charges.Bale)
                {
                    if (ShipPieceWt == "")
                    {
                        ShipPieceWt = Line.BaleWeightValue.ToString();
                        ShipPieceDepth = Line.BaleDimensionsLength.ToString();
                        ShipPieceWidth = Line.BaleDimensionsWidth.ToString();
                        ShipPieceHeig = Line.BaleDimensionsHeight.ToString();
                    }
                    else
                    {
                        ShipPieceWt += "," + Line.BaleWeightValue.ToString();
                        ShipPieceDepth += "," + Line.BaleDimensionsLength.ToString();
                        ShipPieceWidth += "," + Line.BaleDimensionsWidth.ToString();
                        ShipPieceHeig += "," + Line.BaleDimensionsHeight.ToString();
                    }
                }


                Details dHL_Details = new Details();
                string Api_Response_str = "";

                DHLServices.DHLServiceClient.EndpointConfiguration endpointConfiguration = new DHLServices.DHLServiceClient.EndpointConfiguration();


                DHLServices.DHLServiceClient DHLServiceclient = new DHLServices.DHLServiceClient(endpointConfiguration);

                Api_Response_str = DHLServiceclient.PostQuote_RASAsync(ShipperPostCode, ReceiverCountryCode, PostCode, fromCity, IsDutiable, PickupHours, PickupMinutes, DeclaredCurrency, DeclaredValue, NetworkTypeCode, GlobalProductCode, LocalProductCode, toCity, PaymentAccountNumber, pieces, ShipPieceWt, ShipPieceDepth, ShipPieceWidth, ShipPieceHeig).Result;

              


                string AgentRequestData =
"<ShipperPostCode>" + ShipperPostCode + "</ShipperPostCode><ReceiverCountryCode>" + ReceiverCountryCode + "</ReceiverCountryCode><PostCode>" + PostCode + "</PostCode><fromCity>" + fromCity + "</fromCity><IsDutiable>" + IsDutiable + "</IsDutiable><PickupHours>" + PickupHours + "</PickupHours><PickupMinutes>" + PickupMinutes + "</PickupMinutes><DeclaredCurrency>" + DeclaredCurrency + "</DeclaredCurrency><DeclaredValue>" + DeclaredValue + "</DeclaredValue><NetworkTypeCode>" + NetworkTypeCode + "</NetworkTypeCode><GlobalProductCode>" + GlobalProductCode + "</GlobalProductCode><LocalProductCode>" + LocalProductCode + "</LocalProductCode><toCity>" + toCity + "</toCity><PaymentAccountNumber>" + PaymentAccountNumber + "</PaymentAccountNumber><pieces>" + pieces + "</pieces><ShipPieceWt>" + ShipPieceWt + "</ShipPieceWt><ShipPieceDepth>" + ShipPieceDepth + "</ShipPieceDepth><ShipPieceWidth>" + ShipPieceWidth + "</ShipPieceWidth><ShipPieceHeig>" + ShipPieceHeig + "</ShipPieceHeig>";
                logMaster.APIName = "Charge";
                logMaster.AgentCode = "DHL";
                logMaster.InvoiceNo = chargesRootobject.Charges.Header.InvoiceNumber;
                string strJson = JsonConvert.SerializeObject(chargesRootobject);
                logMaster.MasterJson = strJson;
                logMaster.AgentJson = AgentRequestData;
                logMaster.AgentResult = JsonConvert.SerializeObject(Api_Response_str);
                logMaster.TrackingNo = "";
                List<ChargeResponseDatum> DataList = new List<ChargeResponseDatum>();

                XmlSerializer serializer = new XmlSerializer(typeof(Details));
                using (TextReader reader = new StringReader(Api_Response_str))
                {
                    dHL_Details = (Details)serializer.Deserialize(reader);
                }
                if (dHL_Details == null || dHL_Details.ShippingCharge == 0)
                {
                    masterChargeResponse.errormessage = "Unexcepted error occured!";
                    DataList.Add(new ChargeResponseDatum()
                    {
                        AgentCode = "DHL",
                        Currency = DeclaredCurrency,
                        TotalCharges = 0,
                        TotalDuitableCharges = 0,
                        TotalTax = 0,
                        AgentStatus = false,
                        Message = dHL_Details.ConditionData.ToString()
                    });
                }
                else
                {

                    DataList.Add(new ChargeResponseDatum()
                    {
                        AgentCode = "DHL",
                        Currency = "INR",
                        TotalCharges = dHL_Details.ShippingCharge,
                        TotalDuitableCharges = 0,
                        TotalTax = dHL_Details.TotalTaxAmount,
                        AgentStatus = true,
                        Message = "Available-" + chargesRootobject.Charges.Header.Currency
                    }) ;
                    masterChargeResponse.success = true;
                }

                masterChargeResponse.errormessage = masterChargeResponse.errormessage;
                masterChargeResponse.success = false;
                masterChargeResponse.data = DataList;
            }
            catch (Exception ex)
            {
                masterChargeResponse.errormessage = ex.Message;
            }
            logMaster.MasterResult = JsonConvert.SerializeObject(masterChargeResponse);
            logMaster.CreateDate = DateTime.Now;
            logMaster.ModifyDate = DateTime.Now;
            return logMaster;
        }

    }
}
