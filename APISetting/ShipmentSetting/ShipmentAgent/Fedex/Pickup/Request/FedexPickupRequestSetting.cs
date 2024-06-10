using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;
using Newtonsoft.Json;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentPickup;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Pickup.Request
{
    public class FedexPickupRequestSetting
    {

        public static string GetFedexWaybillRequestData(bool Livestatus, string DocumentName, string DocumentId, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            string Result = "";

            var FinalData = new FedexPickupRequest.FPR_PickupRootobject()
            {
                associatedAccountNumber = new FedexPickupRequest.FPR_Associatedaccountnumber()
                {
                    value = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("AccountNumber").ToLower())).First().Value
                },
                originDetail = new FedexPickupRequest.FPR_Origindetail()
                {
                    pickupAddressType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("pickupAddressType").ToLower())).First().Value,
                    pickupLocation = new FedexPickupRequest.FPR_Pickuplocation()
                    {
                        contact = new FedexPickupRequest.FPR_PickupContact()
                        {
                            companyName = finalAgentMaster.GetAccountMasters[0].CompanyName,
                            personName = finalAgentMaster.GetAccountMasters[0].Name,
                            phoneNumber = finalAgentMaster.GetAccountMasters[0].MobileNo
                        },
                        address = new FedexPickupRequest.FPR_PickupAddress()
                        {
                            streetLines = new List<string>()
                            {
                               finalAgentMaster.GetAccountMasters[0].AddressFirst,
                               finalAgentMaster.GetAccountMasters[0].AddressSecond == null ? "" : finalAgentMaster.GetAccountMasters[0].AddressSecond,
                               finalAgentMaster.GetAccountMasters[0].AddressThird== null ? "" :finalAgentMaster.GetAccountMasters[0].AddressThird
                            },
                            city = finalAgentMaster.GetAccountMasters[0].City,
                            stateOrProvinceCode = finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode,
                            postalCode = finalAgentMaster.GetAccountMasters[0].PostalCode,
                            countryCode = finalAgentMaster.GetAccountMasters[0].CountryCode

                        },
                        accountNumber = new FedexPickupRequest.FPR_PickupAccountnumber()
                        {
                            value = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("AccountNumber").ToLower())).First().Value
                        },
                        deliveryInstructions = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("deliveryInstructions").ToLower())).First().Value
                    },
                    readyDateTimestamp = DateTime.Now.Date + finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("readyDateTimestamp").ToLower())).First().Value,
                    customerCloseTime = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("customerCloseTime").ToLower())).First().Value,
                    pickupDateType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("pickupDateType").ToLower())).First().Value
                },
                associatedAccountNumberType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("associatedAccountNumberType").ToLower())).First().Value,
                totalWeight = new FedexPickupRequest.FPR_Totalweight()
                {
                    units = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("units").ToLower())).First().Value,
                    value = Convert.ToDecimal(shippment.ShipmentMaster.Header.GrossWeight)
                },
                packageCount = shippment.ShipmentMaster.Line.Count,
                carrierCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("carrierCode").ToLower())).First().Value,
                remarks = "",
                countryRelationships = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("countryRelationships").ToLower())).First().Value,
                pickupType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("pickupType").ToLower())).First().Value,
                commodityDescription = shippment.ShipmentMaster.Bale[0].BaleDescription,
                pickupNotificationDetail = new FedexPickupRequest.FPR_Pickupnotificationdetail()
                {
                    emailDetails = new List<FedexPickupRequest.FPR_Emaildetail>()
                    {
                       new FedexPickupRequest.FPR_Emaildetail()
                       {
                           address=finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("address").ToLower())).First().Value,
                           locale=finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("locale").ToLower())).First().Value
                       }
                    },
                    format = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("format").ToLower())).First().Value,
                    userMessage = ""
                }


            };


            return Result;
        }
    }
}
