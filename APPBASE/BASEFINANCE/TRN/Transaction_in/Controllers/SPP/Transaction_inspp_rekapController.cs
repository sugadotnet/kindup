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
        public ActionResult Rekap()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            Transaction_indetailVM oData = new Transaction_indetailVM();
            oData.DETAIL = new List<Transaction_inddetailVM>();
            oData.YEAR_ID = oDSYear.getData_currentYear().ID;

            this.prepareLookupFilter();
            return View(oData);
        }
        [HttpPost]
        public ActionResult Rekap(Transaction_indetailVM poViewModel)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            this.oData = poViewModel;
            if (this.oData == null)
            {
                this.oData = new Transaction_indetailVM();
                this.oData.YEAR_ID = this.oDSYear.getData_currentYearID();
            }
            var oData_year = this.oDSYear.getData(this.oData.YEAR_ID);
            this.oData.YEAR_DESC = oData_year.YEAR_DESC;
            this.oData.YEAR_FROM = oData_year.YEAR_FROM;
            this.oData.YEAR_TO = oData_year.YEAR_TO;


            this.oData.DETAIL = oDSDetail.getDatalist_report(
                1, //SPP (1)
                this.oData.YEAR_ID, this.oData.TRN_DT,
                this.oData.CLASSTYPE_ID, this.oData.CLASSROOM_ID);
            this.oData.TRN_AMOUNT = 0;
            if (this.oData.DETAIL != null) this.oData.TRN_AMOUNT = this.oData.DETAIL.Sum(fld => fld.TRND_AMOUNT);
            this.prepareLookupFilter();
            return View(oData);
        }
    } //End Controller
} //End namespace
