using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Response.FedexDocumentResponse;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Response.FedexWaybillMasterResponse;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Response
{
    public class FedexWaybillMasterResponse
    {
        public class FDWMR_Rootobjectsss
        {
            //public string transactionId { get; set; }
            //public string customerTransactionId { get; set; }
            //public FDWMR_Output output { get; set; }
            //public List<FDWMR_Error> errors { get; set; }
        }


        public class FDWMR_Rootobject
        {
            public string transactionId { get; set; }
            public string customerTransactionId { get; set; }
            public FDWMR_Output output { get; set; }
            public List<FDWMR_Error> errors { get; set; }
        }
        public class FDWMR_Error
        {
            public string code { get; set; }
            public string message { get; set; }
        }
        public class FDWMR_Output
        {
            public List<FDWMR_Transactionshipment> transactionShipments { get; set; }
            public List<FDWMR_Alert> alerts { get; set; }
            public string jobId { get; set; }
        }
        public class FDWMR_Alert
        {
            public string code { get; set; }
            public string alertType { get; set; }
            public string message { get; set; }
        }
        public class FDWMR_Transactionshipment
        {
            public string masterTrackingNumber { get; set; }
            public string serviceType { get; set; }
            public string shipDatestamp { get; set; }
            public string serviceName { get; set; }
            public List<FDWMR_Piecerespons> pieceResponses { get; set; }
            public FDWMR_Shipmentadvisorydetails shipmentAdvisoryDetails { get; set; }
            public FDWMR_Completedshipmentdetail completedShipmentDetail { get; set; }
            public string serviceCategory { get; set; }

            public List<FDWMR_Shipmentdocument> shipmentDocuments { get; set; }
        }
        public class FDWMR_Shipmentdocument
        {
            public string contentKey { get; set; }
            public string copiesToPrint { get; set; }
            public string contentType { get; set; }
            public string trackingNumber { get; set; }
            public string docType { get; set; }
            public List<FDWMR_Alert> alerts { get; set; }
            public string encodedLabel { get; set; }
            public string url { get; set; }
        }
        public class FDWMR_Shipmentadvisorydetails
        {
        }

        public class FDWMR_Completedshipmentdetail
        {
            public bool usDomestic { get; set; }
            public string carrierCode { get; set; }
            public FDWMR_Mastertrackingid masterTrackingId { get; set; }
            public FDWMR_Servicedescription serviceDescription { get; set; }
            public string packagingDescription { get; set; }
            public FDWMR_Operationaldetail operationalDetail { get; set; }
            public FDWMR_Shipmentrating shipmentRating { get; set; }
            public List<FDWMR_Completedpackagedetail> completedPackageDetails { get; set; }
            public FDWMR_Documentrequirements documentRequirements { get; set; }
            public FDWMR_Completedetddetail completedEtdDetail { get; set; }
        }

        public class FDWMR_Mastertrackingid
        {
            public string trackingIdType { get; set; }
            public string formId { get; set; }
            public string trackingNumber { get; set; }
        }

        public class FDWMR_Servicedescription
        {
            public string serviceId { get; set; }
            public string serviceType { get; set; }
            public string code { get; set; }
            public List<FDWMR_Name> names { get; set; }
            public List<string> operatingOrgCodes { get; set; }
            public string serviceCategory { get; set; }
            public string description { get; set; }
            public string astraDescription { get; set; }
        }

        public class FDWMR_Name
        {
            public string type { get; set; }
            public string encoding { get; set; }
            public string value { get; set; }
        }

        public class FDWMR_Operationaldetail
        {
            public string ursaPrefixCode { get; set; }
            public string ursaSuffixCode { get; set; }
            public string originLocationId { get; set; }
            public string originLocationNumber { get; set; }
            public string originServiceArea { get; set; }
            public string destinationLocationId { get; set; }
            public string destinationLocationNumber { get; set; }
            public string destinationServiceArea { get; set; }
            public string destinationLocationStateOrProvinceCode { get; set; }
            public string deliveryDate { get; set; }
            public string deliveryDay { get; set; }
            public string commitDate { get; set; }
            public string commitDay { get; set; }
            public bool ineligibleForMoneyBackGuarantee { get; set; }
            public string astraPlannedServiceLevel { get; set; }
            public string astraDescription { get; set; }
            public string postalCode { get; set; }
            public string stateOrProvinceCode { get; set; }
            public string countryCode { get; set; }
            public string airportId { get; set; }
            public string serviceCode { get; set; }
            public string packagingCode { get; set; }
            public string publishedDeliveryTime { get; set; }
            public string scac { get; set; }
        }

        public class FDWMR_Shipmentrating
        {
            public string actualRateType { get; set; }
            public List<FDWMR_Shipmentratedetail> shipmentRateDetails { get; set; }
        }

        public class FDWMR_Shipmentratedetail
        {
            public string rateType { get; set; }
            public string rateScale { get; set; }
            public string rateZone { get; set; }
            public string pricingCode { get; set; }
            public string ratedWeightMethod { get; set; }
            public FDWMR_Currencyexchangerate currencyExchangeRate { get; set; }
            public string dimDivisor { get; set; }
            public string fuelSurchargePercent { get; set; }
            public FDWMR_Totalbillingweight totalBillingWeight { get; set; }
            public string totalBaseCharge { get; set; }
            public string totalFreightDiscounts { get; set; }
            public string totalNetFreight { get; set; }
            public string totalSurcharges { get; set; }
            public string totalNetFedExCharge { get; set; }
            public string totalTaxes { get; set; }
            public string totalNetCharge { get; set; }
            public string totalRebates { get; set; }
            public string totalDutiesAndTaxes { get; set; }
            public string totalAncillaryFeesAndTaxes { get; set; }
            public string totalDutiesTaxesAndFees { get; set; }
            public string totalNetChargeWithDutiesAndTaxes { get; set; }
            public List<FDWMR_Surcharge> surcharges { get; set; }
            public List<FDWMR_Freightdiscount> freightDiscounts { get; set; }
            public List<FDWMR_Tax> taxes { get; set; }
            public string currency { get; set; }
        }

        public class FDWMR_Currencyexchangerate
        {
            public string fromCurrency { get; set; }
            public string intoCurrency { get; set; }
            public string rate { get; set; }
        }

        public class FDWMR_Totalbillingweight
        {
            public string units { get; set; }
            public string value { get; set; }
        }

        public class FDWMR_Surcharge
        {
            public string surchargeType { get; set; }
            public string level { get; set; }
            public string description { get; set; }
            public string amount { get; set; }
        }

        public class FDWMR_Freightdiscount
        {
            public string rateDiscountType { get; set; }
            public string description { get; set; }
            public string percent { get; set; }
            public string amount { get; set; }
        }

        public class FDWMR_Tax
        {
            public string type { get; set; }
            public string description { get; set; }
            public string amount { get; set; }
        }

        public class FDWMR_Documentrequirements
        {
            public List<string> requiredDocuments { get; set; }
            public List<FDWMR_Generationdetail> generationDetails { get; set; }
            public List<string> prohibitedDocuments { get; set; }
        }

        public class FDWMR_Generationdetail
        {
            public string type { get; set; }
            public string minimumCopiesRequired { get; set; }
            public string letterhead { get; set; }
            public string electronicSignature { get; set; }
        }

        public class FDWMR_Completedetddetail
        {
            public string folderId { get; set; }
            public string type { get; set; }
            public List<FDWMR_Uploaddocumentreferencedetail> uploadDocumentReferenceDetails { get; set; }
        }

        public class FDWMR_Uploaddocumentreferencedetail
        {
            public string documentType { get; set; }
            public string documentId { get; set; }
        }

        public class FDWMR_Completedpackagedetail
        {
            public string sequenceNumber { get; set; }
            public List<FDWMR_Trackingid> trackingIds { get; set; }
            public string groupNumber { get; set; }
            public string signatureOption { get; set; }
            public FDWMR_Operationaldetail1 operationalDetail { get; set; }
        }

        public class FDWMR_Operationaldetail1
        {
            public FDWMR_Barcodes barcodes { get; set; }
            public string astraHandlingText { get; set; }
            public List<FDWMR_Operationalinstruction> operationalInstructions { get; set; }
        }

        public class FDWMR_Barcodes
        {
            public List<FDWMR_Binarybarcode> binaryBarcodes { get; set; }
            public List<FDWMR_Stringbarcode> stringBarcodes { get; set; }
        }

        public class FDWMR_Binarybarcode
        {
            public string type { get; set; }
            public string value { get; set; }
        }

        public class FDWMR_Stringbarcode
        {
            public string type { get; set; }
            public string value { get; set; }
        }

        public class FDWMR_Operationalinstruction
        {
            public string number { get; set; }
            public string content { get; set; }
        }

        public class FDWMR_Trackingid
        {
            public string trackingIdType { get; set; }
            public string formId { get; set; }
            public string trackingNumber { get; set; }
        }

        public class FDWMR_Piecerespons
        {
            public string masterTrackingNumber { get; set; }
            public string trackingNumber { get; set; }
            public string additionalChargesDiscount { get; set; }
            public string netRateAmount { get; set; }
            public string netChargeAmount { get; set; }
            public string netDiscountAmount { get; set; }
            public List<FDWMR_Packagedocument> packageDocuments { get; set; }
            public string currency { get; set; }
            public List<FDWMR_Customerreference> customerReferences { get; set; }
            public string codcollectionAmount { get; set; }
            public string baseRateAmount { get; set; }
        }

        public class FDWMR_Packagedocument
        {
            public string url { get; set; }
            public string contentType { get; set; }
            public string copiesToPrint { get; set; }
            public string docType { get; set; }
        }

        public class FDWMR_Customerreference
        {
            public string customerReferenceType { get; set; }
            public string value { get; set; }
        }


    }
}
