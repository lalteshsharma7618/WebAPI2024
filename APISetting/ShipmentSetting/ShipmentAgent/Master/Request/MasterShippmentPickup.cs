using System.ComponentModel.DataAnnotations;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request
{
    public class MasterShippmentPickup
    {
        public class PickupRootobject
        {
            public Pickup Pickup { get; set; }
        }

        public class Pickup
        {
            public PickupHeader Header { get; set; }
            public List<ShippmentLine> Line { get; set; }
            public List<ShippmentBale> Bale { get; set; }
        }

        public class PickupHeader
        {
            [StringLength(10)]
            public string AgentCode { get; set; }

            [StringLength(6)]
            public string AccountNo { get; set; }

            public string InvoiceNumber { get; set; }
            public DateTime PickupDatetimestamp { get; set; }
            public double PickupTotalWeight { get; set; }
        }
    }
}
