namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.Tracking
{
    public static class DHLTrackingMaster
    {

        public static string GetDHLTrackAWBNumber(bool Livestatus, string AWBNumber)
        {
            string Result = "";

            DHLServices.DHLServiceClient.EndpointConfiguration endpointConfiguration = new DHLServices.DHLServiceClient.EndpointConfiguration();


            DHLServices.DHLServiceClient DHLServiceclient = new DHLServices.DHLServiceClient(endpointConfiguration);

            Result = DHLServiceclient.PostTrackingAsync(AWBNumber).Result;

            return Result;
        }

    }
}
