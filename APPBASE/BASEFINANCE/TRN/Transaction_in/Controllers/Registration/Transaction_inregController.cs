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
    [MyActionFilterAttribute]
    public partial class Transaction_inregController : Transaction_inController
    {
        //DS
        protected Installment_inDS oDS_inst;
        //OBL
        protected Transaction_inregBL oBL_trn;

        //Init
        protected override void initConstructor(DBMAINContext poDB)
        {
            base.initConstructor(poDB);

            //BL
            this.oBL_trn = new Transaction_inregBL(poDB);
            //DS
            oDS_inst = new Installment_inDS(poDB);
            
            this.oDatastudent.DETAIL.STUDENTSTS_ID = 4; //Calon Siswa
        } //End initConstructor
        //Constructor 1
        public Transaction_inregController(): base()
        {
            //DBContext
            //this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public Transaction_inregController(DBMAINContext poDB): base(poDB)
        {
            //DBContext
            //this.initConstructor(poDB);
        } //End Constructor 2
        //INDEX
        public override ActionResult Index()
        {
            this._Index();
            return View(this.oDatastudent);
        } //End Action
        [HttpPost]
        public override ActionResult Index(StudentVM poViewModel)
        {
            this.oDatastudent = poViewModel;
            this._Index_post(this.oDatastudent);
            return View(this.oDatastudent);
        } //End Action
        //CREATE
        protected virtual Boolean _Create(int? id = null, int? id2 = null)
        {
            base._Create(id, id2);
            //Get history pembayaran
            this.oData.HIST = this.oDSDetail.getDatalist_detail(this.oData.STUDENT_ID, 13, this.oData_year.YEAR_FROM, this.oData_year.YEAR_TO);
            //Return
            return true;
        } //End method
        public override ActionResult Create(int? id = null, int? id2 = null)
        {
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
                this.oData.TRINTYPE_ID = 13; //Set hardcode jenis transaksi Uang pangkal(13)
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
                //this.oBL_reg.DETAIL_datalist = this.ods
                //BL-DATA support (Optional)
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
            if (this._Create_post(poViewModel))
            {
                //return RedirectToAction("Details", new { id = this.oCRUD.ID });
                //return RedirectToAction("Index");
                return RedirectToAction("Create", new { id = poViewModel.STUDENT_ID, id2 = poViewModel.YEAR_ID });
            } //End if

            //Return
            return View(poViewModel);
        } //End Action
        //KWITANSI
        public ActionResult Kwitansiprint(int? id)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            //if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null) { return RedirectToAction("Index"); } //End if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null)
            //Transaction_indetailVM oViewmodel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransactionView_inID()];
            var oData = oDS.getData(id);
            oData.DETAIL = oDSDetail.getDatalist_detail(oData.ID);
            hlpTerbilang bilang = new hlpTerbilang(oData.TRN_AMOUNT);
            oData.TRN_TERBILANG = bilang.Hasil();
            return View(oData);
        }

        public ActionResult Rincian()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            Transaction_indetailVM oData = new Transaction_indetailVM();
            oData.DETAIL = new List<Transaction_inddetailVM>();
            oData.YEAR_ID = oDSYear.getData_currentYear().ID;

            this.prepareLookupFilter();
            return View(oData);
        }
        [HttpPost]
        public ActionResult Rincian(Transaction_indetailVM poViewModel)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            this.oData = poViewModel;
            if (this.oData == null) {
                this.oData = new Transaction_indetailVM();
                this.oData.YEAR_ID = this.oDSYear.getData_currentYearID();
            }
            var oData_year = this.oDSYear.getData(this.oData.YEAR_ID);
            this.oData.YEAR_DESC = oData_year.YEAR_DESC;
            this.oData.YEAR_FROM = oData_year.YEAR_FROM;
            this.oData.YEAR_TO = oData_year.YEAR_TO;

            
            this.oData.DETAIL = oDSDetail.getDatalist_report(
                13, //Uang Pangkal (13)
                this.oData.YEAR_ID, this.oData.TRN_DT,
                this.oData.CLASSTYPE_ID, this.oData.CLASSROOM_ID);
            this.oData.TRN_AMOUNT = 0;
            if (this.oData.DETAIL != null) this.oData.TRN_AMOUNT = this.oData.DETAIL.Sum(fld => fld.TRND_AMOUNT);
            this.prepareLookupFilter();
            return View(oData);
        }

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
                13, //Uang Pangkal (13)
                this.oData.YEAR_ID, this.oData.TRN_DT,
                this.oData.CLASSTYPE_ID, this.oData.CLASSROOM_ID);
            this.oData.TRN_AMOUNT = 0;
            if (this.oData.DETAIL != null) this.oData.TRN_AMOUNT = this.oData.DETAIL.Sum(fld => fld.TRND_AMOUNT);
            this.prepareLookupFilter();
            return View(oData);
        }
    } //End Controller
} //End namespace
