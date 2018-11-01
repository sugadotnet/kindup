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
    public partial class ClassroomteacherController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private ClassroomteacherDS oDS = new ClassroomteacherDS();
        private ClassroomteacherCRUD oCRUD = new ClassroomteacherCRUD();
        private Classroomteacher_Validation oVAL;
        //DS CFG
        //private BranchallDS oDSBranchall = new BranchallDS();
        //private YearDS oDSYear = new YearDS();
        //private SemesterDS oDSSemester = new SemesterDS();
        private ClasstypeDS oDSClasstype = new ClasstypeDS();
        private ClassroomDS oDSClassroom = new ClassroomDS();
        //EMPLOYEE
        private EmployeeDS oDSEmployee = new EmployeeDS();

        public void prepareLookup()
        {
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            ViewBag.EMPLOYEE = oDSEmployee.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CLASSROOMTEACHER_INDEX;

            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CLASSROOMTEACHER_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }

            prepareLookup();
            return View(oData);
        }
        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CLASSROOMTEACHER_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            ClassroomteacherdetailVM oData = new ClassroomteacherdetailVM();
            prepareLookup();
            return View(oData);
        }
        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CLASSROOMTEACHER_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }

            prepareLookup();
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CLASSROOMTEACHER_DELETE;

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
    } //End public partial class ClassroomteacherController : Controller
} //End namespace APPBASE.Controllers
