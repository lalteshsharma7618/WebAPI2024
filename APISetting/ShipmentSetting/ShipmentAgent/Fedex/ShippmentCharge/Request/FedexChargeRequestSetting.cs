using Newtonsoft.Json.Linq;
using WEB_API_2024.Models.Database.ShipServices.Master;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Request.FedexChargeMasterRequest;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentCharge;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Request
{
    public class FedexChargeRequestSetting
    {
        public static string GetFedexChargeRequestData(FinalAgentMaster finalAgentMaster, ChargesRootobject chargesRootobject)
        {
            string Result = "";

            FCMR_Rootobject fCMR_Rootobject = new FCMR_Rootobject();

            fCMR_Rootobject.accountNumber = new FCMR_Accountnumber()
            {
                value = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("AccountNumber").ToLower())).First().Value
            };


            fCMR_Rootobject.rateRequestControlParameters = new FCMR_Raterequestcontrolparameters()
            {
                rateSortOrder = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("rateSortOrder").ToLower())).First().Value,
                returnLocalizedDateTime = true,
                returnTransitTimes = true
            };

            FCMR_Shipper fCMR_Shipper = new FCMR_Shipper();

            fCMR_Shipper.address = new FCMR_Address()
            {
                city = finalAgentMaster.GetAccountMasters[0].City,
                stateOrProvinceCode = finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode,
                postalCode = finalAgentMaster.GetAccountMasters[0].PostalCode,
                countryCode = finalAgentMaster.GetAccountMasters[0].CountryCode,
                residential = "false",
            };

            FCMR_Recipient fCMR_Recipient = new FCMR_Recipient();
            fCMR_Recipient.address = new FCMR_Address()
            {
                city = chargesRootobject.Charges.Header.DropCity,
                stateOrProvinceCode = chargesRootobject.Charges.Header.DropStateOrProvinceCode,
                postalCode = chargesRootobject.Charges.Header.DropPostalCode,
                countryCode = chargesRootobject.Charges.Header.DropCountryCode
            };



            FCMR_Customsclearancedetail fCMR_Customsclearancedetail = new FCMR_Customsclearancedetail();
            List<FCMR_Commodity> fCMR_Commodities = new List<FCMR_Commodity>();

            List<FCMR_Requestedpackagelineitem> fCMR_Requestedpackagelineitem = new List<FCMR_Requestedpackagelineitem>();
            foreach (var BaleData in chargesRootobject.Charges.Bale)
            {
                fCMR_Requestedpackagelineitem.Add(new FCMR_Requestedpackagelineitem()
                {
                    groupPackageCount = 0,
                    insuredValue = new FCMR_Insuredvalue()
                    {
                        amount = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("InsuredValue").ToLower())).First().Value,
                        currency = chargesRootobject.Charges.Header.Currency
                    },
                    weight = new FCMR_Weight()
                    {
                        units = BaleData.BaleWeightUnits,
                        value = Convert.ToDouble(BaleData.BaleWeightValue)
                    }
                });

                fCMR_Commodities.Add(new FCMR_Commodity()
                {
                    countryOfManufacture = finalAgentMaster.GetAccountMasters[0].CountryCode,
                    customsValue = new FCMR_Customsvalue()
                    {
                        amount = BaleData.BaleCustomsAmount.ToString(),
                        currency = chargesRootobject.Charges.Header.Currency
                    },
                    description = BaleData.BaleDescription,
                    name = BaleData.BaleDescription,
                    numberOfPieces = BaleData.BaleNumberOfPieces,
                    quantity = BaleData.BaleQuantity,
                    weight = new FCMR_Weight()
                    {
                        units = BaleData.BaleWeightUnits,
                        value = Convert.ToDouble(BaleData.BaleWeightValue)
                    }
                }); ;
            }

            fCMR_Customsclearancedetail.commodities = fCMR_Commodities;
            fCMR_Customsclearancedetail.dutiesPayment = new FCMR_Dutiespayment()
            {
                paymentType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("paymentType").ToLower())).First().Value
            };

            FCMR_Requestedshipment fCMR_Requestedshipment = new FCMR_Requestedshipment();
            fCMR_Requestedshipment.blockInsightVisibility = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("blockInsightVisibility").ToLower())).First().Value);
            fCMR_Requestedshipment.customsClearanceDetail = fCMR_Customsclearancedetail;
            fCMR_Requestedshipment.packagingType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PackagingType").ToLower())).First().Value;
            fCMR_Requestedshipment.pickupType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupType").ToLower())).First().Value;

            fCMR_Requestedshipment.requestedPackageLineItems = fCMR_Requestedpackagelineitem;
            fCMR_Requestedshipment.rateRequestType = new List<string>()
            {
                finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("rateRequestType").ToLower())).First().Value,
                 //"ACCOUNT",
            };
            fCMR_Requestedshipment.recipient = fCMR_Recipient;
            fCMR_Requestedshipment.shipper = fCMR_Shipper;
            fCMR_Requestedshipment.shippingChargesPayment = new FCMR_Shippingchargespayment()
            {
                paymentType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("paymentType").ToLower())).First().Value
            };
            fCMR_Requestedshipment.preferredCurrency = chargesRootobject.Charges.Header.Currency;
            //fCMR_Requestedshipment.preferredCurrency = "INR";

            fCMR_Rootobject.requestedShipment = fCMR_Requestedshipment;

            fCMR_Rootobject.carrierCodes = new List<string>()
            {
               finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("CarrierCode").ToLower())).First().Value
            };
            Result = Newtonsoft.Json.JsonConvert.SerializeObject(fCMR_Rootobject);

            return Result;
        }
    }
}
