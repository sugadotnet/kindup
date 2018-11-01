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
    public partial class SkmController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private SkmDS oDS = new SkmDS();
        private SkmCRUD oCRUD = new SkmCRUD();
        private Skm_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKM_INDEX;

            var oData = new SkmVM();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKM_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = new SkmVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKM_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            var oData = new SkmVM();
            oData.DETAIL = new SkmdetailVM();
            return View(oData);
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKM_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = new SkmVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKM_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = new SkmVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class SkmController : Controller
} //End namespace APPBASE.Controllers

