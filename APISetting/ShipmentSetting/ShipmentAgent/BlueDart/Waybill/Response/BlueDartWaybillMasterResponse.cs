namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.Waybill.Response
{
    public class BlueDartWaybillMasterResponse
    {
        public class BlueDartResponseRootobject
        {
            public int status { get; set; }
            public string title { get; set; }

            public BlueDartGeneratewaybillresult GenerateWayBillResult { get; set; }

            [Newtonsoft.Json.JsonProperty("error-response")]
            public List<BlueDartErrorResponse> errorresponse { get; set; }
        }

        public class BlueDartErrorResponse
        {
            public string AWBNo { get; set; }
            public object AWBPrintContent { get; set; }
            public int AvailableAmountForBooking { get; set; }
            public int AvailableBalance { get; set; }
            public string CCRCRDREF { get; set; }
            public object ClusterCode { get; set; }
            public object DestinationArea { get; set; }
            public object DestinationLocation { get; set; }
            public object InvoicePrintContent { get; set; }
            public bool IsError { get; set; }
            public bool IsErrorInPU { get; set; }
            public List<BlueDartStatus> Status { get; set; }
            public object TokenNumber { get; set; }
            public int TransactionAmount { get; set; }
        }


        public class BlueDartGeneratewaybillresult
        {
            public string AWBNo { get; set; }
            public byte[] AWBPrintContent { get; set; }
            public int AvailableAmountForBooking { get; set; }
            public int AvailableBalance { get; set; }
            public string CCRCRDREF { get; set; }
            public string ClusterCode { get; set; }
            public string DestinationArea { get; set; }
            public string DestinationLocation { get; set; }
            public object InvoicePrintContent { get; set; }
            public bool IsError { get; set; }
            public bool IsErrorInPU { get; set; }
            public DateTime ShipmentPickupDate { get; set; }
            public List<BlueDartStatus> Status { get; set; }
            public string TokenNumber { get; set; }
            public int TransactionAmount { get; set; }
        }

        public class BlueDartStatus
        {
            public string StatusCode { get; set; }
            public string StatusInformation { get; set; }
        }
    }
}
