namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response
{

    public class MasterChargeResponse
    {
        public bool success { get; set; }
        public string errormessage { get; set; }
        public List<ChargeResponseDatum> data { get; set; }
    }

    public class ChargeResponseDatum
    {
        public string AgentCode { get; set; }
        public string Currency { get; set; }
        public double TotalCharges { get; set; }
        public double TotalDuitableCharges { get; set; }
        public double TotalTax { get; set; }
        public bool AgentStatus { get; set; }
        public string Message { get; set; }
    }

}
