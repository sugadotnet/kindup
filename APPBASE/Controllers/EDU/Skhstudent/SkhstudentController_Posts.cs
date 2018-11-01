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
    public partial class SkhstudentController : Controller
    {
        [HttpPost]
        public ActionResult Index(SkhstudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_INDEX;

            oVAL = new Skhstudent_Validation(poViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) {
                if (poViewModel.FILTER_SKH_ID != null) { poViewModel.LISTSKHSTUDENT = oDS.getDatalist(poViewModel.FILTER_SKH_ID); }
                poViewModel.LISTSKH = oDS_skh.getDatalist(poViewModel);
                if (poViewModel.FILTER_SKHSTUDENT_ID != null) { poViewModel.DETAIL = oDS.getData(poViewModel.FILTER_SKHSTUDENT_ID); }
            } //End if (ModelState.IsValid)

            if (poViewModel.FILTER_ACTION_TYPE == 1) { return View("Create",poViewModel); }
            if (poViewModel.FILTER_ACTION_TYPE == 2) { return View("Details", poViewModel); }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Details(SkhstudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_DETAILS;

            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = null;

            poViewModel.LISTSKHSTUDENT = null;
            poViewModel.DETAIL = oDS.getData(poViewModel.FILTER_SKHSTUDENT_ID);

            if (poViewModel.FILTER_ACTION_TYPE == 21) {
                //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
                ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
                return View("Edit", poViewModel);
            }
            if (poViewModel.FILTER_ACTION_TYPE == 22) {
                //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
                ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
                return View("Delete", poViewModel);
            }

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Create(SkhstudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_CREATE;

            oVAL = new Skhstudent_Validation(poViewModel.DETAIL);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Create(poViewModel.DETAIL);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
                ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
                ViewBag.CRUDSavedOrDelete = valFLAG.FLAG_TRUE;
                poViewModel.DETAIL = oDS.getData(oCRUD.ID);
            } //End if (ModelState.IsValid)

            return View("Details", poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(SkhstudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_EDIT;

            oVAL = new Skhstudent_Validation(poViewModel.DETAIL);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel.DETAIL);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
                ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
                ViewBag.CRUDSavedOrDelete = valFLAG.FLAG_TRUE;
                poViewModel.DETAIL = oDS.getData(oCRUD.ID);
            }
            return View("Details", poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(SkhstudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_LAPSKH_DELETE;

            oCRUD.Delete(poViewModel.FILTER_SKHSTUDENT_ID);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            if (poViewModel.FILTER_SKH_ID != null) { poViewModel.LISTSKHSTUDENT = oDS.getDatalist(poViewModel.FILTER_SKH_ID); }

            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUDSavedOrDelete = valFLAG.FLAG_TRUE;

            return View("Index", poViewModel);
        }
    } //End public partial class SkhstudentController : Controller
} //End namespace APPBASE.Controllers
