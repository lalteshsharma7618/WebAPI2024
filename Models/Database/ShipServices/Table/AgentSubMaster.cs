using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_2024.Models.Database.ShipServices.Table
{

    [Table("AgentSubMaster", Schema = "SHIP")]
    public partial class AgentSubMaster
    {
        public int id { get; set; }
        public string TokenNo { get; set; }
        public string APIUserTokenNo { get; set; }
        public string AgentMasterTokenNo { get; set; }       
        public string ApplicationName { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
