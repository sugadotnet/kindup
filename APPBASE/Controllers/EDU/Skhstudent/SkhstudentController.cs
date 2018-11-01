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
    public partial class SkhstudentController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private SkhstudentDS oDS = new SkhstudentDS();
        private SkhDS oDS_skh = new SkhDS();
        private SkhstudentCRUD oCRUD = new SkhstudentCRUD();
        private Skhstudent_Validation oVAL;

        public SkhstudentController() { ViewBag.Title = "Kegiatan Harian Anak"; }
        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_INDEX;

            var oData = new SkhstudentVM();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            SkhstudentVM oData = new SkhstudentVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            SkhstudentVM oData = new SkhstudentVM();
            oData.DETAIL = new SkhstudentdetailVM();
            return View(oData);
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            SkhstudentVM oData = new SkhstudentVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            SkhstudentVM oData = new SkhstudentVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class SkhstudentController : Controller
} //End namespace APPBASE.Controllers

