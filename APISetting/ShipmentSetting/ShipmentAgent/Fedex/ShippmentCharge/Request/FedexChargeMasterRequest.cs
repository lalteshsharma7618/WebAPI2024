using Newtonsoft.Json;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Request
{
    public class FedexChargeMasterRequest
    {
        public class FCMR_Rootobject
        {
            public FCMR_Accountnumber accountNumber { get; set; }
            public FCMR_Raterequestcontrolparameters rateRequestControlParameters { get; set; }
            public FCMR_Requestedshipment requestedShipment { get; set; }
            public List<string> carrierCodes { get; set; }
        }

        public class FCMR_Accountnumber
        {
            public string value { get; set; }
        }

        public class FCMR_Raterequestcontrolparameters
        {
            public string rateSortOrder { get; set; }
            public bool returnTransitTimes { get; set; }
            public bool returnLocalizedDateTime { get; set; }
        }

        public class FCMR_Requestedshipment
        {
            public FCMR_Shipper shipper { get; set; }
            public FCMR_Recipient recipient { get; set; }
            public string shipDateStamp { get; set; }
            public string pickupType { get; set; }
            public string packagingType { get; set; }
            public FCMR_Shippingchargespayment shippingChargesPayment { get; set; }
            public bool blockInsightVisibility { get; set; }
            public List<string> rateRequestType { get; set; }
            public List<FCMR_Requestedpackagelineitem> requestedPackageLineItems { get; set; }
            public string preferredCurrency { get; set; }
            public FCMR_Customsclearancedetail customsClearanceDetail { get; set; }
        }

        public class FCMR_Shipper
        {
            public FCMR_Address address { get; set; }
        }

        public class FCMR_Address
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string residential { get; set; }
        }

        public class FCMR_Recipient
        {
            public FCMR_Address address { get; set; }
        }

        public class FCMR_Shippingchargespayment
        {
            public string paymentType { get; set; }
        }

        public class FCMR_Customsclearancedetail
        {
            public FCMR_Dutiespayment dutiesPayment { get; set; }
            public List<FCMR_Commodity> commodities { get; set; }
        }

        public class FCMR_Dutiespayment
        {
            public string paymentType { get; set; }
        }

        public class FCMR_Commodity
        {
            public string name { get; set; }
            public int numberOfPieces { get; set; }
            public string description { get; set; }
            public string countryOfManufacture { get; set; }
            public FCMR_Weight weight { get; set; }
            public int quantity { get; set; }
            public FCMR_Customsvalue customsValue { get; set; }
        }

        public class FCMR_Weight
        {
            public string units { get; set; }
            public double value { get; set; }
        }

        public class FCMR_Customsvalue
        {
            public string currency { get; set; }
            public string amount { get; set; }
        }

        public class FCMR_Requestedpackagelineitem
        {
            public int groupPackageCount { get; set; }
            public FCMR_Insuredvalue insuredValue { get; set; }
            public FCMR_Weight weight { get; set; }
        }

        public class FCMR_Insuredvalue
        {
            public string currency { get; set; }
            public string amount { get; set; }
        }
    }
}
