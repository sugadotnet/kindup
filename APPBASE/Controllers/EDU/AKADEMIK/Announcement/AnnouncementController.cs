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
    public partial class AnnouncementController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private AnnouncementDS oDS = new AnnouncementDS();
        private AnnouncementCRUD oCRUD = new AnnouncementCRUD();
        private Announcement_Validation oVAL;
        private Byte? TIMELINE_TYPE;
        private int? SHARED_GROUP;

        public AnnouncementController() {
            this.TIMELINE_TYPE = valFLAG.FLAG_TIMELINE_TYPE_CALLENDAR;
            this.SHARED_GROUP = valFLAG.FLAG_SHARED_GROUP_PUBLIC;
        } //End public CallendarController()

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PENGUMUMAN_INDEX;

            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PENGUMUMAN_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult View(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PENGUMUMAN_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PENGUMUMAN_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PENGUMUMAN_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_PENGUMUMAN_DELETE;

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
    } //End public partial class AnnouncementController : Controller
} //End namespace APPBASE.Controllers

