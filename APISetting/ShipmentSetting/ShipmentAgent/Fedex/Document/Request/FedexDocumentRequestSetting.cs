using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Request
{
    public static class FedexDocumentRequestSetting
    {
        public static FedexDocumentRequest.FedexDocumentRequestRootObject FedexDocumentRequestRootObject(string filename, string filepath, string originCountryCode, string destinationCountryCode)
        {

            FedexDocumentRequest.FedexDocumentRequestRootObject fedexDocumentRequestRootObject = new FedexDocumentRequest.FedexDocumentRequestRootObject()
            {
                filename = filename,
                filepath = filepath,
                Document = new FedexDocumentRequest.FedexDocumentRequestDocument()
                {
                    workflowName = "ETDPreshipment",
                    carrierCode = "FDXE",
                    name = filename,
                    contentType = "application/pdf",
                    meta = new FedexDocumentRequest.FedexDocumentRequestMeta()
                    {
                        shipDocumentType = "USMCA_COMMERCIAL_INVOICE_CERTIFICATION_OF_ORIGIN",
                        originCountryCode = originCountryCode,
                        destinationCountryCode = destinationCountryCode
                    },
                }
            };
            return fedexDocumentRequestRootObject;
        }
    }
}
