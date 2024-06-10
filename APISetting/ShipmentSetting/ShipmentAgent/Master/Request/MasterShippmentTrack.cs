using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request
{
    public class MasterShippmentTrack
    {
        public class ShippmentTrack
        {
            public string AgentCode { get; set; }
            public string AWBNumber { get; set; }
        }
    }
}
