using RestSharp;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.TrackOrder.Request;
using WEB_API_2024.Models.Database.ShipServices.Master;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API
{
    public static class FedexTrackingMaster
    {
        public static string GetFedexTrackRequestData(bool Livestatus, FinalAgentMaster finalAgentMaster, string AWBNumber)
        {
            string Result = "";

            var FedexTokenResult = FedexTokenMaster.GetTokenNo(Livestatus, finalAgentMaster);
            var RequestData = FedexTrackRequestSetting.GetFedexTrackRequestData(AWBNumber);

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
            var request = new RestRequest("/track/v1/trackingnumbers", Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + FedexTokenResult.access_token);
            request.AddStringBody(RequestData, DataFormat.Json);
            RestResponse response = client.Execute(request);
            var FedexResult = response.Content;
            return Result;
        }
    }
}
