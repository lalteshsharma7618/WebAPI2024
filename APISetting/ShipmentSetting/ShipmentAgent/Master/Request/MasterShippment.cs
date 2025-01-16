using System.ComponentModel.DataAnnotations;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request
{
    public class MasterShippment
    {
        public class ShippmentRootobject
        {
            public Shipment ShipmentMaster { get; set; }
        }

        public class Shipment
        {
            public ShippmentHeader Header { get; set; }
            public List<ShippmentLine> Line { get; set; }
            public List<ShippmentBale> Bale { get; set; }

            public ShippmentCommodity ShippmentCommodity { get; set; }
        }

        public class ShippmentHeader
        {
            [StringLength(10)]
            public string AgentCode { get; set; }

            [StringLength(6)]
            public string AccountNo { get; set; }

            [StringLength(10)]
            public string ShipmentType { get; set; }

            [StringLength(10)]
            public string LocationCode { get; set; }

            [StringLength(10)]
            public string OriginArea { get; set; }

            public string DocumentPdfInByte { get; set; }


            [StringLength(70)]
            public string DropPersonName { get; set; }

            [StringLength(70)]
            public string DropCompanyName { get; set; }

            public string DropPersonEmail { get; set; }

            [StringLength(15)]
            public string DropPhoneNumber { get; set; }

            [StringLength(30)]
            public string DropAddressFirst { get; set; }

            [StringLength(30)]
            public string DropAddressSecond { get; set; }

            [StringLength(30)]
            public string DropAddressThird { get; set; }

            [StringLength(35)]
            public string DropCity { get; set; }

            [StringLength(10)]
            public string DropStateOrProvinceCode { get; set; }

            [StringLength(10)]
            public string DropPostalCode { get; set; }

            [StringLength(2)]
            public string DropCountryCode { get; set; }

            [StringLength(50)]
            public string DropCountryName { get; set; }

            public double TotalCustomsValueAmount { get; set; }

            [StringLength(5)]
            public string Currency { get; set; }


            [StringLength(40)]
            public string InvoiceNumber { get; set; }


            public string InvoiceDate { get; set; }

            public string PickupDate { get; set; }

            [StringLength(40)]
            public string PONumber { get; set; }

            [StringLength(40)]
            public string CustomerRefrence { get; set; }

            [StringLength(5)]
            public string ProductCode { get; set; }

            [StringLength(5)]
            public string SubProductCode { get; set; }
            public double CodCollectableAmount { get; set; }  //new
            public decimal TotalInvoicePrice { get; set; }
            public double TotalDutiableDeclaredvalue { get; set; }

            [StringLength(10)]
            public string DutiesPaymentType { get; set; }

            [StringLength(5)]
            public string DutiableDeclaredCurrency { get; set; }

            [StringLength(5)]
            public string TermsOfTrade { get; set; }

            [StringLength(5)]
            public string IsUsingIGST { get; set; }

            [StringLength(5)]
            public string UsingBondorUT { get; set; }

            public double FreightCharge { get; set; }
            public double InsuranceCharge { get; set; }
            public double TotalIGST { get; set; }
            public decimal GrossWeight { get; set; } //new

            public string BillToCustomerCode { get; set; }
        }

        public class ShippmentLine
        {
            [StringLength(20)]
            public string ItemCode { get; set; }

            [StringLength(20)]
            public string ItemName { get; set; }

            [StringLength(20)]
            public string BaleNo { get; set; }

            [StringLength(4)]
            public string CountryOfManufacture { get; set; }

            public int quantity { get; set; }

            [StringLength(500)]
            public string Description { get; set; }

            [StringLength(20)]
            public string LineHarmonizedCode { get; set; }

            [StringLength(5)]
            public string Currency { get; set; }
            public decimal InvoiceRatePerUnit { get; set; }
            public decimal Line_Price_INR { get; set; }
            public decimal IGSTRate_INR { get; set; }
            public decimal IGSTAmount_INR { get; set; }
            public decimal SGSTAmount_INR { get; set; }
            public decimal CGSTAmount_INR { get; set; }
            public decimal CESSAmount_INR { get; set; }
            public decimal LineWeight { get; set; } //new
            public decimal InsuranceCharge_INR { get; set; }
            public decimal FreightCharge_INR { get; set; }
            public decimal FinalPrice_INR { get; set; }
        }

        public class ShippmentCommodity
        {
            public string CommodityDetail1 { get; set; }
            public string CommodityDetail2 { get; set; }
            public string CommodityDetail3 { get; set; }
        }

        public class ShippmentBale
        {

            [StringLength(20)]
            public string BaleNo { get; set; }
            public int BaleOfCount { get; set; }

            [StringLength(450)]
            public string BaleDescription { get; set; }
            public int BaleNumberOfPieces { get; set; }
            public int BaleQuantity { get; set; }

            [StringLength(5)]
            public string BaleQuantityUnit { get; set; }

            [StringLength(20)]
            public string BaleHarmonizedCode { get; set; }
            public decimal BalePriceAmount { get; set; }
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
