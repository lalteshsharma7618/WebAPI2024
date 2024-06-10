namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Pickup.Request
{
    public class FedexPickupRequest
    {
        public class FPR_PickupRootobject
        {
            public FPR_Associatedaccountnumber associatedAccountNumber { get; set; }
            public FPR_Origindetail originDetail { get; set; }
            public string associatedAccountNumberType { get; set; }
            public FPR_Totalweight totalWeight { get; set; }
            public int packageCount { get; set; }
            public string carrierCode { get; set; }
            public string remarks { get; set; }
            public string countryRelationships { get; set; }
            public string pickupType { get; set; }
            public string commodityDescription { get; set; }
            public FPR_Pickupnotificationdetail pickupNotificationDetail { get; set; }
        }

        public class FPR_Associatedaccountnumber
        {
            public string value { get; set; }
        }

        public class FPR_Origindetail
        {
            public string pickupAddressType { get; set; }
            public FPR_Pickuplocation pickupLocation { get; set; }
            public string readyDateTimestamp { get; set; }
            public string customerCloseTime { get; set; }
            public string pickupDateType { get; set; }
        }

        public class FPR_Pickuplocation
        {
            public FPR_PickupContact contact { get; set; }
            public FPR_PickupAddress address { get; set; }
            public FPR_PickupAccountnumber accountNumber { get; set; }
            public string deliveryInstructions { get; set; }
        }

        public class FPR_PickupContact
        {
            public string companyName { get; set; }
            public string personName { get; set; }
            public string phoneNumber { get; set; }
        }

        public class FPR_PickupAddress
        {
            public List<string> streetLines { get; set; }
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
        }

        public class FPR_PickupAccountnumber
        {
            public string value { get; set; }
        }

        public class FPR_Totalweight
        {
            public string units { get; set; }
            public decimal value { get; set; }
        }

        public class FPR_Pickupnotificationdetail
        {
            public List<FPR_Emaildetail> emailDetails { get; set; }
            public string format { get; set; }
            public string userMessage { get; set; }
        }

        public class FPR_Emaildetail
        {
            public string address { get; set; }
            public string locale { get; set; }
        }
    }
}
