using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_2024.Models.Database.ShipServices.Table
{
   
    [Table("AgentMaster", Schema = "SHIP")]
    public partial class AgentMaster
    {
        public int id { get; set; }
        public string TokenNo { get; set; }       
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string AgentDescription { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
