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
    public partial class SentraController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private SentraDS oDS = new SentraDS();
        private SentraCRUD oCRUD = new SentraCRUD();
        private Sentra_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_INDEX;

            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            ViewBag.CRUDAction = TempData["CRUDAction"];

            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_CREATE;
            //ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            //return View();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_DELETE;
            //ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            //var oData = oDS.getData(id);
            //if (oData == null) { return HttpNotFound(); }
            //return View(oData);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class SentraController : Controller
} //End namespace APPBASE.Controllers
