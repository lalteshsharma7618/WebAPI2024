using WEB_API_2024.Models;
using WEB_API_2024.Models.Database.ShipServices.Table;
using WEB_API_2024.Repository.InterfaceRepository;

namespace WEB_API_2024.Repository.SQLRepository
{
    public class DBServices : IServices
    {
        private readonly DBMaster dBMaster;
        public DBServices(DBMaster dBMaster)
        {
            this.dBMaster = dBMaster;
        }
        public List<AccountMaster> GetAccountMasters(string UserTokenNo, string AccountNo)
        {
            return dBMaster.AccountMasters.Where(x => x.APIUserTokenNo == UserTokenNo && x.AccountNo == AccountNo).ToList();
        }

        public List<AgentDetail> GetAgentDetails(string AgentSubMasterTokenNo)
        {
            return dBMaster.AgentDetails.Where(x => x.AgentSubMasterTokenNo == AgentSubMasterTokenNo && x.Published==true).ToList();
        }

        public List<AgentMaster> GetAgentMasters(string AgentCode)
        {
            return dBMaster.AgentMasters.Where(x => x.AgentCode == AgentCode && x.Published == true).ToList();
        }

        public List<AgentSubMaster> GetSubAgents(string UserTokenNo, string AgentMasterTokenNo)
        {
            return dBMaster.AgentSubMasters.Where(x => x.APIUserTokenNo == UserTokenNo && x.AgentMasterTokenNo == AgentMasterTokenNo).ToList();
        }

        public string InsertLogMaster(LogMaster logMaster)
        {
            try
            {
                dBMaster.LogMasters.Add(logMaster);
                dBMaster.SaveChanges();
                return "";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
