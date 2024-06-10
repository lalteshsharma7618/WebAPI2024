using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_2024.Models.Database.ShipServices.Table
{

    [Table("LogMaster", Schema = "SHIP")]
    public partial class LogMaster
    {
        public int id { get; set; }
        public string UserTokenNo { get; set; }
        public string InvoiceNo { get; set; }
        public string APIName { get; set; }
        public string AgentCode { get; set; }
        public string MasterJson { get; set; }
        public string AgentJson { get; set; }
        public string MasterResult { get; set; }
        public string AgentResult { get; set; }
        public string TrackingNo { get; set; }     
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}

