using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.TrackOrder.Request.FedexTrackRequest;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.TrackOrder.Request
{
    public static class FedexTrackRequestSetting
    {
        public static string GetFedexTrackRequestData(string AWBNumber)
        {
            string Result = "";

            FedexTrackRequest_Rootobject fedexTrackRequest_Rootobject = new FedexTrackRequest_Rootobject();

            List<FedexTrackRequest_Trackinginfo> trackingInfo = new List<FedexTrackRequest_Trackinginfo>();

            FedexTrackRequest_Trackinginfo fedexTrackRequest_Trackinginfo = new FedexTrackRequest_Trackinginfo();
            fedexTrackRequest_Trackinginfo.trackingNumberInfo = new FedexTrackRequest_Trackingnumberinfo()
            {
                trackingNumber = AWBNumber,
                carrierCode = "FDXE"
            };
            trackingInfo.Add(fedexTrackRequest_Trackinginfo);

            fedexTrackRequest_Rootobject.trackingInfo = trackingInfo;

            fedexTrackRequest_Rootobject.includeDetailedScans = true;

            return Result;
        }
    }
}
