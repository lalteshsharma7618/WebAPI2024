using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;
using WEB_API_2024.Models.Database.ShipServices.Master;
using System.Data;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Fedex.Waybill.Request
{
    public class FedexWaybillRequestSetting
    {
        public static string GetFedexWaybillRequestData(bool Livestatus, string DocumentName, string DocumentId, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            string Result = "";
            string bookingConfirmationNumber = "";
            var FinalLineWeightData = shippment.ShipmentMaster.Line.Where(x => x.LineWeight > 67);
            
            if (FinalLineWeightData.Count() > 0)
            {

                if (finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode.ToUpper().Equals("KA"))
                {
                    bookingConfirmationNumber = "BLRA123";
                }
                else if (finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode.ToUpper().Equals("DL"))
                {
                    bookingConfirmationNumber = "DELA123";
                }
                else if (finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode.ToUpper().Equals("MH"))
                {
                    bookingConfirmationNumber = "BOMA123";
                }
                else if (finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode.ToUpper().Equals("RJ"))
                {
                    bookingConfirmationNumber = "JAIA123";
                }
                else if (finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode.ToUpper().Equals("UP"))
                {
                    bookingConfirmationNumber = "VNSA123";
                }
                else if (finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode.ToUpper().Equals("MH"))
                {
                    bookingConfirmationNumber = "BOMA123";
                }
            }

            FedexWaybillMasterRequest.FedexWaybillRootobject FinalData = new FedexWaybillMasterRequest.FedexWaybillRootobject();

            List<FedexWaybillMasterRequest.FedexWaybillCommodity> commodities = new List<FedexWaybillMasterRequest.FedexWaybillCommodity>();
            List<FedexWaybillMasterRequest.FedexWaybillRequestedpackagelineitem> requestedPackageLineItems = new List<FedexWaybillMasterRequest.FedexWaybillRequestedpackagelineitem>();

            foreach (var Bale in shippment.ShipmentMaster.Bale)
            {
                FedexWaybillMasterRequest.FedexWaybillCommodity CMD = new FedexWaybillMasterRequest.FedexWaybillCommodity();
                FedexWaybillMasterRequest.FedexWaybillUnitprice unitPrice = new FedexWaybillMasterRequest.FedexWaybillUnitprice();
                FedexWaybillMasterRequest.FedexWaybillCustomsvalue customsValue = new FedexWaybillMasterRequest.FedexWaybillCustomsvalue();
                FedexWaybillMasterRequest.FedexWaybillWeight weight = new FedexWaybillMasterRequest.FedexWaybillWeight();

                CMD.description = Bale.BaleDescription;
                CMD.countryOfManufacture = finalAgentMaster.GetAccountMasters[0].CountryCode;
                CMD.numberOfPieces = Bale.BaleNumberOfPieces;
                CMD.quantity = Bale.BaleQuantity;
                CMD.quantityUnits = Bale.BaleQuantityUnit;
                CMD.harmonizedCode = Bale.BaleHarmonizedCode;

                unitPrice.amount = Bale.BalePriceAmount;
                unitPrice.currency = shippment.ShipmentMaster.Header.Currency;

                customsValue.amount = Bale.BaleCustomsAmount;
                customsValue.currency = shippment.ShipmentMaster.Header.Currency;

                weight.units = Bale.BaleWeightUnits;
                weight.value = Bale.BaleWeightValue;


                CMD.unitPrice = unitPrice;
                CMD.customsValue = customsValue;
                CMD.weight = weight;
                commodities.Add(CMD);


                List<FedexWaybillMasterRequest.FedexWaybillCustomerreference> CustomerreferenceList = new List<FedexWaybillMasterRequest.FedexWaybillCustomerreference>();
                FedexWaybillMasterRequest.FedexWaybillRequestedpackagelineitem RPLI = new FedexWaybillMasterRequest.FedexWaybillRequestedpackagelineitem();
                FedexWaybillMasterRequest.FedexWaybillWeight1 weight1 = new FedexWaybillMasterRequest.FedexWaybillWeight1();
                FedexWaybillMasterRequest.FedexWaybillDimensions dimensions = new FedexWaybillMasterRequest.FedexWaybillDimensions();

                FedexWaybillMasterRequest.FedexWaybillCustomerreference customerreference = new FedexWaybillMasterRequest.FedexWaybillCustomerreference();

                customerreference.customerReferenceType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("customerReferenceType_1").ToLower())).First().Value;
                customerreference.value = shippment.ShipmentMaster.Header.InvoiceNumber;
                CustomerreferenceList.Add(customerreference);

                customerreference = new FedexWaybillMasterRequest.FedexWaybillCustomerreference();
                customerreference.customerReferenceType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("customerReferenceType_2").ToLower())).First().Value;
                customerreference.value = shippment.ShipmentMaster.Header.PONumber;
                CustomerreferenceList.Add(customerreference);

                customerreference = new FedexWaybillMasterRequest.FedexWaybillCustomerreference();
                customerreference.customerReferenceType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("customerReferenceType_3").ToLower())).First().Value;
                customerreference.value = shippment.ShipmentMaster.Header.CustomerRefrence;

                CustomerreferenceList.Add(customerreference);

                //decimal TotalInvoicePrice = shippment.ShipmentMaster.Line.Sum(x => x.Line_Price_INR);
                decimal TotalInvoicePrice = shippment.ShipmentMaster.Header.TotalInvoicePrice;

                var FinalCheckInvoiceValue = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("TotalInvoicePrice_INR_ConditionValue").ToLower())).First().Value;
                if (Convert.ToDecimal(TotalInvoicePrice) <= Convert.ToDecimal(FinalCheckInvoiceValue))
                {
                    customerreference = new FedexWaybillMasterRequest.FedexWaybillCustomerreference();
                    customerreference.customerReferenceType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("customerReferenceType").ToLower())).First().Value;
                    var customerReferenceValue = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("customerReferenceValue").ToLower())).First().Value;
                    customerreference.value = customerReferenceValue + DateTime.Now.Date.ToString("ddMMyy");
                    CustomerreferenceList.Add(customerreference);
                }


                weight1.value = Bale.BaleWeightValue;
                weight1.units = Bale.BaleWeightUnits;

                dimensions.height = Bale.BaleDimensionsHeight;
                dimensions.length = Bale.BaleDimensionsLength;
                dimensions.units = Bale.BaleDimensionsUnit;
                dimensions.width = Bale.BaleDimensionsWidth;
                RPLI.dimensions = dimensions;

                RPLI.weight = weight1;

                RPLI.customerReferences = CustomerreferenceList;

                requestedPackageLineItems.Add(RPLI);
            }

            FinalData = new FedexWaybillMasterRequest.FedexWaybillRootobject
            {
                _Comment_ = "",
                labelResponseOptions = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("labelResponseOptions").ToLower())).First().Value,
                accountNumber = new FedexWaybillMasterRequest.FedexWaybillAccountnumber
                {
                    value = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("AccountNumber").ToLower())).First().Value
                },
                requestedShipment = new FedexWaybillMasterRequest.FedexWaybillRequestedshipment()
                {
                    totalPackageCount = "",
                    _Comment_ = "",
                    shipper = new FedexWaybillMasterRequest.FedexWaybillShipper()
                    {
                        contact = new FedexWaybillMasterRequest.FedexWaybillContact()
                        {
                            personName = finalAgentMaster.GetAccountMasters[0].Name == "" ? finalAgentMaster.GetAccountMasters[0].CompanyName : finalAgentMaster.GetAccountMasters[0].Name,
                            phoneNumber = finalAgentMaster.GetAccountMasters[0].MobileNo,
                            companyName = finalAgentMaster.GetAccountMasters[0].CompanyName
                        },
                        address = new FedexWaybillMasterRequest.FedexWaybillAddress()
                        {
                            streetLines = new List<string>()
                            {
                                finalAgentMaster.GetAccountMasters[0].AddressFirst,
                                finalAgentMaster.GetAccountMasters[0].AddressSecond == null ? "" : finalAgentMaster.GetAccountMasters[0].AddressSecond,
                                finalAgentMaster.GetAccountMasters[0].AddressThird == null ? "" : finalAgentMaster.GetAccountMasters[0].AddressThird
                            },
                            city = finalAgentMaster.GetAccountMasters[0].City,
                            stateOrProvinceCode = finalAgentMaster.GetAccountMasters[0].stateOrProvinceCode,
                            postalCode = finalAgentMaster.GetAccountMasters[0].PostalCode,
                            countryCode = finalAgentMaster.GetAccountMasters[0].CountryCode
                        },
                        tins = new List<FedexWaybillMasterRequest.FedexWaybillTin>
                        {
                            new FedexWaybillMasterRequest.FedexWaybillTin()
                            {
                                number = finalAgentMaster.GetAccountMasters[0].GSTNumber,
                                tinType = finalAgentMaster.GetAccountMasters[0].GSTType,
                            }
                        }
                    },
                    recipients = new List<FedexWaybillMasterRequest.FedexWaybillRecipient>
                    {
                        new FedexWaybillMasterRequest.FedexWaybillRecipient()
                        {
                            contact = new FedexWaybillMasterRequest.FedexWaybillContact1()
                            {
                                personName = shippment.ShipmentMaster.Header.DropPersonName,
                                phoneNumber = shippment.ShipmentMaster.Header.DropPhoneNumber,
                                companyName = shippment.ShipmentMaster.Header.DropCompanyName
                            },
                            address = new FedexWaybillMasterRequest.FedexWaybillAddress1()
                            {
                                streetLines = new List<string>()
                                {
                                    shippment.ShipmentMaster.Header.DropAddressFirst,
                                    shippment.ShipmentMaster.Header.DropAddressSecond == null ? "" : shippment.ShipmentMaster.Header.DropAddressSecond,
                                    shippment.ShipmentMaster.Header.DropAddressThird == null ? "" : shippment.ShipmentMaster.Header.DropAddressThird
                                },
                                city = shippment.ShipmentMaster.Header.DropCity,
                                stateOrProvinceCode = shippment.ShipmentMaster.Header.DropStateOrProvinceCode,
                                postalCode = shippment.ShipmentMaster.Header.DropPostalCode,
                                countryCode = shippment.ShipmentMaster.Header.DropCountryCode
                            }
                        }
                    },
                    shipDatestamp = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                    pickupType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupType").ToLower())).First().Value,
                    serviceType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ServiceType").ToLower())).First().Value,
                    packagingType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PackagingType").ToLower())).First().Value,
                    blockInsightVisibility = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("BlockInsightVisibility").ToLower())).First().Value),

                    shippingChargesPayment = new FedexWaybillMasterRequest.FedexWaybillShippingchargespayment()
                    {
                        paymentType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("paymentType").ToLower())).First().Value
                    },

                    shipmentSpecialServices = new FedexWaybillMasterRequest.FedexWaybillShipmentspecialservices()
                    {
                        specialServiceTypes = new List<string>()
                        {
                            finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("SpecialServiceTypes").ToLower())).First().Value
                        },
                        etdDetail = new FedexWaybillMasterRequest.FedexWaybillEtddetail()
                        {
                            attachedDocuments = new List<FedexWaybillMasterRequest.FedexWaybillAttacheddocument>()
                            {
                                new FedexWaybillMasterRequest.FedexWaybillAttacheddocument()
                                {
                                    documentReference=DocumentName,
                                    documentId=DocumentId,
                                    documentType=finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("DocumentType").ToLower())).First().Value,
                                    description=finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("DocumentDescription").ToLower())).First().Value,
                                }
                            }
                        }
                    },
                    customsClearanceDetail = new FedexWaybillMasterRequest.FedexWaybillCustomsclearancedetail()
                    {
                        _Comment_ = "",
                        totalCustomsValue = new FedexWaybillMasterRequest.FedexWaybillTotalcustomsvalue()
                        {
                            amount = Convert.ToDecimal(shippment.ShipmentMaster.Header.TotalCustomsValueAmount),
                            currency = shippment.ShipmentMaster.Header.Currency
                        },
                        isDocumentOnly = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsDocumentOnly").ToLower())).First().Value),
                        dutiesPayment = new FedexWaybillMasterRequest.FedexWaybillDutiespayment()
                        {
                            paymentType = shippment.ShipmentMaster.Header.DutiesPaymentType,

                        },
                        commodities = commodities
                    },
                    labelSpecification = new FedexWaybillMasterRequest.FedexWaybillLabelspecification()
                    {
                        imageType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LabelSpecificationImageType").ToLower())).First().Value,
                        labelStockType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LabelSpecificationLabelStockType").ToLower())).First().Value
                    },
                    expressFreightDetail = new FedexWaybillMasterRequest.FedexWaybillExpressfreightdetail()
                    {
                        bookingConfirmationNumber = bookingConfirmationNumber,
                        shippersLoadAndCount = Convert.ToInt32(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ShippersLoadAndCount").ToLower())).First().Value)
                    },
                    requestedPackageLineItems = requestedPackageLineItems
                }
            };

            Result = Newtonsoft.Json.JsonConvert.SerializeObject(FinalData);
            return Result;
        }
    }
}
