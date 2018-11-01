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
    public partial class LHStudentController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private LHStudentDS oDS = new LHStudentDS();
        private StudentDS oDSStudent = new StudentDS();
        private UserDS oDSUser = new UserDS();
        private LHStudentCRUD oCRUD = new LHStudentCRUD();
        private LHStudent_Validation oVAL;
        private string TEMPDATA_RPTLHS = "TEMPDATA_RPTLHS";
        //CFG
        private ClasstypeDS oDSClasstype = new ClasstypeDS();
        private ClassroomDS oDSClassroom = new ClassroomDS();
        //LOV
        private MoodDS oDSMood = new MoodDS();
        private AttendanceDS oDSAttendance = new AttendanceDS();

        public void prepareLookup()
        {
            ViewBag.MOOD = oDSMood.getDatalist_lookup();
            ViewBag.ATTENDANCE = oDSAttendance.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ViewBag.isOutstanding = false;

            if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P) {
                return RedirectToAction("Indexparent");
            } //End if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)

            var oData = new LHStudentVM();
            oData.FILTER_DATE = DateTime.Now;
            if (TempData["poViewModel"] != null) { oData = (LHStudentVM)TempData["poViewModel"]; }
            
            prepareLookupFilter();
            return View(oData);
        }
        public ActionResult Indexreport()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;

            if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)
            {
                return RedirectToAction("Indexparent");
            } //End if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)

            var oData = new LHStudentVM();
            oData.FILTER_DATE = DateTime.Now;
            if (TempData[this.TEMPDATA_RPTLHS] != null) { oData = (LHStudentVM)TempData[this.TEMPDATA_RPTLHS]; }

            prepareLookupFilter();
            return View(oData);
        }
        public ActionResult Indexparent()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            int? nTes = hlpConfig.SessionInfo.getAppResId();
            var oData = oDS.getDatalist(hlpConfig.SessionInfo.getAppResId());
            return View(oData);
        }

        public ActionResult Reportlhs()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;

            if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)
            {
                return RedirectToAction("Indexparent");
            } //End if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)

            var oData = new LHStudentVM();
            if (TempData[this.TEMPDATA_RPTLHS] != null) {
                oData = (LHStudentVM)TempData[this.TEMPDATA_RPTLHS];
                Session[this.TEMPDATA_RPTLHS] = oData;
                oData.LISTRPT = oDS.getDatalist_report(oData);
            } //End if (TempData[this.TEMPDATA_RPTLHS] != null)
            
            return View(oData);
        }
        public ActionResult Reportlhsprint()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;

            if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)
            {
                return RedirectToAction("Indexparent");
            } //End if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P)

            var oData = new LHStudentVM();
            if (Session[this.TEMPDATA_RPTLHS] != null)
            {
                oData = (LHStudentVM)Session[this.TEMPDATA_RPTLHS];
                Session[this.TEMPDATA_RPTLHS] = null;
                oData.LISTRPT = oDS.getDatalist_report(oData);
            } //End if (TempData[this.TEMPDATA_RPTLHS] != null)

            return View(oData);
        }

        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            LHStudentVM oData = new LHStudentVM();
            if (TempData["poViewModel"] != null) {
                ViewBag.poViewModel = TempData["poViewModel"];
                oData = ViewBag.poViewModel;
                oData.DETAIL = oDS.getData(oData.DETAIL.ID);
            }
            if (oData == null) { return HttpNotFound(); }

            prepareLookup();
            return View(oData);
        }
        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            prepareLookup();
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }

            prepareLookup();
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //Sementara tidak bisa delete
            return RedirectToAction("Index");
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }

            prepareLookup();
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class LHStudentController : Controller
} //End namespace APPBASE.Controllers
