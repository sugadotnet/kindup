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
    public partial class Transaction_inController : Controller
    {
        //DBContext
        protected DBMAINContext db = new DBMAINContext();
        //VM
        protected Transaction_indetailVM oViewModel;
        //DATA
        protected Transaction_indetailVM oData;
        protected List<Transaction_indetailVM> oData_list;
        protected Transaction_inddetailVM oDatadetail;
        protected List<Transaction_inddetailVM> oDatadetail_list;
        protected StudentVM oDatastudent;
        protected YeardetailVM oData_year;
        protected MonthsppVM oData_month;
        protected PaymentVM oDatapayment;

        //DS
        protected Transaction_inDS oDS;
        protected Transaction_indDS oDSDetail;
        protected Installment_inDS oDS_inst;
        protected StudentDS oDSStudent;
        protected ClasstypeDS oDSClasstype;
        protected ClassroomDS oDSClassroom;
        protected YearDS oDSYear;
        protected MonthsppDS oDSMonth;
        protected Spp_paymentDS oDSSpp_payment;
        //CRUD
        protected Transaction_inCRUD oCRUD;
        protected Transaction_indCRUD oCRUD_detail;
        protected Installment_inCRUD oCRUD_inst;
        //VALIDATION
        protected Transaction_in_Validation oVAL;
        //BL
        protected Transaction_inBL oBL;
        //MAP


        //Init
        protected virtual void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //VM
            this.oViewModel = new Transaction_indetailVM();
            //DATA
            this.oData = new Transaction_indetailVM();
            this.oData_list = new List<Transaction_indetailVM>();
            this.oDatastudent = new StudentVM();
            this.oDatastudent.DETAIL = new StudentdetailVM();
            
            //DS
            this.oDS = new Transaction_inDS(this.db);
            this.oDSDetail = new Transaction_indDS(this.db);
            this.oDS_inst = new Installment_inDS(this.db);
            this.oDSStudent = new StudentDS(this.db);
            this.oDSClasstype = new ClasstypeDS(this.db);
            this.oDSClassroom = new ClassroomDS(this.db);
            this.oDSYear = new YearDS(db);
            this.oDSMonth = new MonthsppDS();
            //CRUD
            this.oCRUD = new Transaction_inCRUD(this.db);
            this.oCRUD_detail = new Transaction_indCRUD(this.db);
            this.oCRUD_inst = new Installment_inCRUD(this.db);

            //BL
            oBL = new Transaction_inBL();
            //MAP
            //VIEWBAG
            ViewBag.Controllername = "";
            ViewBag.Viewlocation = "~/Views/Transaction_in/";
            ViewBag.Viewextention = ".cshtml";
        } //End initConstructor
        //Constructor 1
        public Transaction_inController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public Transaction_inController(DBMAINContext poDB)
        {
            //DBContext
            this.initConstructor(poDB);
        } //End Constructor 2
        //Prepare Lookup
        public virtual void prepareLookup()
        {
            //ViewBag.STUDENT = oDSStudent.getDatalist_filter(this.oDatastudent.DETAIL);
            //ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist();
            ViewBag.MONTHS = oDSMonth.getDatalist_lookup();
        } //End prepareLookup()
        //Prepare Lookup Filter
        public virtual void prepareLookupFilter()
        {
            //ViewBag.STUDENT = oDSStudent.getDatalist_filter(this.oDatastudent.DETAIL);
            ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.YEAR = oDSYear.getDatalist();
        } //End prepareLookupFilter()

        protected virtual Boolean _Index() {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            this.prepareLookupFilter();
            //ViewBag.STUDENT = oDSStudent.getDatalist_filter(this.oDatastudent.DETAIL);
            //Return
            return true;
        } //End Method
        public virtual ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            this._Index();
            return View(this.oDatastudent);
        } //End Action


        protected Boolean _setData_student(int? id) {
            //Get data student
            this.oDatastudent.DETAIL = oDSStudent.getData(id);
            //STUDENT
            this.oData.STUDENT_ID = id;
            this.oData.STUDENT_NAME = this.oDatastudent.DETAIL.NAME;
            this.oData.PINREG = this.oDatastudent.DETAIL.PINREG;
            this.oData.REGNO = this.oDatastudent.DETAIL.REGNO;
            this.oData.REG_DT = this.oDatastudent.DETAIL.REG_DT;

            //CLASSTYPE
            this.oData.CLASSTYPE_ID = this.oDatastudent.DETAIL.CLASSTYPE_ID;
            this.oData.CLASSTYPE_DESC = this.oDatastudent.DETAIL.CLASSTYPE_NAME;
            //CLASSROOM
            this.oData.CLASSROOM_ID = this.oDatastudent.DETAIL.CLASSROOM_ID;
            this.oData.CLASSROOM_DESC = this.oDatastudent.DETAIL.CLASSROOM_NAME;

            return true;
        } //End Method
        protected Boolean _setData_year(int? id) {
            //Get data tahun
            this.oData_year = this.oDSYear.getData(id);
            this.oData.YEAR_ID = this.oData_year.ID;
            this.oData.YEAR_DESC = this.oData_year.YEAR_DESC;
            this.oData.YEAR_FROM = this.oData_year.YEAR_FROM;
            this.oData.YEAR_TO = this.oData_year.YEAR_TO;

            this.oData.CACHE_YEAR_DESC = this.oData_year.YEAR_DESC;
            this.oData.CACHE_YEAR_FROM = this.oData_year.YEAR_FROM;
            this.oData.CACHE_YEAR_TO = this.oData_year.YEAR_TO;

            return true;
        } //End Method

        protected virtual Boolean _Create(int? id = null, int? id2 = null) {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            //Initial data transaksi
            this.oData = new Transaction_indetailVM();
            this.oData.TRN_DT = DateTime.Now;
            //Initial Student
            if (this._setData_student(id)==false) return false;
            //Initial Tahun
            if (this._setData_year(id2)==false) return false;

            //Return
            return true;
        } //End method
        public virtual ActionResult Create(int? id = null, int? id2 = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            //ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            this._Create(id, id2);
            return View("~/Views/Transaction_in/Create.cshtml", this.oData);
        } //End Action

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        } //End Dispose
    } //End Controller
} //End namespace
