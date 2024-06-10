using DHLServices;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using WEB_API_2024.Models.Database.ShipServices.Master;
using WEB_API_2024.Models.Database.ShipServices.Table;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.Waybill.Response.DHLWaybillMasterResponse;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Response;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.Waybill.API
{
    public class DHLWaybillMaster
    {

        public static LogMaster DHLWaybillCreate(bool Livestatus, string wwwPath, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            MasterResponse masterResponse = new MasterResponse();
            LogMaster logMaster = new LogMaster();
            try
            {

                DHLServiceClient.EndpointConfiguration endpointConfiguration = new DHLServiceClient.EndpointConfiguration();

                DHLServiceClient dHLServiceClient = new DHLServiceClient(endpointConfiguration);

                string SiteId = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("SiteId").ToLower())).First().Value;
                string Password = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("Password").ToLower())).First().Value;
                string ShipperName = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ShipperName").ToLower())).First().Value;

                string Shipmentpurpose = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("Shipmentpurpose").ToLower())).First().Value;
                string ShipperAccNumber = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ShipperAccNumber").ToLower())).First().Value;
                string ShippingPaymentType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ShippingPaymentType").ToLower())).First().Value;
                string BillingAccNumber = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("BillingAccNumber").ToLower())).First().Value;

                string SpecialService = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("SpecialService_1").ToLower())).First().Value;
                string TermsOfTrade = shippment.ShipmentMaster.Header.TermsOfTrade;
                if (TermsOfTrade.ToUpper().Equals(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("TermsOfTrade_1").ToLower())).First().Value.ToUpper()))
                {
                    SpecialService = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("SpecialService_2").ToLower())).First().Value;
                    TermsOfTrade = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("TermsOfTrade_2").ToLower())).First().Value;
                }

                string ConsigneeCompName = shippment.ShipmentMaster.Header.DropPersonName;
                string ConsigneeAddLine1 = shippment.ShipmentMaster.Header.DropAddressFirst;
                string ConsigneeAddLine2 = shippment.ShipmentMaster.Header.DropAddressSecond;
                string ConsigneeAddLine3 = shippment.ShipmentMaster.Header.DropAddressThird;
                string ConsigneeCity = shippment.ShipmentMaster.Header.DropCity;
                string ConsigneeDivCode = shippment.ShipmentMaster.Header.DropStateOrProvinceCode;
                string PostalCode = shippment.ShipmentMaster.Header.DropPostalCode;
                string ConsigneeCountryCode = shippment.ShipmentMaster.Header.DropCountryCode;
                string ConsigneeCountryName = shippment.ShipmentMaster.Header.DropCountryName;
                string ConsigneeName = shippment.ShipmentMaster.Header.DropPersonName;
                string ConsigneePh = shippment.ShipmentMaster.Header.DropPhoneNumber;
                string ConsigneeEmail = shippment.ShipmentMaster.Header.DropPersonEmail;

                if (shippment.ShipmentMaster.Header.DropCountryCode.ToUpper().Equals("AE"))
                {
                    PostalCode = "";
                    ConsigneeDivCode = "";
                }

                if (!shippment.ShipmentMaster.Header.DropCountryCode.ToUpper().Equals("US"))
                {
                    ConsigneeDivCode = "";
                }


                string DutiableDeclaredvalue = shippment.ShipmentMaster.Header.TotalDutiableDeclaredvalue.ToString();
                string DutiableDeclaredCurrency = shippment.ShipmentMaster.Header.DutiableDeclaredCurrency;
                string ShipCurrencyCode = shippment.ShipmentMaster.Header.Currency;

                bool INRStatus = false;

               
                if (shippment.ShipmentMaster.Line.Where(x => x.CGSTAmount_INR > 0 || x.IGSTAmount_INR > 0 || x.SGSTAmount_INR > 0).ToList().Count > 0)
                {
                    INRStatus = true;
                  
                }              
                if(INRStatus)
                {
                    DutiableDeclaredCurrency = "INR";
                    ShipCurrencyCode = "INR";
                    DutiableDeclaredvalue = shippment.ShipmentMaster.Line.Sum(x => x.FinalPrice_INR).ToString();
                }                

                string ShipNumberOfPieces = shippment.ShipmentMaster.Bale.Count.ToString();

                string ShipGlobalProductCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("GlobalProductCode").ToLower())).First().Value;
                string ShipLocalProductCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LocalProductCode").ToLower())).First().Value;
                string ShipContents = shippment.ShipmentMaster.Bale[0].BaleDescription;

                string ShipperId = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ShipperId").ToLower())).First().Value;
                string ShipperCompName = finalAgentMaster.GetAccountMasters[0].CompanyName;
                string ShipperAddress1 = finalAgentMaster.GetAccountMasters[0].AddressFirst;
                string ShipperAddress2 = finalAgentMaster.GetAccountMasters[0].AddressSecond;
                string ShipperAddress3 = finalAgentMaster.GetAccountMasters[0].AddressThird;
                string ShipperCountryCode = finalAgentMaster.GetAccountMasters[0].CountryCode;
                string ShipperCountryName = finalAgentMaster.GetAccountMasters[0].Country;
                string ShipperCity = finalAgentMaster.GetAccountMasters[0].City;
                string ShipperPostalCode = finalAgentMaster.GetAccountMasters[0].PostalCode;
                string ShipperPhoneNumber = finalAgentMaster.GetAccountMasters[0].MobileNo;

                string ShipperRef = shippment.ShipmentMaster.Header.InvoiceNumber;
                string GSTIN = finalAgentMaster.GetAccountMasters[0].GSTNumber;
                string GSTInvNo = shippment.ShipmentMaster.Header.InvoiceNumber;
                string GSTInvNoDate = Convert.ToDateTime(shippment.ShipmentMaster.Header.InvoiceDate).ToString("yyyy-MM-dd");
                string NonGSTInvNo = shippment.ShipmentMaster.Header.InvoiceNumber;
                string NonGSTInvDate = Convert.ToDateTime(shippment.ShipmentMaster.Header.InvoiceDate).ToString("yyyy-MM-dd");
                string IsUsingIGST = shippment.ShipmentMaster.Header.IsUsingIGST;
                string UsingBondorUT = shippment.ShipmentMaster.Header.UsingBondorUT;
                string UseDHLInvoice = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("UseDHLInvoice").ToLower())).First().Value;

                string FreightCharge = shippment.ShipmentMaster.Header.FreightCharge.ToString();
                string InsuranceCharge = shippment.ShipmentMaster.Header.InsuranceCharge.ToString();
                if (INRStatus)
                {
                    FreightCharge = shippment.ShipmentMaster.Line.Sum(x => x.FreightCharge_INR).ToString();
                    InsuranceCharge = shippment.ShipmentMaster.Line.Sum(x => x.InsuranceCharge_INR).ToString();
                }                 
               
                string TotalIGST = shippment.ShipmentMaster.Line.Sum(x => x.IGSTAmount_INR).ToString();
                string IsResponseRequired = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsResponseRequired").ToLower())).First().Value;
                string LabelReq = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LabelReq").ToLower())).First().Value;
                string InsuredAmount = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("InsuredAmount").ToLower())).First().Value;
                string isIndemnityClauseRead = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("isIndemnityClauseRead").ToLower())).First().Value;
                string DistanceInKM = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("DistanceInKM").ToLower())).First().Value;
                string CustomerBarcodeCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("CustomerBarcodeCode").ToLower())).First().Value;
                string CustomerBarcodeText = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("CustomerBarcodeText").ToLower())).First().Value;



                string RegistrationNumber = "";
                string RegistrationNumberTypeCode = "";
                string RegistrationNumberIssuerCountryCode = "";
                string BusinessPartyTypeCode = "";
                string ShipperRegistrationNumber = "";
                string ShipperRegistrationNumberTypeCode = "";
                string ShipperRegistrationNumberIssuerCountryCode = "";
                string ShipperBusinessPartyTypeCode = "";
                string BillToCompanyName = "";
                string BillToContactName = "";
                string BillToAddressLine1 = "";
                string BillToCity = "";
                string BillToPostcode = "";
                string BillToSuburb = "";
                string BillToState = "";
                string BillToCountryName = "";
                string BillToCountryCode = "";
                string BillToPhoneNumber = "";
                string Exporter_CompanyName = "";
                string Exporter_AddressLine1 = "";
                string Exporter_AddressLine2 = "";
                string Exporter_AddressLine3 = "";
                string Exporter_City = "";
                string Exporter_DivisionCode = "";
                string Exporter_PostalCode = "";
                string Exporter_CountryCode = "";
                string Exporter_CountryName = "";
                string Exporter_PersonName = "";
                string Exporter_PhoneNumber = "";
                string Exporter_Email = "";
                string Exporter_RegistrationNumber = "";
                string Exporter_RegistrationNumberTypeCode = "";
                string Exporter_RegistrationNumberIssuerCountryCode = "";
                string Exporter_BusinessPartyTypeCode = "";
                string SignatureName = "";
                string SignatureTitle = "";
                string LicenseNumber = "";
                string ExpiryDate = "";
                string CommodityCode = "";
                string PayerGSTVAT = "";
                string AddDeclText1 = "";
                string Destination_Duty_VAT_Charges = "";



                string ShipPieceWt = "";
                string ShipPieceDepth = "";
                string ShipPieceWidth = "";
                string ShipPieceHeight = "";
                string Weight = "";
                string ManufactureCountryCode = "";
                string ManufactureCountryName = "";
                string SerialNumber = "";
                string Description = "";
                string Qty = "";
                string HSCode = "";
                string ShipPieceUOM = "";
                int SerialNumber_index = 1;
                foreach (var Bale in shippment.ShipmentMaster.Bale)
                {
                    if (ShipPieceWt == "")
                    {
                        ShipPieceWt = Bale.BaleWeightValue.ToString();
                        ShipPieceDepth = Bale.BaleDimensionsLength.ToString();
                        ShipPieceWidth = Bale.BaleDimensionsWidth.ToString();
                        ShipPieceHeight = Bale.BaleDimensionsHeight.ToString();
                        Weight = Bale.BaleWeightValue.ToString();
                        ManufactureCountryCode = finalAgentMaster.GetAccountMasters[0].CountryCode;
                        ManufactureCountryName = finalAgentMaster.GetAccountMasters[0].Country;
                        SerialNumber = SerialNumber_index.ToString();
                        Description = SerialNumber_index + Bale.BaleDescription;

                        Qty = Bale.BaleQuantity.ToString();
                        HSCode = Bale.BaleHarmonizedCode;
                        ShipPieceUOM = Bale.BaleQuantityUnit.ToString();

                    }
                    else
                    {
                        ShipPieceWt += "," + Bale.BaleWeightValue.ToString();
                        ShipPieceDepth += "," + Bale.BaleDimensionsLength.ToString();
                        ShipPieceWidth += "," + Bale.BaleDimensionsWidth.ToString();
                        ShipPieceHeight += "," + Bale.BaleDimensionsHeight.ToString();
                        Weight += "," + Bale.BaleWeightValue.ToString();
                        ManufactureCountryCode += "," + finalAgentMaster.GetAccountMasters[0].CountryCode;
                        ManufactureCountryName += "," + finalAgentMaster.GetAccountMasters[0].Country;
                        SerialNumber += "," + SerialNumber_index.ToString();
                        Description += "," + SerialNumber_index + Bale.BaleDescription;

                        Qty += "," + Bale.BaleQuantity.ToString();
                        HSCode += "," + Bale.BaleHarmonizedCode;
                        ShipPieceUOM += "," + Bale.BaleQuantityUnit.ToString();
                    }
                    SerialNumber_index++;
                }

                string InvoiceRatePerUnit = "";
                string ShipPieceIGST = "";
                foreach (var Bale in shippment.ShipmentMaster.Bale)
                {
                    var LineData = shippment.ShipmentMaster.Line.Where(x => x.BaleNo.ToLower() == Bale.BaleNo.ToLower());
                    if (INRStatus)
                    {
                        if (InvoiceRatePerUnit == "")
                        {
                            InvoiceRatePerUnit = LineData.Sum(x => x.Line_Price_INR).ToString();
                        }
                        else
                        {
                            InvoiceRatePerUnit += "," + LineData.Sum(x => x.Line_Price_INR).ToString();
                        }

                        if (ShipPieceIGST == "")
                        {
                            ShipPieceIGST = LineData.Sum(x => x.IGSTAmount_INR).ToString();
                        }
                        else
                        {
                            ShipPieceIGST += "," + LineData.Sum(x => x.IGSTAmount_INR).ToString();
                        }
                    }
                    else
                    {
                        if (InvoiceRatePerUnit == "")
                        {
                            InvoiceRatePerUnit = LineData.Sum(x => x.InvoiceRatePerUnit).ToString();
                        }
                        else
                        {
                            InvoiceRatePerUnit += "," + LineData.Sum(x => x.InvoiceRatePerUnit).ToString();
                        }

                        if (ShipPieceIGST == "")
                        {
                            ShipPieceIGST = LineData.Sum(x => x.IGSTAmount_INR).ToString();
                        }
                        else
                        {
                            ShipPieceIGST += "," + LineData.Sum(x => x.IGSTAmount_INR).ToString();
                        }
                    }
                }


                var FinalResult = dHLServiceClient.PostShipment_CSBIV_CargoAsync(Shipmentpurpose, ShipperAccNumber, ShippingPaymentType, BillingAccNumber, ConsigneeCompName, ConsigneeAddLine1, ConsigneeAddLine2, ConsigneeAddLine3, ConsigneeCity, ConsigneeDivCode, PostalCode, ConsigneeCountryCode, ConsigneeCountryName, ConsigneeName, ConsigneePh, ConsigneeEmail, RegistrationNumber, RegistrationNumberTypeCode, RegistrationNumberIssuerCountryCode, BusinessPartyTypeCode, DutiableDeclaredvalue, DutiableDeclaredCurrency, ShipNumberOfPieces, ShipCurrencyCode, ShipPieceWt, ShipPieceDepth, ShipPieceWidth, ShipPieceHeight, ShipGlobalProductCode, ShipLocalProductCode, ShipContents, ShipperId, ShipperCompName, ShipperAddress1, ShipperAddress2, ShipperAddress3, ShipperCountryCode, ShipperCountryName, ShipperCity, ShipperPostalCode, ShipperPhoneNumber, SiteId, Password, ShipperName, ShipperRef, ShipperRegistrationNumber, ShipperRegistrationNumberTypeCode, ShipperRegistrationNumberIssuerCountryCode, ShipperBusinessPartyTypeCode, BillToCompanyName, BillToContactName, BillToAddressLine1, BillToCity, BillToPostcode, BillToSuburb, BillToState, BillToCountryName, BillToCountryCode, BillToPhoneNumber, TermsOfTrade, GSTIN, GSTInvNo, GSTInvNoDate, NonGSTInvNo, NonGSTInvDate, IsUsingIGST, UsingBondorUT, Exporter_CompanyName, Exporter_AddressLine1, Exporter_AddressLine2, Exporter_AddressLine3, Exporter_City, Exporter_DivisionCode, Exporter_PostalCode, Exporter_CountryCode, Exporter_CountryName, Exporter_PersonName, Exporter_PhoneNumber, Exporter_Email, Exporter_RegistrationNumber, Exporter_RegistrationNumberTypeCode, Exporter_RegistrationNumberIssuerCountryCode, Exporter_BusinessPartyTypeCode, UseDHLInvoice, SignatureName, SignatureTitle, LicenseNumber, ExpiryDate, ManufactureCountryCode, ManufactureCountryName, SerialNumber, Description, Qty, Weight, HSCode, CommodityCode, InvoiceRatePerUnit, ShipPieceUOM, ShipPieceIGST, FreightCharge, InsuranceCharge, TotalIGST, PayerGSTVAT, AddDeclText1, IsResponseRequired, LabelReq, SpecialService, InsuredAmount, isIndemnityClauseRead, DistanceInKM, Destination_Duty_VAT_Charges, CustomerBarcodeCode, CustomerBarcodeText).Result;

                string AgentRequestData = "<Shipmentpurpose>" + Shipmentpurpose + "</Shipmentpurpose><ShipperAccNumber>" + ShipperAccNumber + "</ShipperAccNumber><ShippingPaymentType>" + ShippingPaymentType + "</ShippingPaymentType><BillingAccNumber>" + BillingAccNumber + "</BillingAccNumber><ConsigneeCompName>" + ConsigneeCompName + "</ConsigneeCompName><ConsigneeAddLine1>" + ConsigneeAddLine1 + "</ConsigneeAddLine1><ConsigneeAddLine2>" + ConsigneeAddLine2 + "</ConsigneeAddLine2><ConsigneeAddLine3>" + ConsigneeAddLine3 + "</ConsigneeAddLine3><ConsigneeCity>" + ConsigneeCity + "</ConsigneeCity><ConsigneeDivCode>" + ConsigneeDivCode + "</ConsigneeDivCode><PostalCode>" + PostalCode + "</PostalCode><ConsigneeCountryCode>" + ConsigneeCountryCode + "</ConsigneeCountryCode><ConsigneeCountryName>" + ConsigneeCountryName + "</ConsigneeCountryName><ConsigneeName>" + ConsigneeName + "</ConsigneeName><ConsigneePh>" + ConsigneePh + "</ConsigneePh><ConsigneeEmail>" + ConsigneeEmail + "</ConsigneeEmail><RegistrationNumber>" + RegistrationNumber + "</RegistrationNumber><RegistrationNumberTypeCode>" + RegistrationNumberTypeCode + "</RegistrationNumberTypeCode><RegistrationNumberIssuerCountryCode>" + RegistrationNumberIssuerCountryCode + "</RegistrationNumberIssuerCountryCode><BusinessPartyTypeCode>" + BusinessPartyTypeCode + "</BusinessPartyTypeCode><DutiableDeclaredvalue>" + DutiableDeclaredvalue + "</DutiableDeclaredvalue><DutiableDeclaredCurrency>" + DutiableDeclaredCurrency + "</DutiableDeclaredCurrency><ShipNumberOfPieces>" + ShipNumberOfPieces + "</ShipNumberOfPieces><ShipCurrencyCode>" + ShipCurrencyCode + "</ShipCurrencyCode><ShipPieceWt>" + ShipPieceWt + "</ShipPieceWt><ShipPieceDepth>" + ShipPieceDepth + "</ShipPieceDepth><ShipPieceWidth>" + ShipPieceWidth + "</ShipPieceWidth><ShipPieceHeight>" + ShipPieceHeight + "</ShipPieceHeight><ShipGlobalProductCode>" + ShipGlobalProductCode + "</ShipGlobalProductCode><ShipLocalProductCode>" + ShipLocalProductCode + "</ShipLocalProductCode><ShipContents>" + ShipContents + "</ShipContents><ShipperId>" + ShipperId + "</ShipperId><ShipperCompName>" + ShipperCompName + "</ShipperCompName><ShipperAddress1>" + ShipperAddress1 + "</ShipperAddress1><ShipperAddress2>" + ShipperAddress2 + "</ShipperAddress2><ShipperAddress3>" + ShipperAddress3 + "</ShipperAddress3><ShipperCountryCode>" + ShipperCountryCode + "</ShipperCountryCode><ShipperCountryName>" + ShipperCountryName + "</ShipperCountryName><ShipperCity>" + ShipperCity + "</ShipperCity><ShipperPostalCode>" + ShipperPostalCode + "</ShipperPostalCode><ShipperPhoneNumber>" + ShipperPhoneNumber + "</ShipperPhoneNumber><SiteId>" + SiteId + "</SiteId><Password>" + Password + "</Password><ShipperName>" + ShipperName + "</ShipperName><ShipperRef>" + ShipperRef + "</ShipperRef><ShipperRegistrationNumber>" + ShipperRegistrationNumber + "</ShipperRegistrationNumber><ShipperRegistrationNumberTypeCode>" + ShipperRegistrationNumberTypeCode + "</ShipperRegistrationNumberTypeCode><ShipperRegistrationNumberIssuerCountryCode>" + ShipperRegistrationNumberIssuerCountryCode + "</ShipperRegistrationNumberIssuerCountryCode><ShipperBusinessPartyTypeCode>" + ShipperBusinessPartyTypeCode + "</ShipperBusinessPartyTypeCode><BillToCompanyName>" + BillToCompanyName + "</BillToCompanyName><BillToContactName>" + BillToContactName + "</BillToContactName><BillToAddressLine1>" + BillToAddressLine1 + "</BillToAddressLine1><BillToCity>" + BillToCity + "</BillToCity><BillToPostcode>" + BillToPostcode + "</BillToPostcode><BillToSuburb>" + BillToSuburb + "</BillToSuburb><BillToState>" + BillToState + "</BillToState><BillToCountryName>" + BillToCountryName + "</BillToCountryName><BillToCountryCode>" + BillToCountryCode + "</BillToCountryCode><BillToPhoneNumber>" + BillToPhoneNumber + "</BillToPhoneNumber><TermsOfTrade>" + TermsOfTrade + "</TermsOfTrade><GSTIN>" + GSTIN + "</GSTIN><GSTInvNo>" + GSTInvNo + "</GSTInvNo><GSTInvNoDate>" + GSTInvNoDate + "</GSTInvNoDate><NonGSTInvNo>" + NonGSTInvNo + "</NonGSTInvNo><NonGSTInvDate>" + NonGSTInvDate + "</NonGSTInvDate><IsUsingIGST>" + IsUsingIGST + "</IsUsingIGST><UsingBondorUT>" + UsingBondorUT + "</UsingBondorUT><Exporter_CompanyName>" + Exporter_CompanyName + "</Exporter_CompanyName><Exporter_AddressLine1>" + Exporter_AddressLine1 + "</Exporter_AddressLine1><Exporter_AddressLine2>" + Exporter_AddressLine2 + "</Exporter_AddressLine2><Exporter_AddressLine3>" + Exporter_AddressLine3 + "</Exporter_AddressLine3><Exporter_City>" + Exporter_City + "</Exporter_City><Exporter_DivisionCode>" + Exporter_DivisionCode + "</Exporter_DivisionCode><Exporter_PostalCode>" + Exporter_PostalCode + "</Exporter_PostalCode><Exporter_CountryCode>" + Exporter_CountryCode + "</Exporter_CountryCode><Exporter_CountryName>" + Exporter_CountryName + "</Exporter_CountryName><Exporter_PersonName>" + Exporter_PersonName + "</Exporter_PersonName><Exporter_PhoneNumber>" + Exporter_PhoneNumber + "</Exporter_PhoneNumber><Exporter_Email>" + Exporter_Email + "</Exporter_Email><Exporter_RegistrationNumber>" + Exporter_RegistrationNumber + "</Exporter_RegistrationNumber><Exporter_RegistrationNumberTypeCode>" + Exporter_RegistrationNumberTypeCode + "</Exporter_RegistrationNumberTypeCode><Exporter_RegistrationNumberIssuerCountryCode>" + Exporter_RegistrationNumberIssuerCountryCode + "</Exporter_RegistrationNumberIssuerCountryCode><Exporter_BusinessPartyTypeCode>" + Exporter_BusinessPartyTypeCode + "</Exporter_BusinessPartyTypeCode><UseDHLInvoice>" + UseDHLInvoice + "</UseDHLInvoice><SignatureName>" + SignatureName + "</SignatureName><SignatureTitle>" + SignatureTitle + "</SignatureTitle><LicenseNumber>" + LicenseNumber + "</LicenseNumber><ExpiryDate>" + ExpiryDate + "</ExpiryDate><ManufactureCountryCode>" + ManufactureCountryCode + "</ManufactureCountryCode><ManufactureCountryName>" + ManufactureCountryName + "</ManufactureCountryName><SerialNumber>" + SerialNumber + "</SerialNumber><Description>" + Description + "</Description><Qty>" + Qty + "</Qty><Weight>" + Weight + "</Weight><HSCode>" + HSCode + "</HSCode><CommodityCode>" + CommodityCode + "</CommodityCode><InvoiceRatePerUnit>" + InvoiceRatePerUnit + "</InvoiceRatePerUnit><ShipPieceUOM>" + ShipPieceUOM + "</ShipPieceUOM><ShipPieceIGST>" + ShipPieceIGST + "</ShipPieceIGST><FreightCharge>" + FreightCharge + "</FreightCharge><InsuranceCharge>" + InsuranceCharge + "</InsuranceCharge><TotalIGST>" + TotalIGST + "</TotalIGST><PayerGSTVAT>" + PayerGSTVAT + "</PayerGSTVAT><AddDeclText1>" + AddDeclText1 + "</AddDeclText1><IsResponseRequired>" + IsResponseRequired + "</IsResponseRequired><LabelReq>" + LabelReq + "</LabelReq><SpecialService>" + SpecialService + "</SpecialService><InsuredAmount>" + InsuredAmount + "</InsuredAmount><isIndemnityClauseRead>" + isIndemnityClauseRead + "</isIndemnityClauseRead><DistanceInKM>" + DistanceInKM + "</DistanceInKM><Destination_Duty_VAT_Charges>" + Destination_Duty_VAT_Charges + "</Destination_Duty_VAT_Charges><CustomerBarcodeCode>" + CustomerBarcodeCode + "</CustomerBarcodeCode><CustomerBarcodeText>" + CustomerBarcodeText + "</CustomerBarcodeText>";


                logMaster.AgentCode = shippment.ShipmentMaster.Header.AgentCode;
                logMaster.InvoiceNo = shippment.ShipmentMaster.Header.CustomerRefrence;
                string strJson = JsonConvert.SerializeObject(shippment);
                logMaster.MasterJson = strJson;
                logMaster.AgentJson = AgentRequestData;
                logMaster.AgentResult = JsonConvert.SerializeObject(FinalResult);
                logMaster.TrackingNo = "";


                ShipmentRecords shipmentRecords = new ShipmentRecords();
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ShipmentRecords));
                    using (TextReader reader = new StringReader(FinalResult))
                    {
                        shipmentRecords = (ShipmentRecords)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    ConditionData dHLEMR_ConditionData = new ConditionData();
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ConditionData));
                        using (StringReader reader = new StringReader(FinalResult))
                        {
                            dHLEMR_ConditionData = (ConditionData)serializer.Deserialize(reader);
                        }

                        if (dHLEMR_ConditionData == null || dHLEMR_ConditionData.Text == null || dHLEMR_ConditionData.Text == "")
                        {
                            masterResponse.errormessage = "Invalid error occured from DHL!";
                        }
                        else
                        {
                            masterResponse.errormessage = dHLEMR_ConditionData.Text;
                        }
                    }
                    catch (Exception ex1)
                    {
                        masterResponse.errormessage = ex1.Message;
                    }
                }

                if (shipmentRecords == null || shipmentRecords.ShipmentRecord == null || shipmentRecords.ShipmentRecord.PDFLabelPath == null || shipmentRecords.ShipmentRecord.PDFLabelPath == "")
                {
                    if (masterResponse.errormessage == null && masterResponse.errormessage == "")
                    {
                        masterResponse.errormessage = "Invalid error occured from DHL!";
                    }

                }
                else
                {
                    try
                    {
                        int indexId = 0;
                        foreach (var item in shipmentRecords.ShipmentRecord.GeneralInfo.Shipment.ItemsElementName)
                        {
                            if (item.ToString().ToLower() == "id")
                            {
                                break;
                            }
                            indexId++;
                        }

                        var AWBNumber = shipmentRecords.ShipmentRecord.GeneralInfo.Shipment.Items[indexId].ToString();
                        var LabelUrl= shipmentRecords.ShipmentRecord.PDFLabelPath;
                        var AgentCode= shippment.ShipmentMaster.Header.AgentCode; ;

                        List<MasterShippmentResponse> FinalData = new List<MasterShippmentResponse>()
                        {
                            new MasterShippmentResponse()
                            {
                                AWBNumber = AWBNumber.ToString(),
                                LabelUrl = LabelUrl.ToString(),
                                AgentCode = AgentCode.ToString(),
                                DestinationArea = "",
                                DestinationLocation = "",
                                ClusterCode = ""

                                 
                            }
                        };

                        masterResponse.data = FinalData;
                        masterResponse.success = true;
                        logMaster.TrackingNo = AWBNumber;                       
                    }
                    catch (Exception ex)
                    {
                        masterResponse.errormessage = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                masterResponse.errormessage = ex.Message;
            }
           
            logMaster.MasterResult = JsonConvert.SerializeObject(masterResponse);
            logMaster.CreateDate = DateTime.Now;
            logMaster.ModifyDate = DateTime.Now;
            logMaster.APIName = "Waybill";
            return logMaster;

        }

    }
}
