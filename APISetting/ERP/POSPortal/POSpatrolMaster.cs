namespace WEB_API_2024.APISetting.ERP.POSPortal
{
    public class POSpatrolMaster
    {

        public class POS_Rootobject
        {
            public List<POS_Transaction> Transactions { get; set; }
            public List<POS_Itemdetail> ItemDetail { get; set; }
            public List<POS_Paymentdetail> PaymentDetail { get; set; }
        }

        public class POS_Transaction
        {
            public string LOCATION_CODE { get; set; }
            public string TERMINAL_ID { get; set; }
            public string SHIFT_NO { get; set; }
            public string RCPT_NUM { get; set; }
            public string RCPT_DT { get; set; }
            public string BUSINESS_DT { get; set; }
            public string RCPT_TM { get; set; }
            public string INV_AMT { get; set; }
            public string TAX_AMT { get; set; }
            public string RET_AMT { get; set; }
            public string TRAN_STATUS { get; set; }
            public string OP_CUR { get; set; }
            public string BC_EXCH { get; set; }
            public string DISCOUNT { get; set; }
        }

        public class POS_Itemdetail
        {
            public string REC_TYPE { get; set; }
            public string RCPT_NUM { get; set; }
            public string RCPT_DT { get; set; }
            public string ITEM_CODE { get; set; }
            public string ITEM_NAME { get; set; }
            public string ITEM_QTY { get; set; }
            public string ITEM_PRICE { get; set; }
            public string ITEM_CAT { get; set; }
            public string ITEM_TAX { get; set; }
            public string ITEM_TAX_TYPE { get; set; }
            public string ITEM_NET_AMT { get; set; }
            public string OP_CUR { get; set; }
            public string BC_EXCH { get; set; }
            public string ITEM_STATUS { get; set; }
            public string ITEM_DISCOUNT { get; set; }
        }

        public class POS_Paymentdetail
        {
            public string RCPT_NUM { get; set; }
            public string RCPT_DT { get; set; }
            public string PAYMENT_NAME { get; set; }
            public string CURRENCY_CODE { get; set; }
            public string EXCHANGE_RATE { get; set; }
            public string TENDER_AMOUNT { get; set; }
            public string OP_CUR { get; set; }
            public string BC_EXCH { get; set; }
            public string PAYMENT_STATUS { get; set; }
        }

    }
}
