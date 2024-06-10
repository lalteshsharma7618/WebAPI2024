namespace WEB_API_2024.APISetting.ShipmentSetting.ShipmentAgent.DHL.ShippmentCharge.Response
{
    public class DHLResponse
    {
        public class DHL_ChargeResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public double ShippingCharge { get; set; }
            public double TotalTaxAmount { get; set; }
            public string currency { get; set; }

        }



        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [Serializable()]
        [System.ComponentModel.DesignerCategory("code")]
        [System.Xml.Serialization.XmlType(AnonymousType = true)]
        [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
        public partial class Details
        {

            private double shippingChargeField;

            private double totalTaxAmountField;

            private string conditionDataField;


            /// <remarks/>
            public double ShippingCharge
            {
                get
                {
                    return shippingChargeField;
                }
                set
                {
                    shippingChargeField = value;
                }
            }

            /// <remarks/>
            public double TotalTaxAmount
            {
                get
                {
                    return totalTaxAmountField;
                }
                set
                {
                    totalTaxAmountField = value;
                }
            }          
            /// <remarks/>
            public string ConditionData
            {
                get
                {
                    return this.conditionDataField;
                }
                set
                {
                    this.conditionDataField = value;
                }
            }
        }


      


    }
}
