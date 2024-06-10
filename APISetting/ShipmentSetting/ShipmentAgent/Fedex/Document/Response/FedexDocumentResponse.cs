using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Response.FedexWaybillMasterResponse;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Response
{
    public class FedexDocumentResponse
    {

        public class FDR_RootObject
        {
            public FDR_Output output { get; set; }
            public string customerTransactionId { get; set; }
            public List<FDR_Error> errors { get; set; }

            public string path { get; set; }
            public string error { get; set; }
            public string message { get; set; }
            public DateTime timestamp { get; set; }
            public string status { get; set; }
        }


        public class FDR_Sys_Document_response
        {
            public bool success { get; set; }
            public string message { get; set; }
            public string docid { get; set; }
            public string docname { get; set; }
        }
        public class FDR_Error
        {
            public string code { get; set; }
            public string message { get; set; }
        }


        public class FDR_Output
        {
            public FDR_Meta meta { get; set; }
        }

        public class FDR_Meta
        {
            public string documentType { get; set; }
            public string docId { get; set; }
            public object folderId { get; set; }
        }



    }
}
