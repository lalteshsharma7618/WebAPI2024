using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_2024.Models.Database.ShipServices.Table
{

    [Table("AgentDetail", Schema = "SHIP")]
    public partial class AgentDetail
    {
        public int id { get; set; }
        public string AgentSubMasterTokenNo { get; set; }
        public string DataType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
