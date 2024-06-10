namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.TrackOrder.Request
{
    public class FedexTrackRequest
    {

        public class FedexTrackRequest_Rootobject
        {
            public List<FedexTrackRequest_Trackinginfo> trackingInfo { get; set; }
            public bool includeDetailedScans { get; set; }
        }

        public class FedexTrackRequest_Trackinginfo
        {
            public FedexTrackRequest_Trackingnumberinfo trackingNumberInfo { get; set; }
        }

        public class FedexTrackRequest_Trackingnumberinfo
        {
            public string carrierCode { get; set; }
            public string trackingNumber { get; set; }
        }

    }
}
