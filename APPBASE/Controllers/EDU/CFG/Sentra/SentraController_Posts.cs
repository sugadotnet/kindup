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
    public partial class SentraController : Controller
    {
        [HttpPost]
        public ActionResult Create(SentradetailVM poViewModel)
        {
            //ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_CREATE;

            //oVAL = new Sentra_Validation(poViewModel);
            //oVAL.Validate_Create();

            ////Add Error if exists
            //for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            //{
            //    ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            //} //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            //if (ModelState.IsValid)
            //{
            //    oCRUD.Create(poViewModel);
            //    if (oCRUD.isERR)
            //    {
            //        TempData["ERRMSG"] = oCRUD.ERRMSG;
            //        return RedirectToAction("ErrorSYS", "Error");
            //    } //End if (!oCRUD.isERR) {

            //    TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            //    TempData["CRUDAction"] = "_PartialConfirmSaved";
            //    return RedirectToAction("Index");

            //} //End if (ModelState.IsValid)

            //return View(poViewModel);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(SentradetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_EDIT;

            oVAL = new Sentra_Validation(poViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                //TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                //return RedirectToAction("Details", new { id = oCRUD.ID });

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                TempData["CRUDAction"] = "_PartialConfirmSaved";
                return RedirectToAction("Index");

            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            //ViewBag.AC_MENU_ID = valMENU.PENGATURAN_SENTRA_DELETE;

            //oCRUD.Delete(id);

            //if (oCRUD.isERR)
            //{
            //    TempData["ERRMSG"] = oCRUD.ERRMSG;
            //    return RedirectToAction("ErrorSYS", "Error");
            //} //End if (!oCRUD.isERR) {

            ////TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            ////return RedirectToAction("Index");

            //TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            //TempData["CRUDAction"] = "_PartialConfirmDeleted";
            return RedirectToAction("Index");
        }
    } //End public partial class SentraController : Controller
} //End namespace APPBASE.Controllers

