using System;
using System.Collections.Generic;
using System.Linq;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Transaction_insppBL : Transaction_inBL
    {
        protected override Boolean setDETAIL() {
            this._DETAIL_result.DTA_STS = null;
            this._DETAIL_result.TRND_METHODID = 2; //Cash/Cicilan(Reguler)  
            this._DETAIL_result.TRND_TYPEID = this._HEADER_result.TRINTYPE_ID; //Uang Pangkal / Pendaftaran
            this._DETAIL_result.TRND_SUBTYPEID = null;
            this._DETAIL_result.TRND_ITEMTYPEID = null;
            this._DETAIL_result.TRND_ITEMID = null;
            //Actual
            this._DETAIL_result.TRND_QTY = 1;
            this._DETAIL_result.TRND_PRICE = this._HEADER_result.TRN_AMOUNT;
            this._DETAIL_result.TRND_AMOUNT = this._HEADER_result.TRN_AMOUNT;
            //Base
            this._DETAIL_result.TRND_PRICEBASE = this._HEADER_result.TRND_PRICEBASE;
            this._DETAIL_result.TRND_QTYBASE = this._HEADER_result.TRND_QTYBASE;
            this._DETAIL_result.TRND_AMOUNTBASE = this._HEADER_result.TRND_AMOUNTBASE;

            if (this._DETAIL_result.TRND_QTYBASE == null)
                this._DETAIL_result.TRND_QTYBASE = 1;
            if (this._DETAIL_result.TRND_PRICEBASE == null)
                this._DETAIL_result.TRND_PRICEBASE = this._DETAIL_result.TRND_PRICE;
            if (this._DETAIL_result.TRND_AMOUNTBASE == null)
                this._DETAIL_result.TRND_AMOUNTBASE = this._DETAIL_result.TRND_AMOUNT;

            this._DETAIL_result.TRND_DESC = this._HEADER_result.TRN_DESC;
            this._DETAIL_result.TRN_ID = this._HEADER_result.ID;
            this._DETAIL_result.INSTD_ID = this._HEADER_inst_result.ID;
            this._DETAIL_result.INSTD_SEQNO = this._HEADER_inst_result.INSTD_SEQNO;

            //Set Bulang SPP
            if (this._HEADER_data.MONTH1 == null) this._HEADER_data.MONTH1 = 1;
            if (this._HEADER_data.MONTH2 == null) this._HEADER_data.MONTH2 = this._HEADER_data.MONTH1;
            if (this._HEADER_data.MONTH2 == 0) this._HEADER_data.MONTH2 = this._HEADER_data.MONTH1;
            this._DETAIL_result.TRND_ITEMID = this._HEADER_data.MONTH1;
            this._DETAIL_result.TRND_QTY = (this._HEADER_data.MONTH2 - this._HEADER_data.MONTH1) + 1;

            this._DETAIL_resultlist.Add(this._DETAIL_result);
            //Return
            return true;
        } //End Method

        protected virtual Boolean setDETAIL_afterSaveHEADER_INST() {
            
            //Return
            return true;
        } //End method
    } //End Method
} //End namespace APPBASE.Models
