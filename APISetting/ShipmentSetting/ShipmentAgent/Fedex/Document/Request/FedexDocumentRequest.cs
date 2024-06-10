namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Request
{
    public class FedexDocumentRequest
    {
        public class FedexDocumentRequestRootObject
        {
            public string filename { get; set; }
            public string filepath { get; set; }
            public FedexDocumentRequestDocument Document { get; set; }
        }


        public class FedexDocumentRequestDocument
        {
            public string workflowName { get; set; }
            public string carrierCode { get; set; }
            public string name { get; set; }
            public string contentType { get; set; }
            public FedexDocumentRequestMeta meta { get; set; }
        }

        public class FedexDocumentRequestMeta
        {
            public string shipDocumentType { get; set; }
            public string originCountryCode { get; set; }
            public string destinationCountryCode { get; set; }
        }

    }
}
