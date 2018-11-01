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
    public partial class SkhController : Controller
    {
        [HttpPost]
        public ActionResult Index(SkhVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_INDEX;

            oVAL = new Skh_Validation(poViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) { poViewModel.LIST = oDS.getDatalist(poViewModel); } //End if (ModelState.IsValid)

            prepareLookupFilter();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Create(SkhVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_CREATE;

            oVAL = new Skh_Validation(poViewModel.DETAIL);
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

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.ID });

            } //End if (ModelState.IsValid)

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(SkhVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_EDIT;

            oVAL = new Skh_Validation(poViewModel.DETAIL);
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

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.ID });
            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SKH_DELETE;

            oCRUD.Delete(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
    } //End public partial class SkhController : Controller
} //End namespace APPBASE.Controllers
