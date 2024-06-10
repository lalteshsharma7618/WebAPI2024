using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_2024.Models.Database
{
    [Table("APIUserMaster", Schema = "dbo")]
    public partial class APIUserMaster
    {

        [Column(Order = 0)]
        public int id { get; set; }

        [StringLength(300)]
        public string TokenNo { get; set; }

        public string ClientId { get; set; }


        public string ClientSecret { get; set; }

        [Column(Order = 1)]
        [StringLength(300)]
        public string UserName { get; set; }


        [Column(Order = 2)]
        [StringLength(300)]
        public string Password { get; set; }

        public string GrantType { get; set; }

        public string Role { get; set; }

        public bool? LiveStatus { get; set; }
        public bool? Active { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
