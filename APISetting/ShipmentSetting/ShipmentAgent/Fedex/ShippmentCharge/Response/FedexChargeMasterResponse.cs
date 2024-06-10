using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Response.FedexDocumentResponse;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Response.FedexChargeMasterResponse;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.ShippmentCharge.Response
{
    public class FedexChargeMasterResponse
    {
        public class FCR_ChargeResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public string serviceName { get; set; }
            public string customerMessages { get; set; }
            public double totalDiscounts { get; set; }
            public double totalBaseCharge { get; set; }
            public double totalNetCharge { get; set; }
            public double totalVatCharge { get; set; }
            public double totalNetFedExCharge { get; set; }
            public double totalDutiesAndTaxes { get; set; }
            public double totalNetChargeWithDutiesAndTaxes { get; set; }
            public double totalDutiesTaxesAndFees { get; set; }
            public double totalAncillaryFeesAndTaxes { get; set; }
            public string totalBillingWeight { get; set; }
            public string currency { get; set; }

        }


        public class FCR_Rootobject
        {
            public string transactionId { get; set; }
            public string customerTransactionId { get; set; }
            public FCR_Output output { get; set; }
            public List<FCR_Error> errors { get; set; }
        }

        public class FCR_Error
        {
            public string code { get; set; }
            public string message { get; set; }
        }
        public class FCR_Output
        {
            public List<FCR_Ratereplydetail> rateReplyDetails { get; set; }
            public string quoteDate { get; set; }
            public bool encoded { get; set; }
            public List<FCR_Alert> alerts { get; set; }
        }

        public class FCR_Ratereplydetail
        {
            public string serviceType { get; set; }
            public string serviceName { get; set; }
            public string packagingType { get; set; }
            public List<FCR_Customermessage> customerMessages { get; set; }
            public List<FCR_Ratedshipmentdetail> ratedShipmentDetails { get; set; }
            public bool anonymouslyAllowable { get; set; }
            public FCR_Operationaldetail operationalDetail { get; set; }
            public string signatureOptionType { get; set; }
            public FCR_Servicedescription serviceDescription { get; set; }
            public FCR_Commit commit { get; set; }
        }

        public class FCR_Operationaldetail
        {
            public string originLocationIds { get; set; }
            public string commitDays { get; set; }
            public string serviceCode { get; set; }
            public string airportId { get; set; }
            public string scac { get; set; }
            public string originServiceAreas { get; set; }
            public string deliveryDay { get; set; }
            public double originLocationNumbers { get; set; }
            public string destinationPostalCode { get; set; }
            public DateTime commitDate { get; set; }
            public string astraDescription { get; set; }
            public string deliveryDate { get; set; }
            public string deliveryEligibilities { get; set; }
            public bool ineligibleForMoneyBackGuarantee { get; set; }
            public string maximumTransitTime { get; set; }
            public string astraPlannedServiceLevel { get; set; }
            public string destinationLocationIds { get; set; }
            public string destinationLocationStateOrProvinceCodes { get; set; }
            public string transitTime { get; set; }
            public string packagingCode { get; set; }
            public double destinationLocationNumbers { get; set; }
            public string publishedDeliveryTime { get; set; }
            public string countryCodes { get; set; }
            public string stateOrProvinceCodes { get; set; }
            public string ursaPrefixCode { get; set; }
            public string ursaSuffixCode { get; set; }
            public string destinationServiceAreas { get; set; }
            public string originPostalCodes { get; set; }
            public string customTransitTime { get; set; }
        }

        public class FCR_Servicedescription
        {
            public string serviceId { get; set; }
            public string serviceType { get; set; }
            public string code { get; set; }
            public List<FCR_Name> names { get; set; }
            public List<string> operatingOrgCodes { get; set; }
            public string serviceCategory { get; set; }
            public string description { get; set; }
            public string astraDescription { get; set; }
        }

        public class FCR_Name
        {
            public string type { get; set; }
            public string encoding { get; set; }
            public string value { get; set; }
        }

        public class FCR_Commit
        {
            public FCR_Datedetail dateDetail { get; set; }
        }

        public class FCR_Datedetail
        {
            public string dayOfWeek { get; set; }
            public DateTime dayCxsFormat { get; set; }
        }

        public class FCR_Customermessage
        {
            public string code { get; set; }
            public string message { get; set; }
        }

        public class FCR_Ratedshipmentdetail
        {
            public string rateType { get; set; }
            public string ratedWeightMethod { get; set; }
            public float totalDiscounts { get; set; }
            public float totalBaseCharge { get; set; }
            public float totalNetCharge { get; set; }
            public double totalVatCharge { get; set; }
            public float totalNetFedExCharge { get; set; }
            public double totalDutiesAndTaxes { get; set; }
            public float totalNetChargeWithDutiesAndTaxes { get; set; }
            public double totalDutiesTaxesAndFees { get; set; }
            public double totalAncillaryFeesAndTaxes { get; set; }
            public FCR_Shipmentratedetail shipmentRateDetail { get; set; }
            public string currency { get; set; }
            public List<FCR_Ratedpackage> ratedPackages { get; set; }
            public bool anonymouslyAllowable { get; set; }
            public FCR_Operationaldetail1 operationalDetail { get; set; }
            public string signatureOptionType { get; set; }
            public FCR_Servicedescription1 serviceDescription { get; set; }
        }

        public class FCR_Shipmentratedetail
        {
            public string rateZone { get; set; }
            public double dimDivisor { get; set; }
            public float fuelSurchargePercent { get; set; }
            public float totalSurcharges { get; set; }
            public double totalFreightDiscount { get; set; }
            public List<FCR_Surcharge> surCharges { get; set; }
            public string pricingCode { get; set; }
            public FCR_Currencyexchangerate currencyExchangeRate { get; set; }
            public FCR_Totalbillingweight totalBillingWeight { get; set; }
            public string currency { get; set; }
        }

        public class FCR_Currencyexchangerate
        {
            public string fromCurrency { get; set; }
            public string intoCurrency { get; set; }
            public float rate { get; set; }
        }

        public class FCR_Totalbillingweight
        {
            public string units { get; set; }
            public double value { get; set; }
        }

        public class FCR_Surcharge
        {
            public string type { get; set; }
            public string description { get; set; }
            public float amount { get; set; }
            public string level { get; set; }
        }

        public class FCR_Operationaldetail1
        {
            public bool ineligibleForMoneyBackGuarantee { get; set; }
            public string astraDescription { get; set; }
            public string airportId { get; set; }
            public string serviceCode { get; set; }
            public string originLocationIds { get; set; }
            public string commitDays { get; set; }
            public string scac { get; set; }
            public string originServiceAreas { get; set; }
            public string deliveryDay { get; set; }
            public double originLocationNumbers { get; set; }
            public string destinationPostalCode { get; set; }
            public DateTime commitDate { get; set; }
            public string deliveryDate { get; set; }
            public string deliveryEligibilities { get; set; }
            public string maximumTransitTime { get; set; }
            public string astraPlannedServiceLevel { get; set; }
            public string destinationLocationIds { get; set; }
            public string destinationLocationStateOrProvinceCodes { get; set; }
            public string transitTime { get; set; }
            public string packagingCode { get; set; }
            public double destinationLocationNumbers { get; set; }
            public string publishedDeliveryTime { get; set; }
            public string countryCodes { get; set; }
            public string stateOrProvinceCodes { get; set; }
            public string ursaPrefixCode { get; set; }
            public string ursaSuffixCode { get; set; }
            public string destinationServiceAreas { get; set; }
            public string originPostalCodes { get; set; }
            public string customTransitTime { get; set; }
        }

        public class FCR_Servicedescription1
        {
            public string serviceId { get; set; }
            public string serviceType { get; set; }
            public string code { get; set; }
            public List<FCR_Name> names { get; set; }
            public List<string> operatingOrgCodes { get; set; }
            public string description { get; set; }
            public string astraDescription { get; set; }
        }

        public class FCR_Ratedpackage
        {
            public double groupNumber { get; set; }
            public float effectiveNetDiscount { get; set; }
            public FCR_Packageratedetail packageRateDetail { get; set; }
            public string rateType { get; set; }
            public string ratedWeightMethod { get; set; }
            public float baseCharge { get; set; }
            public float netFreight { get; set; }
            public float totalSurcharges { get; set; }
            public float netFedExCharge { get; set; }
            public double totalTaxes { get; set; }
            public float netCharge { get; set; }
            public double totalRebates { get; set; }
            public FCR_Billingweight billingWeight { get; set; }
            public double totalFreightDiscounts { get; set; }
            public List<FCR_Surcharge> surcharges { get; set; }
            public string currency { get; set; }
        }

        public class FCR_Packageratedetail
        {
            public string rateType { get; set; }
            public string ratedWeightMethod { get; set; }
            public float baseCharge { get; set; }
            public float netFreight { get; set; }
            public float totalSurcharges { get; set; }
            public float netFedExCharge { get; set; }
            public double totalTaxes { get; set; }
            public float netCharge { get; set; }
            public double totalRebates { get; set; }
            public FCR_Billingweight billingWeight { get; set; }
            public double totalFreightDiscounts { get; set; }
            public List<FCR_Surcharge> surcharges { get; set; }
            public string currency { get; set; }
        }

        public class FCR_Billingweight
        {
            public string units { get; set; }
            public double value { get; set; }
        }
        public class FCR_Alert
        {
            public string code { get; set; }
            public string message { get; set; }
            public string alertType { get; set; }
        }

    }
}
