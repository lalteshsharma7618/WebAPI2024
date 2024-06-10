using Newtonsoft.Json;
using RestSharp;
using WEB_API_2024.Models.Database.ShipServices.Master;


namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API
{
    public static class FedexTokenMaster
    {
        public static FedexTokenRootobject GetTokenNo(bool Livestatus, FinalAgentMaster finalAgentMaster)
        {
            var FinalPostURL = "https://apis-sandbox.fedex.com";
            if (Livestatus)
            {
                FinalPostURL = "https://apis.fedex.com";
            }
            FinalPostURL = "https://apis.fedex.com";

            var options = new RestClientOptions(FinalPostURL)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/oauth/token", Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            //request.AddParameter("client_id",finalAgentMaster.GetAgentDetails.
            //    Where(x => x.Key.ToLower().Equals(Convert.ToString("client_id").ToLower())).First().Value);
            //request.AddParameter("client_secret", finalAgentMaster.GetAgentDetails.
            //    Where(x => x.Key.ToLower().Equals(Convert.ToString("client_secret").ToLower())).First().Value);

            request.AddParameter("client_id", "l792194829c0be4b79b11b23e7a5f1d649");
            request.AddParameter("client_secret", "ff5072cadd7d4b72a4ab9919b81a5027");

            RestResponse response = client.Execute(request);
            FedexTokenRootobject fedexTokenRootobject = JsonConvert.DeserializeObject<FedexTokenRootobject>(response.Content);

            return fedexTokenRootobject;
        }
    }


    public class FedexTokenRootobject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }

}
