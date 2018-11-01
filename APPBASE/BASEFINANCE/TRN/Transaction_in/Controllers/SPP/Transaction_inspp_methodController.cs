using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcbiz;


namespace APPBASE.Controllers
{
    public partial class Transaction_insppController : Transaction_inController
    {
        protected byte? getMonthTo(int pnMonthFrom, int pnQty){
            byte? vReturn = null;
            int nQty = pnQty;
            int nMonth = pnMonthFrom;

            vReturn = (byte)((nMonth + nQty) - 1);
            return vReturn;
        }
        protected void setMonth()
        {
            //Set Month
            if (this.oData.DETAIL != null)
            {
                this.oData.MONTH1 = (byte)this.oData.DETAIL[0].TRND_ITEMID;
                this.oData.MONTH2 = getMonthTo((int)this.oData.DETAIL[0].TRND_QTY, (int)this.oData.MONTH1);
            } //End if
            if (this.oData.MONTH2 == null) this.oData.MONTH2 = this.oData.MONTH1;
            this.oData.MONTHS = this.oDSMonth.getDatalist_lookup();
            this.oData.MONTH1_SHORTDESC = this.oData.MONTHS.Where(fld => fld.ID == this.oData.MONTH1).SingleOrDefault().MONTH_SHORTDESC;
            this.oData.MONTH2_SHORTDESC = this.oData.MONTHS.Where(fld => fld.ID == this.oData.MONTH2).SingleOrDefault().MONTH_SHORTDESC;
        }
    } //End Controller
} //End namespace
