namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Request
{
    public class FedexWaybillMasterRequest
    {

        public class FedexWaybillRootobject
        {
            public string labelResponseOptions { get; set; }
            public FedexWaybillRequestedshipment requestedShipment { get; set; }
            public object _Comment_ { get; set; }
            public FedexWaybillAccountnumber accountNumber { get; set; }
        }

        public class FedexWaybillRequestedshipment
        {
            public FedexWaybillShipper shipper { get; set; }
            public List<FedexWaybillRecipient> recipients { get; set; }
            public string shipDatestamp { get; set; }
            public string serviceType { get; set; }
            public string packagingType { get; set; }
            public string pickupType { get; set; }
            public bool blockInsightVisibility { get; set; }
            public object _Comment_ { get; set; }
            public string totalPackageCount { get; set; }
            public FedexWaybillShippingchargespayment shippingChargesPayment { get; set; }
            public FedexWaybillLabelspecification labelSpecification { get; set; }
            public FedexWaybillExpressfreightdetail expressFreightDetail { get; set; }
            public FedexWaybillShipmentspecialservices shipmentSpecialServices { get; set; }
            public FedexWaybillCustomsclearancedetail customsClearanceDetail { get; set; }
            public List<FedexWaybillRequestedpackagelineitem> requestedPackageLineItems { get; set; }
        }

        public class FedexWaybillShipper
        {
            public FedexWaybillContact contact { get; set; }
            public FedexWaybillAddress address { get; set; }
            public List<FedexWaybillTin> tins { get; set; }
        }

        public class FedexWaybillContact
        {
            public string personName { get; set; }
            public string phoneNumber { get; set; }
            public string companyName { get; set; }
        }

        public class FedexWaybillAddress
        {
            public List<string> streetLines { get; set; }
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
        }

        public class FedexWaybillTin
        {
            public string number { get; set; }
            public string tinType { get; set; }
        }

        public class FedexWaybillShippingchargespayment
        {
            public string paymentType { get; set; }
        }

        public class FedexWaybillLabelspecification
        {
            public string imageType { get; set; }
            public string labelStockType { get; set; }
        }

        public class FedexWaybillExpressfreightdetail
        {
            public string bookingConfirmationNumber { get; set; }
            public int shippersLoadAndCount { get; set; }
        }

        public class FedexWaybillShipmentspecialservices
        {
            public List<string> specialServiceTypes { get; set; }
            public FedexWaybillEtddetail etdDetail { get; set; }
        }

        public class FedexWaybillEtddetail
        {
            public List<FedexWaybillAttacheddocument> attachedDocuments { get; set; }
        }

        public class FedexWaybillAttacheddocument
        {
            public string documentType { get; set; }
            public string documentReference { get; set; }
            public string description { get; set; }
            public string documentId { get; set; }
        }

        public class FedexWaybillCustomsclearancedetail
        {
            public FedexWaybillTotalcustomsvalue totalCustomsValue { get; set; }
            public FedexWaybillDutiespayment dutiesPayment { get; set; }
            public bool isDocumentOnly { get; set; }
            public List<FedexWaybillCommodity> commodities { get; set; }
            public object _Comment_ { get; set; }
        }

        public class FedexWaybillTotalcustomsvalue
        {
            public decimal amount { get; set; }
            public string currency { get; set; }
        }

        public class FedexWaybillDutiespayment
        {
            public string paymentType { get; set; }
        }

        public class FedexWaybillCommodity
        {
            public string description { get; set; }
            public string countryOfManufacture { get; set; }
            public int quantity { get; set; }
            public int numberOfPieces { get; set; }
            public string quantityUnits { get; set; }
            public FedexWaybillUnitprice unitPrice { get; set; }
            public FedexWaybillCustomsvalue customsValue { get; set; }
            public string harmonizedCode { get; set; }
            public FedexWaybillWeight weight { get; set; }
        }

        public class FedexWaybillUnitprice
        {
            public decimal amount { get; set; }
            public string currency { get; set; }
        }

        public class FedexWaybillCustomsvalue
        {
            public decimal amount { get; set; }
            public string currency { get; set; }
        }

        public class FedexWaybillWeight
        {
            public string units { get; set; }
            public decimal value { get; set; }
        }

        public class FedexWaybillRecipient
        {
            public FedexWaybillContact1 contact { get; set; }
            public FedexWaybillAddress1 address { get; set; }
        }

        public class FedexWaybillContact1
        {
            public string personName { get; set; }
            public string phoneNumber { get; set; }
            public string companyName { get; set; }
        }

        public class FedexWaybillAddress1
        {
            public List<string> streetLines { get; set; }
            public string city { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string postalCode { get; set; }
            public string countryCode { get; set; }
        }

        public class FedexWaybillRequestedpackagelineitem
        {
            public List<FedexWaybillCustomerreference> customerReferences { get; set; }
            public FedexWaybillDimensions dimensions { get; set; }
            public FedexWaybillWeight1 weight { get; set; }
        }

        public class FedexWaybillDimensions
        {
            public decimal length { get; set; }
            public decimal width { get; set; }
            public decimal height { get; set; }
            public string units { get; set; }
        }

        public class FedexWaybillWeight1
        {
            public string units { get; set; }
            public decimal value { get; set; }
        }

        public class FedexWaybillCustomerreference
        {
            public string customerReferenceType { get; set; }
            public string value { get; set; }
        }

        public class FedexWaybillAccountnumber
        {
            public string value { get; set; }
        }

    }
}
