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
        protected override Boolean _Create(int? id = null, int? id2 = null)
        {
            base._Create(id, id2);
            //Get history pembayaran
            this.oData.HIST = this.oDSDetail.getDatalist_detail(this.oData.STUDENT_ID, 1, this.oData_year.YEAR_FROM, this.oData_year.YEAR_TO);
            //Return
            this.prepareLookup();
            return true;
        } //End method
        public override ActionResult Create(int? id = null, int? id2 = null)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_CREATE;
            this._Create(id, id2);
            return View(this.oData);
        } //End Action
        protected override Boolean _Create_post(Transaction_indetailVM poViewModel)
        {

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
                this.oData.TRINTYPE_ID = 1; //Set hardcode jenis transaksi SPP(1)
                this.oData.TRN_STS = 1; //Open (Create operation)
                //Siapkan variable Student, Year from dan year to
                //Initial Student
                if (this._setData_student(this.oData.STUDENT_ID) == false) return false;
                //Initial Tahun
                if (this._setData_year(this.oData.YEAR_ID) == false) return false;

                //BL-CRUD=> Inject dependency
                this.oBL_trn.CRUD = this.oCRUD;
                this.oBL_trn.CRUD_detail = this.oCRUD_detail;
                this.oBL_trn.CRUD_inst = this.oCRUD_inst;
                //BL-DATA=> Inject dependency
                this.oBL_trn.HEADER_data = this.oData;
                this.oBL_trn.HEADER_inst_data = this.oDS_inst.getData(
                                                this.oData.STUDENT_ID, this.oData.TRINTYPE_ID,
                                                this.oData.YEAR_FROM, this.oData.YEAR_TO);
                this.oBL_trn.DETAIL_datalist = this.oDSDetail.getDatalist_detail(
                                                this.oData.STUDENT_ID, this.oData.TRINTYPE_ID,
                                                this.oData.YEAR_FROM, this.oData.YEAR_TO);
                //BL-LOOKUP=> Inject dependency (Optional)
                this.oBL_trn.MONTH_lookuplist = this.oDSMonth.getDatalist_lookup();

                //BL-RESULT=> Inject dependency
                this.oBL_trn.HEADER_result = new Transaction_indetailVM();
                this.oBL_trn.DETAIL_result = new Transaction_inddetailVM();
                this.oBL_trn.DETAIL_resultlist = new List<Transaction_inddetailVM>();
                this.oBL_trn.HEADER_inst_result = new Installment_indetailVM();
                //BL-MAIN
                this.oBL_trn.Init();
                this.oBL_trn.Process();
                this.oBL_trn.Save();
                if (this.oBL_trn.RESULT == true) this.oBL_trn.Commit();
                else this.oBL_trn.Rollback();



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
        public override ActionResult Create(Transaction_indetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_CREATE;
            if (this._Create_post(poViewModel))
            {
                //return RedirectToAction("Details", new { id = this.oCRUD.ID });
                //return RedirectToAction("Index");
                return RedirectToAction("Create", new { id = poViewModel.STUDENT_ID, id2 = poViewModel.YEAR_ID });
            } //End if

            //Return
            return View(poViewModel);
        } //End Action
    } //End Controller
} //End namespace
