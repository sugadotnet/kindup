using System;
using System.Collections.Generic;
using System.Linq;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public partial class Transaction_inBL
    {
        protected virtual Boolean setHEADER_INST() {
            if (this._HEADER_inst_data == null)
            {
                this._HEADER_inst_result.InjectFrom(this._HEADER_result);
                this._HEADER_inst_result.DTA_STS = 1; //New(Belum pernah ada installment)
                this._HEADER_inst_result.INST_DT = this._HEADER_result.TRN_DT;
                this._HEADER_inst_result.INST_STS = 1; //Open
                this._HEADER_inst_result.INST_STARTDT = this._HEADER_result.TRN_DT;
                //this._HEADER_inst_result.INST_ENDDT = this.HEADER_result.TRN_DT;
                this._HEADER_inst_result.INST_TYPEID = 13; //Uang pangkal
                this._HEADER_inst_result.INST_SUBTYPEID = null; //Sementara kosong

                //Base
                //this._HEADER_inst_result.INST_QTYBASE = this._DETAIL_result.TRND_QTYBASE;
                //this._HEADER_inst_result.INST_PRICEBASE = this._DETAIL_result.TRND_PRICEBASE;
                //this._HEADER_inst_result.INST_AMOUNTBASE = this._DETAIL_result.TRND_AMOUNTBASE;
                //Actual
                //this._HEADER_inst_result.INST_QTY = this._DETAIL_result.TRND_QTYBASE;
                //this._HEADER_inst_result.INST_AMOUNT = 0;
            }
            else {
                this._HEADER_inst_result = this._HEADER_inst_data;
                if (this._HEADER_inst_result.ID != null) {
                    this._HEADER_inst_result.DTA_STS = 2; //UPDATE (Installment sudah pernah ada)
                } //End if
            } //End if
            this._HEADER_inst_result.INST_ENDDT = this._HEADER_result.TRN_DT;

            //Reset calculation - Base
            this._HEADER_inst_result.INST_QTYBASE = 0;
            this._HEADER_inst_result.INST_PRICEBASE = 0;
            this._HEADER_inst_result.INST_AMOUNTBASE = 0;
            //Reset calculation - Actual
            this._HEADER_inst_result.INST_QTY = 0;
            this._HEADER_inst_result.INST_AMOUNT = 0;
            //Return
            return true;
        } //End Method

        protected virtual Boolean calcHEADER_INST() {
            //Calc history pembayaran
            foreach (var item in this._DETAIL_datalist)
            {
                //BASE
                this._HEADER_inst_result.INST_QTYBASE = this._HEADER_inst_result.INST_QTYBASE + 1;
                this._HEADER_inst_result.INST_PRICEBASE = item.TRND_PRICEBASE;
                this._HEADER_inst_result.INST_AMOUNTBASE = this._HEADER_inst_result.INST_AMOUNTBASE + item.TRND_AMOUNTBASE;
                //ACTUAL
                this._HEADER_inst_result.INST_QTY = this._HEADER_inst_result.INST_QTY + 1;
                this._HEADER_inst_result.INST_AMOUNT = this._HEADER_inst_result.INST_AMOUNT + item.TRND_AMOUNT;
            } //End if
            //Calc pembayaran saat ini
            foreach (var item in this._DETAIL_resultlist)
            {
                //BASE
                this._HEADER_inst_result.INST_QTYBASE = this._HEADER_inst_result.INST_QTYBASE + 1;
                this._HEADER_inst_result.INST_PRICEBASE = item.TRND_PRICEBASE;
                this._HEADER_inst_result.INST_AMOUNTBASE = this._HEADER_inst_result.INST_AMOUNTBASE + item.TRND_AMOUNTBASE;
                //ACTUAL
                this._HEADER_inst_result.INST_QTY = this._HEADER_inst_result.INST_QTY + 1;
                this._HEADER_inst_result.INST_AMOUNT = this._HEADER_inst_result.INST_AMOUNT + item.TRND_AMOUNT;
            } //End if
            //Return
            return true;
        } //End method
        protected virtual Boolean statusHEADER_INST() {
            if (this._HEADER_inst_result.INST_AMOUNTBASE == this._HEADER_inst_result.INST_AMOUNT)
                this._HEADER_inst_result.INST_STS = 2; //Closed/lunas
            //Return
            return true;
        } //End method
} //End Method
} //End namespace APPBASE.Models
