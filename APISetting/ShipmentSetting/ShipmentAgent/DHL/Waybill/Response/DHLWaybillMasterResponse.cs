using System.Xml.Serialization;

namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.Waybill.Response
{
    public class DHLWaybillMasterResponse
    {

        public class DHLEMR_Response
        {
            public bool success { get; set; }
            public string message { get; set; }
            public string AWBNumber { get; set; }
            public string LabelUrl { get; set; }
        }


        [XmlRoot(ElementName = "ConditionData")]
        public class ConditionData
        {
            [XmlText]
            public string Text { get; set; }
        }




        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true, Namespace = "http://www.dhl.com")]
        [XmlRoot(Namespace = "http://www.dhl.com", IsNullable = false)]
        public partial class ShipmentRecords
        {

            private CustomerInfo customerInfoField;

            private ShipmentRecord shipmentRecordField;

            private int totalField;

            /// <remarks/>
            [XmlElement(Namespace = "")]
            public CustomerInfo CustomerInfo
            {
                get
                {
                    return customerInfoField;
                }
                set
                {
                    customerInfoField = value;
                }
            }

            /// <remarks/>
            [XmlElement(Namespace = "")]
            public ShipmentRecord ShipmentRecord
            {
                get
                {
                    return shipmentRecordField;
                }
                set
                {
                    shipmentRecordField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public int Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        [XmlRoot(Namespace = "", IsNullable = false)]
        public partial class CustomerInfo
        {

            private string softwareCodeField;

            private string softwareVersionField;

            private string firstAWB1strangeField;

            private string lastAWB1strangeField;

            private string nextAWBField;

            private string defaultAccountNoField;

            private string customerNameField;

            private string easyShipUsernameField;

            private string shipmentsSCLReadyFlagField;

            /// <remarks/>
            public string SoftwareCode
            {
                get
                {
                    return softwareCodeField;
                }
                set
                {
                    softwareCodeField = value;
                }
            }

            /// <remarks/>
            public string SoftwareVersion
            {
                get
                {
                    return softwareVersionField;
                }
                set
                {
                    softwareVersionField = value;
                }
            }

            /// <remarks/>
            public string FirstAWB1strange
            {
                get
                {
                    return firstAWB1strangeField;
                }
                set
                {
                    firstAWB1strangeField = value;
                }
            }

            /// <remarks/>
            public string LastAWB1strange
            {
                get
                {
                    return lastAWB1strangeField;
                }
                set
                {
                    lastAWB1strangeField = value;
                }
            }

            /// <remarks/>
            public string NextAWB
            {
                get
                {
                    return nextAWBField;
                }
                set
                {
                    nextAWBField = value;
                }
            }

            /// <remarks/>
            public string DefaultAccountNo
            {
                get
                {
                    return defaultAccountNoField;
                }
                set
                {
                    defaultAccountNoField = value;
                }
            }

            /// <remarks/>
            public string CustomerName
            {
                get
                {
                    return customerNameField;
                }
                set
                {
                    customerNameField = value;
                }
            }

            /// <remarks/>
            public string EasyShipUsername
            {
                get
                {
                    return easyShipUsernameField;
                }
                set
                {
                    easyShipUsernameField = value;
                }
            }

            /// <remarks/>
            public string ShipmentsSCLReadyFlag
            {
                get
                {
                    return shipmentsSCLReadyFlagField;
                }
                set
                {
                    shipmentsSCLReadyFlagField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        [XmlRoot(Namespace = "", IsNullable = false)]
        public partial class ShipmentRecord
        {

            private ShipmentRecordGeneralInfo generalInfoField;

            private ShipmentRecordShipmentContents shipmentContentsField;

            private ShipmentRecordDHLServices dHLServicesField;

            private ShipmentRecordCustomsInfo customsInfoField;

            private ShipmentRecordShipmentMultipleRefs shipmentMultipleRefsField;

            private ShipmentRecordPieces piecesField;

            private string pDFPathField;

            private string pDFLabelPathField;

            private string invoicePathField;

            private string versionField;

            /// <remarks/>
            public ShipmentRecordGeneralInfo GeneralInfo
            {
                get
                {
                    return generalInfoField;
                }
                set
                {
                    generalInfoField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordShipmentContents ShipmentContents
            {
                get
                {
                    return shipmentContentsField;
                }
                set
                {
                    shipmentContentsField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordDHLServices DHLServices
            {
                get
                {
                    return dHLServicesField;
                }
                set
                {
                    dHLServicesField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordCustomsInfo CustomsInfo
            {
                get
                {
                    return customsInfoField;
                }
                set
                {
                    customsInfoField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordShipmentMultipleRefs ShipmentMultipleRefs
            {
                get
                {
                    return shipmentMultipleRefsField;
                }
                set
                {
                    shipmentMultipleRefsField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordPieces Pieces
            {
                get
                {
                    return piecesField;
                }
                set
                {
                    piecesField = value;
                }
            }

            /// <remarks/>
            public string PDFPath
            {
                get
                {
                    return pDFPathField;
                }
                set
                {
                    pDFPathField = value;
                }
            }

            /// <remarks/>
            public string PDFLabelPath
            {
                get
                {
                    return pDFLabelPathField;
                }
                set
                {
                    pDFLabelPathField = value;
                }
            }

            /// <remarks/>
            public string InvoicePath
            {
                get
                {
                    return invoicePathField;
                }
                set
                {
                    invoicePathField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string Version
            {
                get
                {
                    return versionField;
                }
                set
                {
                    versionField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfo
        {

            private ShipmentRecordGeneralInfoShipment shipmentField;

            private ShipmentRecordGeneralInfoShipper shipperField;

            private ShipmentRecordGeneralInfoReceiver receiverField;

            private ShipmentRecordGeneralInfoAdditionalService additionalServiceField;

            private ShipmentRecordGeneralInfoBilling billingField;

            private ShipmentRecordGeneralInfoRoadBaseSpecific roadBaseSpecificField;

            /// <remarks/>
            public ShipmentRecordGeneralInfoShipment Shipment
            {
                get
                {
                    return shipmentField;
                }
                set
                {
                    shipmentField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordGeneralInfoShipper Shipper
            {
                get
                {
                    return shipperField;
                }
                set
                {
                    shipperField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordGeneralInfoReceiver Receiver
            {
                get
                {
                    return receiverField;
                }
                set
                {
                    receiverField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordGeneralInfoAdditionalService AdditionalService
            {
                get
                {
                    return additionalServiceField;
                }
                set
                {
                    additionalServiceField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordGeneralInfoBilling Billing
            {
                get
                {
                    return billingField;
                }
                set
                {
                    billingField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordGeneralInfoRoadBaseSpecific RoadBaseSpecific
            {
                get
                {
                    return roadBaseSpecificField;
                }
                set
                {
                    roadBaseSpecificField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfoShipment
        {

            private object[] itemsField;

            private ItemsChoiceType[] itemsElementNameField;

            /// <remarks/>
            [XmlElement("ActualTotWgt", typeof(string))]
            [XmlElement("BackEndType", typeof(string))]
            [XmlElement("BillTypeCode", typeof(string))]
            [XmlElement("CashAmount", typeof(string))]
            [XmlElement("CompleteDt", typeof(string))]
            [XmlElement("CompleteTime", typeof(string))]
            [XmlElement("CourPkupDt", typeof(string))]
            [XmlElement("CourPkupTime", typeof(string))]
            [XmlElement("DecimalPlaces", typeof(string))]
            [XmlElement("DefaultCurrency", typeof(string))]
            [XmlElement("DestIATA", typeof(string))]
            [XmlElement("DimWgtFactor", typeof(string))]
            [XmlElement("EnteredDt", typeof(string))]
            [XmlElement("EnteredTime", typeof(string))]
            [XmlElement("GlobalProdCd", typeof(string))]
            [XmlElement("ID", typeof(string))]
            [XmlElement("IsExchangeShipment", typeof(string))]
            [XmlElement("LabelPrinting", typeof(string))]
            [XmlElement("LocalProdCd", typeof(string))]
            [XmlElement("NumOfPallets", typeof(string))]
            [XmlElement("NumOfPieces", typeof(string))]
            [XmlElement("OnePieceOnly", typeof(string))]
            [XmlElement("OrgIATA", typeof(string))]
            [XmlElement("RoundedTotWgt", typeof(string))]
            [XmlElement("ShippingCharge", typeof(string))]
            [XmlElement("TotDecldVal", typeof(string))]
            [XmlElement("TotDimWgt", typeof(string))]
            [XmlChoiceIdentifier("ItemsElementName")]
            public object[] Items
            {
                get
                {
                    return itemsField;
                }
                set
                {
                    itemsField = value;
                }
            }

            /// <remarks/>
            [XmlElement("ItemsElementName")]
            [XmlIgnore()]
            public ItemsChoiceType[] ItemsElementName
            {
                get
                {
                    return itemsElementNameField;
                }
                set
                {
                    itemsElementNameField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [XmlType(IncludeInSchema = false)]
        public enum ItemsChoiceType
        {

            /// <remarks/>
            ActualTotWgt,

            /// <remarks/>
            BackEndType,

            /// <remarks/>
            BillTypeCode,

            /// <remarks/>
            CashAmount,

            /// <remarks/>
            CompleteDt,

            /// <remarks/>
            CompleteTime,

            /// <remarks/>
            CourPkupDt,

            /// <remarks/>
            CourPkupTime,

            /// <remarks/>
            DecimalPlaces,

            /// <remarks/>
            DefaultCurrency,

            /// <remarks/>
            DestIATA,

            /// <remarks/>
            DimWgtFactor,

            /// <remarks/>
            EnteredDt,

            /// <remarks/>
            EnteredTime,

            /// <remarks/>
            GlobalProdCd,

            /// <remarks/>
            ID,

            /// <remarks/>
            IsExchangeShipment,

            /// <remarks/>
            LabelPrinting,

            /// <remarks/>
            LocalProdCd,

            /// <remarks/>
            NumOfPallets,

            /// <remarks/>
            NumOfPieces,

            /// <remarks/>
            OnePieceOnly,

            /// <remarks/>
            OrgIATA,

            /// <remarks/>
            RoundedTotWgt,

            /// <remarks/>
            ShippingCharge,

            /// <remarks/>
            TotDecldVal,

            /// <remarks/>
            TotDimWgt,
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfoShipper
        {

            private string referenceField;

            private string companyNmField;

            private string cityField;

            private string postalCdField;

            private string ctryCdField;

            private string ctryNmField;

            private string cnctNmField;

            private string phNoField;

            private string acctNoField;

            /// <remarks/>
            public string Reference
            {
                get
                {
                    return referenceField;
                }
                set
                {
                    referenceField = value;
                }
            }

            /// <remarks/>
            public string CompanyNm
            {
                get
                {
                    return companyNmField;
                }
                set
                {
                    companyNmField = value;
                }
            }

            /// <remarks/>
            public string City
            {
                get
                {
                    return cityField;
                }
                set
                {
                    cityField = value;
                }
            }

            /// <remarks/>
            public string PostalCd
            {
                get
                {
                    return postalCdField;
                }
                set
                {
                    postalCdField = value;
                }
            }

            /// <remarks/>
            public string CtryCd
            {
                get
                {
                    return ctryCdField;
                }
                set
                {
                    ctryCdField = value;
                }
            }

            /// <remarks/>
            public string CtryNm
            {
                get
                {
                    return ctryNmField;
                }
                set
                {
                    ctryNmField = value;
                }
            }

            /// <remarks/>
            public string CnctNm
            {
                get
                {
                    return cnctNmField;
                }
                set
                {
                    cnctNmField = value;
                }
            }

            /// <remarks/>
            public string PhNo
            {
                get
                {
                    return phNoField;
                }
                set
                {
                    phNoField = value;
                }
            }

            /// <remarks/>
            public string AcctNo
            {
                get
                {
                    return acctNoField;
                }
                set
                {
                    acctNoField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfoReceiver
        {

            private string idField;

            private object acctNoField;

            private string companyNmField;

            private string cityField;

            private string postalCdField;

            private string ctryCdField;

            private string ctryNmField;

            private string cnctNameField;

            private string phNoField;

            /// <remarks/>
            public string ID
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
            public object AcctNo
            {
                get
                {
                    return acctNoField;
                }
                set
                {
                    acctNoField = value;
                }
            }

            /// <remarks/>
            public string CompanyNm
            {
                get
                {
                    return companyNmField;
                }
                set
                {
                    companyNmField = value;
                }
            }

            /// <remarks/>
            public string City
            {
                get
                {
                    return cityField;
                }
                set
                {
                    cityField = value;
                }
            }

            /// <remarks/>
            public string PostalCd
            {
                get
                {
                    return postalCdField;
                }
                set
                {
                    postalCdField = value;
                }
            }

            /// <remarks/>
            public string CtryCd
            {
                get
                {
                    return ctryCdField;
                }
                set
                {
                    ctryCdField = value;
                }
            }

            /// <remarks/>
            public string CtryNm
            {
                get
                {
                    return ctryNmField;
                }
                set
                {
                    ctryNmField = value;
                }
            }

            /// <remarks/>
            public string CnctName
            {
                get
                {
                    return cnctNameField;
                }
                set
                {
                    cnctNameField = value;
                }
            }

            /// <remarks/>
            public string PhNo
            {
                get
                {
                    return phNoField;
                }
                set
                {
                    phNoField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfoAdditionalService
        {

            private string insuredAmtField;

            private string cODValField;

            /// <remarks/>
            public string InsuredAmt
            {
                get
                {
                    return insuredAmtField;
                }
                set
                {
                    insuredAmtField = value;
                }
            }

            /// <remarks/>
            public string CODVal
            {
                get
                {
                    return cODValField;
                }
                set
                {
                    cODValField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfoBilling
        {

            private string thirdPartyBillingField;

            private string invoiceNoField;

            /// <remarks/>
            public string ThirdPartyBilling
            {
                get
                {
                    return thirdPartyBillingField;
                }
                set
                {
                    thirdPartyBillingField = value;
                }
            }

            /// <remarks/>
            public string InvoiceNo
            {
                get
                {
                    return invoiceNoField;
                }
                set
                {
                    invoiceNoField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordGeneralInfoRoadBaseSpecific
        {

            private string scheduleNoField;

            private string dangerousGoodsField;

            /// <remarks/>
            public string ScheduleNo
            {
                get
                {
                    return scheduleNoField;
                }
                set
                {
                    scheduleNoField = value;
                }
            }

            /// <remarks/>
            public string DangerousGoods
            {
                get
                {
                    return dangerousGoodsField;
                }
                set
                {
                    dangerousGoodsField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordShipmentContents
        {

            private string shipmentContentField;

            private string totalField;

            /// <remarks/>
            public string ShipmentContent
            {
                get
                {
                    return shipmentContentField;
                }
                set
                {
                    shipmentContentField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordDHLServices
        {

            private string totalField;

            /// <remarks/>
            [XmlAttribute()]
            public string Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordCustomsInfo
        {

            private string dutiableField;

            private ShipmentRecordCustomsInfoProformaInvoices proformaInvoicesField;

            /// <remarks/>
            public string Dutiable
            {
                get
                {
                    return dutiableField;
                }
                set
                {
                    dutiableField = value;
                }
            }

            /// <remarks/>
            public ShipmentRecordCustomsInfoProformaInvoices ProformaInvoices
            {
                get
                {
                    return proformaInvoicesField;
                }
                set
                {
                    proformaInvoicesField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordCustomsInfoProformaInvoices
        {

            private ShipmentRecordCustomsInfoProformaInvoicesProformaItem proformaItemField;

            private string totalField;

            /// <remarks/>
            public ShipmentRecordCustomsInfoProformaInvoicesProformaItem ProformaItem
            {
                get
                {
                    return proformaItemField;
                }
                set
                {
                    proformaItemField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordCustomsInfoProformaInvoicesProformaItem
        {

            private string qtyField;

            private string wghField;

            private string wghUOMField;

            private string wghDecimalField;

            private string volWghField;

            private string lengthField;

            private string heightField;

            private string widthField;

            private string crncyCdField;

            private string priceDecimalField;

            private string unitPriceField;

            /// <remarks/>
            public string Qty
            {
                get
                {
                    return qtyField;
                }
                set
                {
                    qtyField = value;
                }
            }

            /// <remarks/>
            public string Wgh
            {
                get
                {
                    return wghField;
                }
                set
                {
                    wghField = value;
                }
            }

            /// <remarks/>
            public string WghUOM
            {
                get
                {
                    return wghUOMField;
                }
                set
                {
                    wghUOMField = value;
                }
            }

            /// <remarks/>
            public string WghDecimal
            {
                get
                {
                    return wghDecimalField;
                }
                set
                {
                    wghDecimalField = value;
                }
            }

            /// <remarks/>
            public string VolWgh
            {
                get
                {
                    return volWghField;
                }
                set
                {
                    volWghField = value;
                }
            }

            /// <remarks/>
            public string Length
            {
                get
                {
                    return lengthField;
                }
                set
                {
                    lengthField = value;
                }
            }

            /// <remarks/>
            public string Height
            {
                get
                {
                    return heightField;
                }
                set
                {
                    heightField = value;
                }
            }

            /// <remarks/>
            public string Width
            {
                get
                {
                    return widthField;
                }
                set
                {
                    widthField = value;
                }
            }

            /// <remarks/>
            public string CrncyCd
            {
                get
                {
                    return crncyCdField;
                }
                set
                {
                    crncyCdField = value;
                }
            }

            /// <remarks/>
            public string PriceDecimal
            {
                get
                {
                    return priceDecimalField;
                }
                set
                {
                    priceDecimalField = value;
                }
            }

            /// <remarks/>
            public string UnitPrice
            {
                get
                {
                    return unitPriceField;
                }
                set
                {
                    unitPriceField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordShipmentMultipleRefs
        {

            private string totalField;

            /// <remarks/>
            [XmlAttribute()]
            public string Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordPieces
        {

            private ShipmentRecordPiecesPiece pieceField;

            private string totalField;

            /// <remarks/>
            public ShipmentRecordPiecesPiece Piece
            {
                get
                {
                    return pieceField;
                }
                set
                {
                    pieceField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordPiecesPiece
        {

            private object[] itemsField;

            private ItemsChoiceType1[] itemsElementNameField;

            /// <remarks/>
            [XmlElement("Height", typeof(decimal))]
            [XmlElement("ID", typeof(string))]
            [XmlElement("Length", typeof(decimal))]
            [XmlElement("PckgTyp", typeof(string))]
            [XmlElement("PieceMultipleRefs", typeof(ShipmentRecordPiecesPiecePieceMultipleRefs))]
            [XmlElement("UOM", typeof(string))]
            [XmlElement("VolWgh", typeof(decimal))]
            [XmlElement("Volume", typeof(decimal))]
            [XmlElement("Wgh", typeof(decimal))]
            [XmlElement("Width", typeof(decimal))]
            [XmlChoiceIdentifier("ItemsElementName")]
            public object[] Items
            {
                get
                {
                    return itemsField;
                }
                set
                {
                    itemsField = value;
                }
            }

            /// <remarks/>
            [XmlElement("ItemsElementName")]
            [XmlIgnore()]
            public ItemsChoiceType1[] ItemsElementName
            {
                get
                {
                    return itemsElementNameField;
                }
                set
                {
                    itemsElementNameField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public partial class ShipmentRecordPiecesPiecePieceMultipleRefs
        {

            private string totalField;

            /// <remarks/>
            [XmlAttribute()]
            public string Total
            {
                get
                {
                    return totalField;
                }
                set
                {
                    totalField = value;
                }
            }
        }

        /// <remarks/>
        [Serializable()]
        [XmlType(IncludeInSchema = false)]
        public enum ItemsChoiceType1
        {

            /// <remarks/>
            Height,

            /// <remarks/>
            ID,

            /// <remarks/>
            Length,

            /// <remarks/>
            PckgTyp,

            /// <remarks/>
            PieceMultipleRefs,

            /// <remarks/>
            UOM,

            /// <remarks/>
            VolWgh,

            /// <remarks/>
            Volume,

            /// <remarks/>
            Wgh,

            /// <remarks/>
            Width,
        }
    }
}
