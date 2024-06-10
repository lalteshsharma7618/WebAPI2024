using System.Data;
using WEB_API_2024.Models.Database.ShipServices.Master;
using static WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.Master.Request.MasterShippment;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.BlueDart.Waybill.Request
{
    public class BlueDartWaybillRequestSetting
    {
        public static int ToUnixTimeSeconds(DateTime date)
        {
            DateTime point = new DateTime(1970, 1, 1);
            TimeSpan time = date.Subtract(point);

            return (int)time.TotalSeconds;
        }

        public static string GetBluedartWaybillRequestData(bool Livestatus, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            string Result = "";
            BlueDartWaybillMasterRequest.BlueDartRequestRootobject FinalData = new BlueDartWaybillMasterRequest.BlueDartRequestRootobject();

            var Commodity = new BlueDartWaybillMasterRequest.BlueDartWaybillCommodity()
            {
                CommodityDetail1 = shippment.ShipmentMaster.ShippmentCommodity.CommodityDetail1,
                CommodityDetail2 = shippment.ShipmentMaster.ShippmentCommodity.CommodityDetail2,
                CommodityDetail3 = shippment.ShipmentMaster.ShippmentCommodity.CommodityDetail3,
            };

            List<BlueDartWaybillMasterRequest.BlueDartWaybillDimension> DimensionsDetails = new List<BlueDartWaybillMasterRequest.BlueDartWaybillDimension>();
            List<BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail> ItemDetailsData = new List<BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail>();

            foreach (var InvoiceBale in shippment.ShipmentMaster.Bale)
            {
                BlueDartWaybillMasterRequest.BlueDartWaybillDimension dim = new BlueDartWaybillMasterRequest.BlueDartWaybillDimension();
                dim.Length = Convert.ToDecimal(InvoiceBale.BaleDimensionsLength);
                dim.Breadth = Convert.ToDecimal(InvoiceBale.BaleDimensionsWidth);
                dim.Height = Convert.ToDecimal(InvoiceBale.BaleDimensionsHeight);
                dim.Count = Convert.ToInt32(InvoiceBale.BaleOfCount);
                //dim.Count = Convert.ToInt32(1);
                DimensionsDetails.Add(dim);
            }

            foreach (var InvoiceLine in shippment.ShipmentMaster.Line)
            {
                BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail itemDetail = new BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail();
                itemDetail.CGSTAmount = Convert.ToDecimal(InvoiceLine.CGSTAmount_INR);
                itemDetail.HSCode = InvoiceLine.LineHarmonizedCode;
                itemDetail.IGSTAmount = Convert.ToDecimal(InvoiceLine.IGSTAmount_INR);
                itemDetail.InvoiceDate = "/Date(" + ToUnixTimeSeconds(Convert.ToDateTime(shippment.ShipmentMaster.Header.InvoiceDate)) + ")/";
                itemDetail.InvoiceNumber = shippment.ShipmentMaster.Header.InvoiceNumber;
                itemDetail.ItemID = InvoiceLine.ItemCode;
                itemDetail.ItemName = InvoiceLine.ItemName;
                itemDetail.ItemValue = Convert.ToDecimal(InvoiceLine.InvoiceRatePerUnit);
                itemDetail.Itemquantity = Convert.ToInt32(InvoiceLine.quantity);
                itemDetail.PlaceofSupply = "";
                itemDetail.ProductDesc1 = InvoiceLine.Description;
                itemDetail.ProductDesc2 = "";
                itemDetail.SGSTAmount = Convert.ToDecimal(InvoiceLine.SGSTAmount_INR);
                itemDetail.SKUNumber = "";
                itemDetail.SellerGSTNNumber = "";
                itemDetail.SellerName = "";
                itemDetail.TaxableAmount = Convert.ToDecimal(InvoiceLine.FinalPrice_INR);
                itemDetail.countryOfOrigin = "";
                itemDetail.cessAmount = InvoiceLine.CESSAmount_INR.ToString();
                ItemDetailsData.Add(itemDetail);
            }

            var ShipperOrginAreaCode = shippment.ShipmentMaster.Header.OriginArea;
            var ShipperCustomerCode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(ShipperOrginAreaCode.ToLower())).First().Value;

            FinalData = new BlueDartWaybillMasterRequest.BlueDartRequestRootobject
            {
                Request = new BlueDartWaybillMasterRequest.BlueDartWaybillRequest
                {
                    Consignee = new BlueDartWaybillMasterRequest.BlueDartWaybillConsignee
                    {
                        AvailableDays = "",
                        AvailableTiming = "",
                        ConsigneeAddress1 = shippment.ShipmentMaster.Header.DropAddressFirst.ToString(),
                        ConsigneeAddress2 = shippment.ShipmentMaster.Header.DropAddressSecond.ToString(),
                        ConsigneeAddress3 = shippment.ShipmentMaster.Header.DropAddressThird.ToString(),
                        ConsigneeAddressType = "",
                        ConsigneeAddressinfo = "",
                        ConsigneeAttention = "",
                        ConsigneeEmailID = shippment.ShipmentMaster.Header.DropPersonEmail,
                        ConsigneeFullAddress = shippment.ShipmentMaster.Header.DropAddressFirst.ToString(),
                        ConsigneeGSTNumber = "",
                        ConsigneeLatitude = "",
                        ConsigneeLongitude = "",
                        ConsigneeMaskedContactNumber = "",
                        ConsigneeMobile = shippment.ShipmentMaster.Header.DropPhoneNumber,
                        ConsigneeName = shippment.ShipmentMaster.Header.DropPersonName,
                        ConsigneePincode = shippment.ShipmentMaster.Header.DropPostalCode,
                        ConsigneeTelephone = "",
                    },
                    Returnadds = new BlueDartWaybillMasterRequest.BlueDartWaybillReturnadds
                    {
                        ManifestNumber = "",
                        ReturnAddress1 = "",
                        ReturnAddress2 = "",
                        ReturnAddress3 = "",
                        ReturnAddressinfo = "",
                        ReturnContact = finalAgentMaster.GetAccountMasters[0].Name,
                        ReturnEmailID = finalAgentMaster.GetAccountMasters[0].Email,
                        ReturnLatitude = finalAgentMaster.GetAccountMasters[0].Latitude,
                        ReturnLongitude = finalAgentMaster.GetAccountMasters[0].Longitude,
                        ReturnMaskedContactNumber = "",
                        ReturnMobile = finalAgentMaster.GetAccountMasters[0].MobileNo,
                        ReturnPincode = finalAgentMaster.GetAccountMasters[0].PostalCode,
                        ReturnTelephone = finalAgentMaster.GetAccountMasters[0].TelephoneNo
                    },
                    Services = new BlueDartWaybillMasterRequest.BlueDartWaybillServices
                    {
                        AWBNo = "",
                        ActualWeight = shippment.ShipmentMaster.Header.GrossWeight.ToString(),
                        CollectableAmount = Convert.ToDecimal(shippment.ShipmentMaster.Header.CodCollectableAmount),
                        Commodity = Commodity,
                        CreditReferenceNo = shippment.ShipmentMaster.Header.CustomerRefrence.ToString().Replace("/", "---"),
                        CreditReferenceNo2 = "",
                        CreditReferenceNo3 = "",
                        DeclaredValue = Convert.ToDecimal(shippment.ShipmentMaster.Header.TotalDutiableDeclaredvalue),
                        DeliveryTimeSlot = "",
                        Dimensions = DimensionsDetails,
                        FavouringName = "",
                        IsDedicatedDeliveryNetwork = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsDedicatedDeliveryNetwork").ToLower())).First().Value),
                        IsDutyTaxPaidByShipper = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsDutyTaxPaidByShipper").ToLower())).First().Value),
                        IsForcePickup = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsForcePickup").ToLower())).First().Value),
                        IsPartialPickup = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsPartialPickup").ToLower())).First().Value),
                        IsReversePickup = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsReversePickup").ToLower())).First().Value),
                        ItemCount = shippment.ShipmentMaster.Line.Count,
                        Officecutofftime = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("Officecutofftime").ToLower())).First().Value,
                        PDFOutputNotRequired = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PDFOutputNotRequired").ToLower())).First().Value),
                        PackType = "",
                        ParcelShopCode = "",
                        PayableAt = "",
                        PickupDate = "/Date(" + ToUnixTimeSeconds(Convert.ToDateTime(shippment.ShipmentMaster.Header.PickupDate.ToString())).ToString() + ")/",
                        PickupMode = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupMode").ToLower())).First().Value,
                        PickupTime = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupTime").ToLower())).First().Value,
                        PickupType = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PickupType").ToLower())).First().Value,
                        PieceCount = shippment.ShipmentMaster.Line.Count.ToString(),


                        PreferredPickupTimeSlot = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("PreferredPickupTimeSlot").ToLower())).First().Value,
                        ProductCode = shippment.ShipmentMaster.Header.ProductCode,
                        SubProductCode = shippment.ShipmentMaster.Header.SubProductCode,
                        ProductFeature = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ProductFeature").ToLower())).First().Value,
                        ProductType = Convert.ToInt32(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("ProductType").ToLower())).First().Value),
                        RegisterPickup = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("RegisterPickup").ToLower())).First().Value),
                        SpecialInstruction = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("SpecialInstruction").ToLower())).First().Value,

                        TotalCashPaytoCustomer = Convert.ToInt32(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("TotalCashPaytoCustomer").ToLower())).First().Value),
                        itemdtl = ItemDetailsData,
                        noOfDCGiven = Convert.ToInt32(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("noOfDCGiven").ToLower())).First().Value)
                    },
                    Shipper = new BlueDartWaybillMasterRequest.BlueDartWaybillShipper
                    {
                        CustomerAddress1 = finalAgentMaster.GetAccountMasters[0].AddressFirst,
                        CustomerAddress2 = finalAgentMaster.GetAccountMasters[0].AddressSecond,
                        CustomerAddress3 = finalAgentMaster.GetAccountMasters[0].AddressThird,
                        CustomerAddressinfo = "",
                        CustomerBusinessPartyTypeCode = "",
                        CustomerCode = ShipperCustomerCode,
                        CustomerEmailID = finalAgentMaster.GetAccountMasters[0].Email,
                        CustomerGSTNumber = finalAgentMaster.GetAccountMasters[0].GSTNumber,
                        CustomerLatitude = finalAgentMaster.GetAccountMasters[0].Latitude,
                        CustomerLongitude = finalAgentMaster.GetAccountMasters[0].Longitude,
                        CustomerMaskedContactNumber = "",
                        CustomerMobile = finalAgentMaster.GetAccountMasters[0].MobileNo,
                        CustomerName = finalAgentMaster.GetAccountMasters[0].Name == "" ? finalAgentMaster.GetAccountMasters[0].CompanyName : finalAgentMaster.GetAccountMasters[0].Name,
                        CustomerPincode = finalAgentMaster.GetAccountMasters[0].PostalCode,
                        CustomerTelephone = finalAgentMaster.GetAccountMasters[0].TelephoneNo,
                        IsToPayCustomer = Convert.ToBoolean(finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("IsToPayCustomer").ToLower())).First().Value),
                        OriginArea = ShipperOrginAreaCode,
                        Sender = finalAgentMaster.GetAccountMasters[0].Name == "" ?
                                        finalAgentMaster.GetAccountMasters[0].CompanyName :
                                        finalAgentMaster.GetAccountMasters[0].Name,
                        VendorCode = ""
                    },
                },
                Profile = new BlueDartWaybillMasterRequest.BlueDartWaybillProfile
                {
                    Api_type = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("Api_type").ToLower())).First().Value,
                    LicenceKey = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LicenceKey").ToLower())).First().Value,
                    LoginID = finalAgentMaster.GetAgentDetails.Where(x => x.Key.ToLower().Equals(Convert.ToString("LoginID").ToLower())).First().Value
                }

            };
            Result = Newtonsoft.Json.JsonConvert.SerializeObject(FinalData);
            return Result;
        }

        public static string GetBluedartRequestTestData(bool Livestatus, FinalAgentMaster finalAgentMaster, ShippmentRootobject shippment)
        {
            string Result = "";
            string TimeStamp = ToUnixTimeSeconds(DateTime.Now).ToString();
            BlueDartWaybillMasterRequest.BlueDartRequestRootobject FinalData = new BlueDartWaybillMasterRequest.BlueDartRequestRootobject();

            var Commodity = new BlueDartWaybillMasterRequest.BlueDartWaybillCommodity()
            {
                CommodityDetail1 = "Test1",
                CommodityDetail2 = "Test1",
                CommodityDetail3 = "Test1"
            };

            List<BlueDartWaybillMasterRequest.BlueDartWaybillDimension> Dimensions = new List<BlueDartWaybillMasterRequest.BlueDartWaybillDimension>();

            BlueDartWaybillMasterRequest.BlueDartWaybillDimension dimen = new BlueDartWaybillMasterRequest.BlueDartWaybillDimension();
            dimen.Breadth = Convert.ToDecimal("32.7");
            dimen.Count = 1;
            dimen.Height = Convert.ToDecimal("3.2");
            dimen.Length = Convert.ToDecimal("28.9");
            Dimensions.Add(dimen);


            List<BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail> itemdtl = new List<BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail>();

            BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail Item = new BlueDartWaybillMasterRequest.BlueDartWaybillItemDetail();
            Item.CGSTAmount = 0;
            Item.HSCode = "";
            Item.IGSTAmount = 0;
            Item.Instruction = "";
            Item.InvoiceDate = "/Date(" + TimeStamp + ")/";
            Item.InvoiceNumber = "JR/100/1001";
            Item.ItemID = "Test101";
            Item.ItemName = "Test";
            Item.ItemValue = 100;
            Item.Itemquantity = 1;
            Item.PlaceofSupply = "";
            Item.ProductDesc1 = "";
            Item.ProductDesc2 = "";
            Item.ReturnReason = "";
            Item.SGSTAmount = 0;
            Item.SKUNumber = "";
            Item.SellerGSTNNumber = "";
            Item.SellerName = "";
            Item.SubProduct1 = "Test";
            Item.SubProduct2 = "Test";
            Item.TaxableAmount = 0;
            Item.TotalValue = 100;
            Item.cessAmount = "0.0";
            Item.countryOfOrigin = "";
            Item.docType = "";
            Item.subSupplyType = 0;
            Item.supplyType = "";
            itemdtl.Add(Item);

            FinalData = new BlueDartWaybillMasterRequest.BlueDartRequestRootobject
            {
                Request = new BlueDartWaybillMasterRequest.BlueDartWaybillRequest
                {
                    Consignee = new BlueDartWaybillMasterRequest.BlueDartWaybillConsignee
                    {
                        AvailableDays = "",
                        AvailableTiming = "",
                        ConsigneeAddress1 = "Test",
                        ConsigneeAddress2 = "Test",
                        ConsigneeAddress3 = "Test",
                        ConsigneeAddressType = "",
                        ConsigneeAddressinfo = "",
                        ConsigneeAttention = "ABCD",
                        ConsigneeEmailID = "laltesh.s@pixxeldigital.com",
                        ConsigneeFullAddress = "",
                        ConsigneeGSTNumber = "",
                        ConsigneeLatitude = "",
                        ConsigneeLongitude = "",
                        ConsigneeMaskedContactNumber = "",
                        ConsigneeMobile = "9983047618",
                        ConsigneeName = "Test",
                        ConsigneePincode = "110027",
                        ConsigneeTelephone = ""

                    },
                    Returnadds = new BlueDartWaybillMasterRequest.BlueDartWaybillReturnadds
                    {
                        ManifestNumber = "",
                        ReturnAddress1 = "Test",
                        ReturnAddress2 = "Test",
                        ReturnAddress3 = "Test",
                        ReturnAddressinfo = "",
                        ReturnContact = "Test",
                        ReturnEmailID = "testemail@bluedart.com",
                        ReturnLatitude = "",
                        ReturnLongitude = "",
                        ReturnMaskedContactNumber = "",
                        ReturnMobile = "9983047618",
                        ReturnPincode = "400057",
                        ReturnTelephone = ""
                    },
                    Services = new BlueDartWaybillMasterRequest.BlueDartWaybillServices
                    {
                        AWBNo = "",
                        ActualWeight = "0.50",
                        CollectableAmount = 0,
                        Commodity = Commodity,
                        CreditReferenceNo = shippment.ShipmentMaster.Header.CustomerRefrence.ToString().Replace("/", "-"),
                        CreditReferenceNo2 = "",
                        CreditReferenceNo3 = "",
                        DeclaredValue = 100,
                        DeliveryTimeSlot = "",
                        Dimensions = Dimensions,
                        FavouringName = "",
                        IsDedicatedDeliveryNetwork = false,
                        IsDutyTaxPaidByShipper = false,
                        IsForcePickup = false,
                        IsPartialPickup = false,
                        IsReversePickup = false,
                        ItemCount = 1,
                        Officecutofftime = "",
                        PDFOutputNotRequired = false,
                        PackType = "",
                        ParcelShopCode = "",
                        PayableAt = "",
                        PickupDate = "/Date(" + TimeStamp + ")/",
                        PickupMode = "",
                        PickupTime = "1600",
                        PickupType = "",
                        PieceCount = "1",
                        PreferredPickupTimeSlot = "",
                        ProductCode = "A",
                        ProductFeature = "",
                        ProductType = 1,
                        RegisterPickup = true,
                        SpecialInstruction = "",
                        SubProductCode = "P",
                        TotalCashPaytoCustomer = 0,
                        itemdtl = itemdtl,
                        noOfDCGiven = 0
                    },
                    Shipper = new BlueDartWaybillMasterRequest.BlueDartWaybillShipper
                    {
                        CustomerAddress1 = "Test",
                        CustomerAddress2 = "Test",
                        CustomerAddress3 = "Test",
                        CustomerAddressinfo = "",
                        CustomerBusinessPartyTypeCode = "",
                        CustomerCode = "940111",
                        CustomerEmailID = "TestCustEmail@bd.com",
                        CustomerGSTNumber = "",
                        CustomerLatitude = "",
                        CustomerLongitude = "",
                        CustomerMaskedContactNumber = "",
                        CustomerMobile = "9983047618",
                        CustomerName = "Test",
                        CustomerPincode = "122002",
                        CustomerTelephone = "",
                        IsToPayCustomer = false,
                        OriginArea = "GGN",
                        Sender = "TestJPR11",
                        VendorCode = ""
                    },
                },
                Profile = new BlueDartWaybillMasterRequest.BlueDartWaybillProfile
                {
                    Api_type = "S",
                    LicenceKey = "kh7mnhqkmgegoksipxr0urmqesesseup",
                    LoginID = "GG940111"
                }

            };
            Result = Newtonsoft.Json.JsonConvert.SerializeObject(FinalData);
            return Result;
        }
    }
}
