using Microsoft.EntityFrameworkCore;
using WEB_API_2024.Models.Database;
using WEB_API_2024.Models.Database.ERP.View;
using WEB_API_2024.Models.Database.ShipServices.Table;
using WEB_API_2024.Models.Database.Website.Table;

namespace WEB_API_2024.Models
{
    public class DBMaster : DbContext
    {
        public DBMaster(DbContextOptions<DBMaster> options) : base(options)
        {

        }

        public virtual DbSet<APIUserMaster> APIUserMasters { get; set; }
        public virtual DbSet<ProductData> ProductDatas { get; set; }
        public virtual DbSet<FinalProductDataWahtmoreAPI> FinalProductDataWahtmoreAPIs { get; set; }
        public virtual DbSet<LogMaster> LogMasters { get; set; }

        public virtual DbSet<AgentMaster> AgentMasters { get; set; }
        public virtual DbSet<AgentSubMaster> AgentSubMasters { get; set; }
        public virtual DbSet<AgentDetail> AgentDetails { get; set; }
        public virtual DbSet<AccountMaster> AccountMasters { get; set; }

        //ERP
        public virtual DbSet<NAVPosPortalData> NAVPosPortalDatas { get; set; }
    }
}
