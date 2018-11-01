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
using APPBASE.Svcapp;

namespace APPBASE.Controllers
{
    public partial class Transaction_inController : Controller
    {
        protected virtual Boolean _Index_post(StudentVM poViewModel)
        {
            this.oDatastudent = poViewModel;
            this.oDatastudent.DETAIL = new StudentdetailVM();
            this.oDatastudent.DETAIL.CLASSTYPE_ID = this.oDatastudent.FILTER_CLASSTYPE_ID;
            this.oDatastudent.DETAIL.CLASSROOM_ID = this.oDatastudent.FILTER_CLASSROOM_ID;
            this.oDatastudent.DETAIL.YEAR_ID = this.oDatastudent.FILTER_YEAR_ID;
            this.oDatastudent.DETAIL.STUDENTSTS_ID = 4; //Calon Siswa
            ViewBag.STUDENT = oDSStudent.getDatalist_filter(this.oDatastudent.DETAIL);
            
            this.prepareLookupFilter();
            //Return
            return true;
        } //End Method
        [HttpPost]
        public virtual ActionResult Index(StudentVM poViewModel)
        {
            //ViewBag.STUDENTS = oDSStudent.getDatalist_filter(poViewModel);
            //this.prepareLookupFilter();

            this._Index_post(poViewModel);
            return View("~/Views/Transaction_in/Index.cshtml", poViewModel);
        } //End Action
        protected virtual Boolean _Create_post(Transaction_indetailVM poViewModel) {

            Transaction_indetailVM oViewModel = poViewModel;
            oViewModel.TRN_AMOUNT = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRN_AMOUNT_S);

            this.oVAL = new Transaction_in_Validation(oViewModel, oDS);
            this.oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oData = oViewModel;
                //BL-DATA=> Inject dependency
                this.oBL.CRUD = this.oCRUD;
                this.oBL.CRUD_detail = this.oCRUD_detail;
                this.oBL.CRUD_inst = this.oCRUD_inst;
                this.oBL.HEADER_data = this.oData;
                //BL-DATA support (Optional)
                //BL-RESULT=> Inject dependency
                this.oBL.HEADER_result = new Transaction_indetailVM();
                this.oBL.DETAIL_result = new Transaction_inddetailVM();
                this.oBL.DETAIL_resultlist = new List<Transaction_inddetailVM>();
                this.oBL.HEADER_inst_result = new Installment_indetailVM();
                //BL-MAIN
                this.oBL.Init();
                this.oBL.Process();
                this.oBL.Save();
                if (this.oBL.RESULT == true) this.oBL.Commit();
                else this.oBL.Rollback();

                //this.oCRUD.Create(oViewModel);
                //this.oCRUD.Commit();
                if (this.oCRUD.isERR) { return false; } //End if (!this.oCRUD.isERR) {
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return true;
            } //End if (ModelState.IsValid)

            //Return
            return false;
        } //End Method
        [HttpPost]
        public virtual ActionResult Create(Transaction_indetailVM poViewModel)
        {
            if (this._Create_post(poViewModel)) {
                return RedirectToAction("Details", new { id = this.oCRUD.ID });
            } //End if
            //Return
            return View("~/Views/Transaction_in/Create.cshtml", poViewModel);
        } //End Action
    } //End Controller
} //End namespace
