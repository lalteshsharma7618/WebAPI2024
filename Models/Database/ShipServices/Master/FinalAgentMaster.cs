using WEB_API_2024.Models.Database.ShipServices.Table;

namespace WEB_API_2024.Models.Database.ShipServices.Master
{
    public class FinalAgentMaster
    {
        public List<AgentMaster> GetAgentMasters { get; set; }
       public List<AgentSubMaster> GetAgentSubMasters { get; set; }
        public List<AgentDetail> GetAgentDetails { get; set; }
        public List<AccountMaster> GetAccountMasters { get; set; }
    }
}
