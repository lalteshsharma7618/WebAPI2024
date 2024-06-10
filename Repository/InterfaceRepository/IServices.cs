using WEB_API_2024.Models.Database.ShipServices.Table;

namespace WEB_API_2024.Repository.InterfaceRepository
{
    public interface IServices
    {
        List<AgentMaster> GetAgentMasters(string AgentCode);
        List<AgentSubMaster> GetSubAgents(string UserTokenNo, string AgentMasterTokenNo);

        List<AgentDetail> GetAgentDetails(string AgentSubMasterTokenNo);

        List<AccountMaster> GetAccountMasters(string UserTokenNo, string AccountNo);

        string InsertLogMaster(LogMaster logMaster);
    }
}
