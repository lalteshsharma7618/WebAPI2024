using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_2024.Models.Database.ShipServices.Table
{
    [Table("AccountMaster", Schema = "SHIP")]
    public partial class AccountMaster
    {
        public int id { get; set; }
        public string TokenNo { get; set; }
        public string APIUserTokenNo { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string MobileNo { get; set; }       
        public string TelephoneNo { get; set; }
        public string AddressFirst { get; set; }
        public string AddressSecond { get; set; }
        public string AddressThird { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string stateOrProvinceCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string OriginAreaCode { get; set; }
        public string GSTType { get; set; }
        public string GSTNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}
