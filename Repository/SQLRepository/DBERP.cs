using WEB_API_2024.Models;
using WEB_API_2024.Models.Database.ERP.View;
using WEB_API_2024.Repository.InterfaceRepository;

namespace WEB_API_2024.Repository.SQLRepository
{
    public class DBERP : IERP
    {
        private readonly DBMaster dBMaster;

        public DBERP(DBMaster dBMaster)
        {
            this.dBMaster = dBMaster;
        }
        public List<NAVPosPortalData> GetNAVPosPortalDatas()
        {
            return dBMaster.NAVPosPortalDatas.Select(x=> new NAVPosPortalData()
            {
                LOCATION_CODE = x.LOCATION_CODE,
                TERMINAL_ID = x.TERMINAL_ID,
                SHIFT_NO = x.SHIFT_NO,
                RCPT_NUM = x.RCPT_NUM,
                RCPT_DT = x.RCPT_DT,
                BUSINESS_DT = x.BUSINESS_DT,
                RCPT_TM = x.RCPT_TM,
                INV_AMT = x.INV_AMT,
                TAX_AMT = x.TAX_AMT,
                RET_AMT = x.RET_AMT,
                TRAN_STATUS = x.TRAN_STATUS,
                OP_CUR = x.OP_CUR,
                BC_EXCH = x.BC_EXCH,
                DISCOUNT = x.DISCOUNT,
                REC_TYPE = x.REC_TYPE,
                ITEM_CODE = x.ITEM_CODE,
                ITEM_NAME = x.ITEM_NAME,
                ITEM_QTY = x.ITEM_QTY,
                ITEM_PRICE = x.ITEM_PRICE,
                ITEM_CAT = x.ITEM_CAT,
                ITEM_TAX = x.ITEM_TAX,
                ITEM_TAX_TYPE = x.ITEM_TAX_TYPE,
                ITEM_NET_AMT = x.ITEM_NET_AMT,
                ITEM_STATUS = x.ITEM_STATUS,
                ITEM_DISCOUNT = x.ITEM_DISCOUNT,
                PAYMENT_NAME = x.PAYMENT_NAME,
                CURRENCY_CODE = x.CURRENCY_CODE,
                EXCHANGE_RATE = x.EXCHANGE_RATE,
                TENDER_AMOUNT = x.TENDER_AMOUNT,
                PAYMENT_STATUS = x.PAYMENT_STATUS

            }).ToList();
        }
    }
}
