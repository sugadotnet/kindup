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
        public override ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_INDEX;
            this._Index();
            return View(this.oDatastudent);
        } //End Action
        [HttpPost]
        public override ActionResult Index(StudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_INDEX;
            this.oDatastudent = poViewModel;
            this._Index_post(this.oDatastudent);
            return View(this.oDatastudent);
        } //End Action
        protected override Boolean _Index_post(StudentVM poViewModel)
        {
            this.oDatastudent = poViewModel;
            this.oDatastudent.DETAIL = new StudentdetailVM();
            this.oDatastudent.DETAIL.CLASSTYPE_ID = this.oDatastudent.FILTER_CLASSTYPE_ID;
            this.oDatastudent.DETAIL.CLASSROOM_ID = this.oDatastudent.FILTER_CLASSROOM_ID;
            this.oDatastudent.DETAIL.YEAR_ID = this.oDatastudent.FILTER_YEAR_ID;
            ViewBag.STUDENT = oDSStudent.getDatalist_filter_active(this.oDatastudent.DETAIL);

            this.prepareLookupFilter();
            //Return
            return true;
        } //End Method
    } //End Controller
} //End namespace
