using Newtonsoft.Json;
using RestSharp;
using WEB_API_2024.Models.Database.ShipServices.Master;


namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API
{
    public static class FedexTokenMaster
    {
        public static string GetFedexAccountNo(FinalAgentMaster finalAgentMaster,string LocationCode)
        {
            string Result = "";
            if (LocationCode.ToUpper().Equals("LOC-200"))  //UP
            {
                Result = "206455615";
            }
            else if (LocationCode.ToUpper().Equals("LOC-300") || LocationCode.ToUpper().Equals("LOC-309") || LocationCode.ToUpper().Equals("LOC-339")) //Mumbai
            {
                Result = "206387368";
            }
            else if (LocationCode.ToUpper().Equals("LOC-168") || LocationCode.ToUpper().Equals("LOC-268")) //Delhi
            {
                Result = "206387427";
            }
            else
            {
                Result = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("AccountNumber").ToLower())).First().Value;
            }
            return Result;
        }
        public static FedexTokenRootobject GetTokenNo(bool Livestatus, FinalAgentMaster finalAgentMaster,string LocationCode)
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
            
            if(LocationCode.ToUpper().Equals("LOC-200"))  //UP
            {
                request.AddParameter("client_id", "l7326204831fbf4700a3863a625b229ea8");
                request.AddParameter("client_secret", "5840e4eddb144f72b35325d98248f254");
            }
            else if (LocationCode.ToUpper().Equals("LOC-300") || LocationCode.ToUpper().Equals("LOC-309")|| LocationCode.ToUpper().Equals("LOC-339")) //Mumbai
            {
                request.AddParameter("client_id", "l7534f594e472e41f59be8fa9fc3225544");
                request.AddParameter("client_secret", "8900e5e5f7464da280c59e24a9e108a8");
            }
            else if (LocationCode.ToUpper().Equals("LOC-168")|| LocationCode.ToUpper().Equals("LOC-268")) //Delhi
            {
                request.AddParameter("client_id", "l7d7c80e661c034d739a49bda3787b4509");
                request.AddParameter("client_secret", "af5ee9625e4d48f1bcc620013623fcee");
            }
            else
            {
                request.AddParameter("client_id", "l792194829c0be4b79b11b23e7a5f1d649");
                request.AddParameter("client_secret", "ff5072cadd7d4b72a4ab9919b81a5027");
            }

            //request.AddParameter("client_id", "l792194829c0be4b79b11b23e7a5f1d649");
            //request.AddParameter("client_secret", "ff5072cadd7d4b72a4ab9919b81a5027");

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
