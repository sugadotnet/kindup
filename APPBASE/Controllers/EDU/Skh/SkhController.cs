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
    public partial class SkhController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private SkhDS oDS = new SkhDS();
        private SkhCRUD oCRUD = new SkhCRUD();
        private Skh_Validation oVAL;
        //DS CFG
        //private BranchallDS oDSBranchall = new BranchallDS();
        private YearDS oDSYear = new YearDS();
        private SemesterDS oDSSemester = new SemesterDS();
        private ClasstypeDS oDSClasstype = new ClasstypeDS();
        //private ClassroomDS oDSClassroom = new ClassroomDS();
        //DS LOV
        private ThemeDS oDSTheme = new ThemeDS();

        public void prepareLookup()
        {

            ViewBag.YEAR = oDSYear.getDatalist_lookup();
            ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.THEME = oDSTheme.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            ViewBag.YEAR = oDSYear.getDatalist_lookup();
            ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.THEME = oDSTheme.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_INDEX;

            var oData = new SkhVM();
            prepareLookupFilter();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            SkhVM oData = new SkhVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            SkhVM oData = new SkhVM();
            oData.DETAIL = new SkhdetailVM();
            prepareLookup();
            return View(oData);
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            SkhVM oData = new SkhVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            SkhVM oData = new SkhVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class SkhController : Controller
} //End namespace APPBASE.Controllers

