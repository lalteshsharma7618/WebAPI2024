using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_2024.Models.Database.ERP.View
{
    [Table("NAVPosPortalData", Schema = "ERP")]
    public class NAVPosPortalData
    {
        public int id { get; set; }
        public string LOCATION_CODE { get; set; }
        public string TERMINAL_ID { get; set; }
        public string SHIFT_NO { get; set; }
        public string RCPT_NUM { get; set; }
        public DateTime RCPT_DT { get; set; }
        public DateTime BUSINESS_DT { get; set; }
        public string RCPT_TM { get; set; }
        public decimal INV_AMT { get; set; }
        public decimal TAX_AMT { get; set; }
        public decimal RET_AMT { get; set; }
        public string TRAN_STATUS { get; set; }
        public string OP_CUR { get; set; }
        public decimal BC_EXCH { get; set; }
        public decimal DISCOUNT { get; set; }

        public string REC_TYPE { get; set; }
        //public string RCPT_NUM { get; set; }
        //public string RCPT_DT { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public decimal ITEM_QTY { get; set; }
        public decimal ITEM_PRICE { get; set; }
        public string ITEM_CAT { get; set; }
        public decimal ITEM_TAX { get; set; }
        public string ITEM_TAX_TYPE { get; set; }
        public decimal ITEM_NET_AMT { get; set; }
        //public string OP_CUR { get; set; }
        //public string BC_EXCH { get; set; }
        public string ITEM_STATUS { get; set; }
        public decimal ITEM_DISCOUNT { get; set; }

        //public string RCPT_NUM { get; set; }
        //public string RCPT_DT { get; set; }
        public string PAYMENT_NAME { get; set; }
        public string CURRENCY_CODE { get; set; }
        public decimal EXCHANGE_RATE { get; set; }
        public decimal TENDER_AMOUNT { get; set; }
        //public string OP_CUR { get; set; }
        //public string BC_EXCH { get; set; }
        public string PAYMENT_STATUS { get; set; }
    }
}
