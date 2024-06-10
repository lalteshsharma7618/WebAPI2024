using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;
using RestSharp;
using Newtonsoft.Json;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Request;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Document.Response;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.API
{
    public class FedexDocumentMaster
    {

        public static FedexDocumentResponse.FDR_Sys_Document_response FedexDocumentCreate(string FedexTokenno, bool Livestatus, string wwwPath, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            FedexDocumentResponse.FDR_Sys_Document_response fDR_Sys_Document_Response = new FedexDocumentResponse.FDR_Sys_Document_response();

            try
            {


                string filename = shippment.ShipmentMaster.Header.InvoiceNumber.Replace(" ", "-").Replace("/", "-") + ".pdf";
                string filepath = wwwPath + "\\Data\\pdf\\" + filename;
                string originCountryCode = finalAgentMaster.GetAccountMasters[0].CountryCode;
                string destinationCountryCode = shippment.ShipmentMaster.Header.DropCountryCode;

                #region File Write
                byte[] byteArray = Convert.FromBase64String(shippment.ShipmentMaster.Header.DocumentPdfInByte);
                using (var fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                }
                #endregion;

                var DocumentResuestData = FedexDocumentRequestSetting.FedexDocumentRequestRootObject(filename, filepath, originCountryCode, destinationCountryCode);
                string jsonData = JsonConvert.SerializeObject(DocumentResuestData.Document);

                var FinalPostURL = "https://apis-sandbox.fedex.com";
                if (Livestatus)
                {
                    FinalPostURL = "https://documentapi.prod.fedex.com";
                }
                FinalPostURL = "https://documentapi.prod.fedex.com";

                var options = new RestClientOptions(FinalPostURL)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/documents/v1/etds/upload", Method.Post);

                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddHeader("file", DocumentResuestData.filename);
                request.AddHeader("Authorization", "Bearer " + FedexTokenno);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("document", jsonData, ParameterType.RequestBody);
                request.AddFile("attachment", DocumentResuestData.filepath);
                RestResponse response = client.Execute(request);
                var DocumentResult = JsonConvert.DeserializeObject<FedexDocumentResponse.FDR_RootObject>(response.Content);

                if (DocumentResult == null || DocumentResult.output == null || DocumentResult.errors != null && DocumentResult.errors.Count != 0)
                {
                    string errormess = "";
                    if (DocumentResult != null && DocumentResult.errors != null)
                    {
                        foreach (var error in DocumentResult.errors)
                        {
                            errormess += error.code + " : " + error.message + "<br/>";
                        }
                    }
                    else if (DocumentResult != null && DocumentResult.error != null)
                    {
                        errormess += DocumentResult.status + " : " + DocumentResult.message + "<br/>";
                    }
                    else
                    {
                        errormess = "Invalid error occured from Fedex!";
                    }
                    fDR_Sys_Document_Response.message = errormess;
                    return fDR_Sys_Document_Response;
                }

                fDR_Sys_Document_Response.success = true;
                fDR_Sys_Document_Response.docid = DocumentResult.output.meta.docId;
                fDR_Sys_Document_Response.docname = filename;
            }
            catch (Exception ex)
            {
                fDR_Sys_Document_Response.message = ex.Message;
            }
            return fDR_Sys_Document_Response;
        }




    }

}
