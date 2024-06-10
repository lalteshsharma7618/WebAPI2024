namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.Waybill.Request
{
    public class BlueDartWaybillMasterRequest
    {
        public class BlueDartRequestRootobject
        {
            public BlueDartWaybillRequest Request { get; set; }
            public BlueDartWaybillProfile Profile { get; set; }
        }

        public class BlueDartWaybillRequest
        {
            public BlueDartWaybillConsignee Consignee { get; set; }
            public BlueDartWaybillReturnadds Returnadds { get; set; }
            public BlueDartWaybillServices Services { get; set; }
            public BlueDartWaybillShipper Shipper { get; set; }
        }

        public class BlueDartWaybillConsignee
        {
            public string AvailableDays { get; set; }
            public string AvailableTiming { get; set; }
            public string ConsigneeAddress1 { get; set; }
            public string ConsigneeAddress2 { get; set; }
            public string ConsigneeAddress3 { get; set; }
            public string ConsigneeAddressType { get; set; }
            public string ConsigneeAddressinfo { get; set; }
            public string ConsigneeAttention { get; set; }
            public string ConsigneeEmailID { get; set; }
            public string ConsigneeFullAddress { get; set; }
            public string ConsigneeGSTNumber { get; set; }
            public string ConsigneeLatitude { get; set; }
            public string ConsigneeLongitude { get; set; }
            public string ConsigneeMaskedContactNumber { get; set; }
            public string ConsigneeMobile { get; set; }
            public string ConsigneeName { get; set; }
            public string ConsigneePincode { get; set; }
            public string ConsigneeTelephone { get; set; }
        }

        public class BlueDartWaybillReturnadds
        {
            public string ManifestNumber { get; set; }
            public string ReturnAddress1 { get; set; }
            public string ReturnAddress2 { get; set; }
            public string ReturnAddress3 { get; set; }
            public string ReturnAddressinfo { get; set; }
            public string ReturnContact { get; set; }
            public string ReturnEmailID { get; set; }
            public string ReturnLatitude { get; set; }
            public string ReturnLongitude { get; set; }
            public string ReturnMaskedContactNumber { get; set; }
            public string ReturnMobile { get; set; }
            public string ReturnPincode { get; set; }
            public string ReturnTelephone { get; set; }
        }

        public class BlueDartWaybillServices
        {
            public string AWBNo { get; set; }
            public string ActualWeight { get; set; }
            public decimal CollectableAmount { get; set; }
            public BlueDartWaybillCommodity Commodity { get; set; }
            public string CreditReferenceNo { get; set; }
            public string CreditReferenceNo2 { get; set; }
            public string CreditReferenceNo3 { get; set; }
            public decimal DeclaredValue { get; set; }
            public string DeliveryTimeSlot { get; set; }
            public List<BlueDartWaybillDimension> Dimensions { get; set; }
            public string FavouringName { get; set; }
            public bool IsDedicatedDeliveryNetwork { get; set; }
            public bool IsDutyTaxPaidByShipper { get; set; }
            public bool IsForcePickup { get; set; }
            public bool IsPartialPickup { get; set; }
            public bool IsReversePickup { get; set; }
            public int ItemCount { get; set; }
            public string Officecutofftime { get; set; }
            public bool PDFOutputNotRequired { get; set; }
            public string PackType { get; set; }
            public string ParcelShopCode { get; set; }
            public string PayableAt { get; set; }
            public string PickupDate { get; set; }
            public string PickupMode { get; set; }
            public string PickupTime { get; set; }
            public string PickupType { get; set; }
            public string PieceCount { get; set; }
            public string PreferredPickupTimeSlot { get; set; }
            public string ProductCode { get; set; }
            public string ProductFeature { get; set; }
            public int ProductType { get; set; }
            public bool RegisterPickup { get; set; }
            public string SpecialInstruction { get; set; }
            public string SubProductCode { get; set; }
            public int TotalCashPaytoCustomer { get; set; }
            public List<BlueDartWaybillItemDetail> itemdtl { get; set; }
            public int noOfDCGiven { get; set; }
        }

        public class BlueDartWaybillCommodity
        {
            public string CommodityDetail1 { get; set; }
            public string CommodityDetail2 { get; set; }
            public string CommodityDetail3 { get; set; }
        }

        public class BlueDartWaybillDimension
        {
            public decimal Breadth { get; set; }
            public int Count { get; set; }
            public decimal Height { get; set; }
            public decimal Length { get; set; }
        }

        public class BlueDartWaybillItemDetail
        {
            public decimal CGSTAmount { get; set; }
            public string HSCode { get; set; }
            public decimal IGSTAmount { get; set; }
            public string Instruction { get; set; }
            public string InvoiceDate { get; set; }
            public string InvoiceNumber { get; set; }
            public string ItemID { get; set; }
            public string ItemName { get; set; }
            public decimal ItemValue { get; set; }
            public int Itemquantity { get; set; }
            public string PlaceofSupply { get; set; }
            public string ProductDesc1 { get; set; }
            public string ProductDesc2 { get; set; }
            public string ReturnReason { get; set; }
            public decimal SGSTAmount { get; set; }
            public string SKUNumber { get; set; }
            public string SellerGSTNNumber { get; set; }
            public string SellerName { get; set; }
            public string SubProduct1 { get; set; }
            public string SubProduct2 { get; set; }
            public decimal TaxableAmount { get; set; }
            public decimal TotalValue { get; set; }
            public string cessAmount { get; set; }
            public string countryOfOrigin { get; set; }
            public string docType { get; set; }
            public int subSupplyType { get; set; }
            public string supplyType { get; set; }
        }

        public class BlueDartWaybillShipper
        {
            public string CustomerAddress1 { get; set; }
            public string CustomerAddress2 { get; set; }
            public string CustomerAddress3 { get; set; }
            public string CustomerAddressinfo { get; set; }
            public string CustomerBusinessPartyTypeCode { get; set; }
            public string CustomerCode { get; set; }
            public string CustomerEmailID { get; set; }
            public string CustomerGSTNumber { get; set; }
            public string CustomerLatitude { get; set; }
            public string CustomerLongitude { get; set; }
            public string CustomerMaskedContactNumber { get; set; }
            public string CustomerMobile { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPincode { get; set; }
            public string CustomerTelephone { get; set; }
            public bool IsToPayCustomer { get; set; }
            public string OriginArea { get; set; }
            public string Sender { get; set; }
            public string VendorCode { get; set; }
        }

        public class BlueDartWaybillProfile
        {
            public string LoginID { get; set; }
            public string LicenceKey { get; set; }
            public string Api_type { get; set; }
        }
    }
}
