using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippmentCharge;
using System.IO.Pipelines;
using System.Xml.Linq;

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
        public double netFreight { get; set; }
        public double FuelSurcharges { get; set; }
        public double OverSizePiece { get; set; }
        public double ExportDeclaration { get; set; }
        public double DDPCharges { get; set; }
        public double GST { get; set; }
        public double FinalFreight { get; set; }



       
        public bool AgentStatus { get; set; }
        public string Message { get; set; }

        public string Description { get; set; }
    }

}
