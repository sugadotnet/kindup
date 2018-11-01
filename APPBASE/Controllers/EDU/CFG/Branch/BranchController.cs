﻿using System;
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
    public partial class BranchController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private BranchDS oDS = new BranchDS();
        private BranchCRUD oCRUD = new BranchCRUD();
        private Branch_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CABANG_INDEX;

            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CABANG_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CABANG_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CABANG_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            if (hlpConfig.SessionInfo.getAppUsername().ToUpper() == Svcapp.valDFLT.SYSADMIN_USER)
            {
                ViewBag.AC_MENU_ID = valMENU.PENGATURAN_CABANG_DELETE;

                ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
                var oData = oDS.getData(id);
                if (oData == null) { return HttpNotFound(); }
                return View(oData);
            }
            return Redirect(HttpContext.Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class BranchController : Controller
} //End namespace APPBASE.Controllers

