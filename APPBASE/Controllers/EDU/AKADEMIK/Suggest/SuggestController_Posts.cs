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
    public partial class SuggestController : Controller
    {
        [HttpPost]
        public ActionResult Create(SuggestdetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SARAN_CREATE;

            oVAL = new Suggest_Validation(poViewModel);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                poViewModel.TIMELINE_TYPE = this.TIMELINE_TYPE;
                poViewModel.SHARED_GROUP = this.SHARED_GROUP;
                var oCRUDTimeline = new TimelineCRUD(poViewModel);
                oCRUDTimeline.Create();
                poViewModel.TIMELINE_ID = oCRUDTimeline.ID;
                oCRUD.Create(poViewModel);
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
        public ActionResult Edit(SuggestdetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SARAN_EDIT;

            oVAL = new Suggest_Validation(poViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                //poViewModel.TIMELINE_TYPE = this.TIMELINE_TYPE;
                oCRUD.Update(poViewModel);
                poViewModel.TIMELINE_ID = oCRUD.TIMELINE_ID;
                var oCRUDTimeline = new TimelineCRUD(poViewModel);
                oCRUDTimeline.Update();
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
            ViewBag.AC_MENU_ID = valMENU.AKADEMIK_SARAN_DELETE;

            oCRUD.Delete(id);
            var oCRUDTimeline = new TimelineCRUD();
            oCRUDTimeline.Delete(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
    } //End public partial class SuggestController : Controller
} //End namespace APPBASE.Controllers
