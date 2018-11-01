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
using Omu.ValueInjecter;

namespace APPBASE.Controllers
{
    public partial class Transaction_insppController : Transaction_inController
    {
        public ActionResult Tunggakan()
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_INDEX;
            this.prepareLookupFilter();
            this.oDatapayment = new PaymentVM();
            this.oDatapayment.MONTHLY_LIST = new List<Monthly_paymentVM>();
            return View(this.oDatapayment);
        } //End Action
        [HttpPost]
        public ActionResult Tunggakan(PaymentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_INDEX;

            StudentVM oViewModel_student = new StudentVM();
            oViewModel_student.InjectFrom(poViewModel);

            //STUDENTS
            var Data_students = oDSStudent.getDatalist_aktif2(oViewModel_student);
            //MONTHS
            var Data_months = oDSMonth.getDatalist();
            //TRANSACTIONS
            var Data_transactions = oDSDetail.getDatalist_byFilter(oViewModel_student);
            //PAYMENT
            this.oDSSpp_payment = new Spp_paymentDS(this.db, Data_students, Data_months, Data_transactions);
            this.oDatapayment = new PaymentVM();
            this.oDatapayment.MONTHLY_LIST = oDSSpp_payment.getdatalist();
            //YEAR
            var oYear = this.oDSYear.getData(poViewModel.FILTER_YEAR_ID);
            this.oDatapayment.FILTER_YEAR_ID = oYear.ID;
            this.oDatapayment.FILTER_YEAR_DESC = oYear.YEAR_DESC;
            //CLASSTYPE
            if (poViewModel.FILTER_CLASSTYPE_ID != null) {
                var oClasstype = this.oDSClasstype.getData(poViewModel.FILTER_CLASSTYPE_ID);
                this.oDatapayment.FILTER_CLASSTYPE_ID = (byte)oClasstype.ID;
                this.oDatapayment.FILTER_CLASSTYPE_NAME = oClasstype.CLASSTYPE_NAME;
            } //end if
            //CLASSROOM
            if (poViewModel.FILTER_CLASSROOM_ID != null) {
                var oClassroom = this.oDSClassroom.getData(poViewModel.FILTER_CLASSROOM_ID);
                this.oDatapayment.FILTER_CLASSROOM_ID = (byte)oClassroom.ID;
                this.oDatapayment.FILTER_CLASSROOM_NAME = oClassroom.CLASSROOM_NAME;
            } //end if

            this.prepareLookupFilter();
            return View(this.oDatapayment);
        } //End Action
    } //End Controller
} //End namespace
