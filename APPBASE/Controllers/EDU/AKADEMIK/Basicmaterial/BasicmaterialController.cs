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
    public partial class BasicmaterialController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private BasicmaterialDS oDS = new BasicmaterialDS();
        private BasicmaterialCRUD oCRUD = new BasicmaterialCRUD();
        private Basicmaterial_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_MATERIDASAR_INDEX;

            return RedirectToAction("Details");
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_MATERIDASAR_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData();
            //if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_MATERIDASAR_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_MATERIDASAR_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData();
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_MATERIDASAR_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData();
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class BasicmaterialController : Controller
} //End namespace APPBASE.Controllers
