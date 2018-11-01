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
    public partial class PromisedController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private PromisedDS oDS = new PromisedDS();
        private PromisedCRUD oCRUD = new PromisedCRUD();
        private Promised_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PROMISED_INDEX;

            //var oData = oDS.getDatalist();
            //return View();
            var oData = new PromisedVM();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PROMISED_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            PromisedVM oData = new PromisedVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PROMISED_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            PromisedVM oData = new PromisedVM();
            oData.DETAIL = new PromiseddetailVM();
            return View(oData);
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PROMISED_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            PromisedVM oData = new PromisedVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PROMISED_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            PromisedVM oData = new PromisedVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class PromisedController : Controller
} //End namespace APPBASE.Controllers

