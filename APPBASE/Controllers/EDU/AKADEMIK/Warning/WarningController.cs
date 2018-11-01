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
    public partial class WarningController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private WarningDS oDS = new WarningDS();
        private WarningCRUD oCRUD = new WarningCRUD();
        private Warning_Validation oVAL;
        private Byte? TIMELINE_TYPE;
        private int? SHARED_GROUP;

        public WarningController() {
            this.TIMELINE_TYPE = valFLAG.FLAG_TIMELINE_TYPE_WARNING;
            this.SHARED_GROUP = valFLAG.FLAG_SHARED_GROUP_EMPLOYEES;
        } //End public WarningController()

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_TEGURAN_INDEX;

            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_TEGURAN_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_TEGURAN_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_TEGURAN_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_TEGURAN_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class WarningController : Controller
} //End namespace APPBASE.Controllers

