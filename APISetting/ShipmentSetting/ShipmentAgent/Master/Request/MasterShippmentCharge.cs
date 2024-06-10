using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request
{
    public class MasterShippmentCharge
    {
        public class ChargesRootobject
        {
            [JsonProperty(Required = Required.DisallowNull)]
            public Charges Charges { get; set; }
        }

        public class Charges
        {
            public ChargesHeader Header { get; set; }
            public List<ChargesShippmentLine> Line { get; set; }
            public List<ChargesShippmentBale> Bale { get; set; }
        }

        public class ChargesHeader
        {
            [StringLength(10)]
            public string ShipmentType { get; set; }

            [StringLength(10)]
            public string AgentCode { get; set; }

            [StringLength(6)]
            public string AccountNo { get; set; }

            [StringLength(35)]
            public string DropCity { get; set; }

            [StringLength(2)]
            public string DropCountryCode { get; set; }

            [StringLength(10)]
            public string DropPostalCode { get; set; }

            [StringLength(10)]
            public string DropStateOrProvinceCode { get; set; }

            [StringLength(5)]
            public string Currency { get; set; }

            [StringLength(40)]
            public string InvoiceNumber { get; set; }

            public decimal TotalDutiableDeclaredvalue { get; set; }

            [StringLength(5)]
            public string DutiableDeclaredCurrency { get; set; }
        }

        public class ChargesShippmentLine
        {
            //[StringLength(20)]
            //public string ItemCode { get; set; }

            //[StringLength(20)]
            //public string ItemName { get; set; }

            //[StringLength(20)]
            //public string BaleNo { get; set; }

            //[StringLength(4)]
            //public string CountryOfManufacture { get; set; }

            //public int quantity { get; set; }

            //[StringLength(500)]
            //public string Description { get; set; }

            //[StringLength(20)]
            //public string LineHarmonizedCode { get; set; }

            //[StringLength(5)]
            //public string Currency { get; set; }
            //public decimal InvoiceRatePerUnit { get; set; }
            //public decimal Line_Price_INR { get; set; }
            public decimal IGSTRate_INR { get; set; }
            public decimal IGSTAmount_INR { get; set; }
            public decimal SGSTAmount_INR { get; set; }
            public decimal CGSTAmount_INR { get; set; }
            public decimal CESSAmount_INR { get; set; }
            //public decimal LineWeight { get; set; } //new
            //public decimal InsuranceCharge_INR { get; set; }
            //public decimal FreightCharge_INR { get; set; }
            public decimal FinalPrice_INR { get; set; }
        }

        public class ChargesShippmentBale
        {

            //[StringLength(20)]
            //public string BaleNo { get; set; }
            //public int BaleOfCount { get; set; }

            [StringLength(450)]
            public string BaleDescription { get; set; }
            public int BaleNumberOfPieces { get; set; }
            public int BaleQuantity { get; set; }

            //[StringLength(5)]
            //public string BaleQuantityUnit { get; set; }

            //[StringLength(20)]
            //public string BaleHarmonizedCode { get; set; }
            //public decimal BalePriceAmount { get; set; }
            public decimal BaleCustomsAmount { get; set; }

            [StringLength(5)]
            public string BaleWeightUnits { get; set; }
            public decimal BaleWeightValue { get; set; }

            [StringLength(5)]
            public string BaleDimensionsUnit { get; set; }
            public decimal BaleDimensionsHeight { get; set; }
            public decimal BaleDimensionsLength { get; set; }
            public decimal BaleDimensionsWidth { get; set; }
        }
    }
}
