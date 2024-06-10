using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.TrackOrder.Response.FedexTrackResponse;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.TrackOrder.Response
{
    public class FedexTrackResponse
    {

        public class FedexTrackResponse_Rootobject
        {
            public string transactionId { get; set; }
            public FedexTrackResponse_Output output { get; set; }
        }

        public class FedexTrackResponse_Output
        {
            public List<FedexTrackResponse_Completetrackresult> completeTrackResults { get; set; }
        }

        public class FedexTrackResponse_Completetrackresult
        {
            public string trackingNumber { get; set; }
            public List<FedexTrackResponse_Trackresult> trackResults { get; set; }
        }

        public class FedexTrackResponse_Trackresult
        {
            public FedexTrackResponse_Trackingnumberinfo trackingNumberInfo { get; set; }
            public FedexTrackResponse_Additionaltrackinginfo additionalTrackingInfo { get; set; }
            public FedexTrackResponse_Shipperinformation shipperInformation { get; set; }
            public FedexTrackResponse_Recipientinformation recipientInformation { get; set; }
            public FedexTrackResponse_Lateststatusdetail latestStatusDetail { get; set; }
            public List<FedexTrackResponse_Dateandtime> dateAndTimes { get; set; }
            public List<FedexTrackResponse_Availableimage> availableImages { get; set; }
            public List<FedexTrackResponse_Specialhandling> specialHandlings { get; set; }
            public FedexTrackResponse_Packagedetails packageDetails { get; set; }
            public FedexTrackResponse_Shipmentdetails shipmentDetails { get; set; }
            public List<FedexTrackResponse_Scanevent> scanEvents { get; set; }
            public List<string> availableNotifications { get; set; }
            public FedexTrackResponse_Deliverydetails deliveryDetails { get; set; }
            public FedexTrackResponse_Originlocation originLocation { get; set; }
            public FedexTrackResponse_Destinationlocation destinationLocation { get; set; }
            public FedexTrackResponse_Lastupdateddestinationaddress lastUpdatedDestinationAddress { get; set; }
            public FedexTrackResponse_Servicedetail serviceDetail { get; set; }
            public FedexTrackResponse_Standardtransittimewindow standardTransitTimeWindow { get; set; }
            public FedexTrackResponse_Estimateddeliverytimewindow estimatedDeliveryTimeWindow { get; set; }
            public string goodsClassificationCode { get; set; }
            public FedexTrackResponse_Returndetail returnDetail { get; set; }
        }

        public class FedexTrackResponse_Trackingnumberinfo
        {
            public string trackingNumber { get; set; }
            public string trackingNumberUniqueId { get; set; }
            public string carrierCode { get; set; }
        }

        public class FedexTrackResponse_Additionaltrackinginfo
        {
            public string nickname { get; set; }
            public List<FedexTrackResponse_Packageidentifier> packageIdentifiers { get; set; }
            public bool hasAssociatedShipments { get; set; }
        }

        public class FedexTrackResponse_Packageidentifier
        {
            public string type { get; set; }
            public List<string> values { get; set; }
            public string trackingNumberUniqueId { get; set; }
            public string carrierCode { get; set; }
        }

        public class FedexTrackResponse_Shipperinformation
        {
            public FedexTrackResponse_Contact contact { get; set; }
            public FedexTrackResponse_Address address { get; set; }
        }

        public class FedexTrackResponse_Contact
        {
        }

        public class FedexTrackResponse_Address
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Recipientinformation
        {
            public FedexTrackResponse_Contact1 contact { get; set; }
            public FedexTrackResponse_Address1 address { get; set; }
        }

        public class FedexTrackResponse_Contact1
        {
        }

        public class FedexTrackResponse_Address1
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Lateststatusdetail
        {
            public string code { get; set; }
            public string derivedCode { get; set; }
            public string statusByLocale { get; set; }
            public string description { get; set; }
            public FedexTrackResponse_Scanlocation scanLocation { get; set; }
        }

        public class FedexTrackResponse_Scanlocation
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Packagedetails
        {
            public FedexTrackResponse_Packagingdescription packagingDescription { get; set; }
            public string sequenceNumber { get; set; }
            public string count { get; set; }
            public FedexTrackResponse_Weightanddimensions weightAndDimensions { get; set; }
            public List<object> packageContent { get; set; }
        }

        public class FedexTrackResponse_Packagingdescription
        {
            public string type { get; set; }
            public string description { get; set; }
        }

        public class FedexTrackResponse_Weightanddimensions
        {
            public List<FedexTrackResponse_Weight> weight { get; set; }
            public List<FedexTrackResponse_Dimension> dimensions { get; set; }
        }

        public class FedexTrackResponse_Weight
        {
            public string value { get; set; }
            public string unit { get; set; }
        }

        public class FedexTrackResponse_Dimension
        {
            public int length { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string units { get; set; }
        }

        public class FedexTrackResponse_Shipmentdetails
        {
            public bool possessionStatus { get; set; }
            public List<FedexTrackResponse_Weight1> weight { get; set; }
        }

        public class FedexTrackResponse_Weight1
        {
            public string value { get; set; }
            public string unit { get; set; }
        }

        public class FedexTrackResponse_Deliverydetails
        {
            public FedexTrackResponse_Actualdeliveryaddress actualDeliveryAddress { get; set; }
            public string locationType { get; set; }
            public string locationDescription { get; set; }
            public string deliveryAttempts { get; set; }
            public string receivedByName { get; set; }
            public List<FedexTrackResponse_Deliveryoptioneligibilitydetail> deliveryOptionEligibilityDetails { get; set; }
        }

        public class FedexTrackResponse_Actualdeliveryaddress
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Deliveryoptioneligibilitydetail
        {
            public string option { get; set; }
            public string eligibility { get; set; }
        }

        public class FedexTrackResponse_Originlocation
        {
            public FedexTrackResponse_Locationcontactandaddress locationContactAndAddress { get; set; }
            public string locationId { get; set; }
        }

        public class FedexTrackResponse_Locationcontactandaddress
        {
            public FedexTrackResponse_Address2 address { get; set; }
        }

        public class FedexTrackResponse_Address2
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Destinationlocation
        {
            public FedexTrackResponse_Locationcontactandaddress1 locationContactAndAddress { get; set; }
            public string locationType { get; set; }
        }

        public class FedexTrackResponse_Locationcontactandaddress1
        {
            public FedexTrackResponse_Address3 address { get; set; }
        }

        public class FedexTrackResponse_Address3
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Lastupdateddestinationaddress
        {
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Servicedetail
        {
            public string type { get; set; }
            public string description { get; set; }
            public string shortDescription { get; set; }
        }

        public class FedexTrackResponse_Standardtransittimewindow
        {
            public FedexTrackResponse_Window window { get; set; }
        }

        public class FedexTrackResponse_Window
        {
            public DateTime ends { get; set; }
        }

        public class FedexTrackResponse_Estimateddeliverytimewindow
        {
            public FedexTrackResponse_Window1 window { get; set; }
        }

        public class FedexTrackResponse_Window1
        {
        }

        public class FedexTrackResponse_Returndetail
        {
        }

        public class FedexTrackResponse_Dateandtime
        {
            public string type { get; set; }
            public DateTime dateTime { get; set; }
        }

        public class FedexTrackResponse_Availableimage
        {
            public string type { get; set; }
        }

        public class FedexTrackResponse_Specialhandling
        {
            public string type { get; set; }
            public string description { get; set; }
            public string paymentType { get; set; }
        }

        public class FedexTrackResponse_Scanevent
        {
            public DateTime date { get; set; }
            public string eventType { get; set; }
            public string eventDescription { get; set; }
            public string exceptionCode { get; set; }
            public string exceptionDescription { get; set; }
            public FedexTrackResponse_Scanlocation1 scanLocation { get; set; }
            public string locationId { get; set; }
            public string locationType { get; set; }
            public string derivedStatusCode { get; set; }
            public string derivedStatus { get; set; }
            public FedexTrackResponse_Delaydetail delayDetail { get; set; }
        }

        public class FedexTrackResponse_Scanlocation1
        {
            public string[] streetLines { get; set; }
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
            public bool residential { get; set; }
            public string countryName { get; set; }
        }

        public class FedexTrackResponse_Delaydetail
        {
            public string type { get; set; }
        }

    }
}
