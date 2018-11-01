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
    public partial class StudentController : Controller
    {
        [HttpPost]
        public ActionResult Index(StudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_INDEX;

            oVAL = new Student_Validation(poViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) { poViewModel.LIST = oDS.getDatalist_aktif(poViewModel); } //End if (ModelState.IsValid)
            prepareLookupFilter();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Index_calon(StudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_INDEX;

            oVAL = new Student_Validation(poViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) { poViewModel.LIST = oDS.getDatalist_calon(poViewModel); } //End if (ModelState.IsValid)
            prepareLookupFilter();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Index_alumni(StudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_INDEX;

            oVAL = new Student_Validation(poViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) { poViewModel.LIST = oDS.getDatalist_lulus(poViewModel); } //End if (ModelState.IsValid)
            prepareLookupFilter();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Index_pindah(StudentVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_INDEX;

            oVAL = new Student_Validation(poViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) { poViewModel.LIST = oDS.getDatalist_pindah(poViewModel); } //End if (ModelState.IsValid)
            prepareLookupFilter();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Create(StudentVM poViewModel, HttpPostedFileBase FileSTUDENT_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_CREATE;

            oVAL = new Student_Validation(poViewModel.DETAIL);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Create(poViewModel.DETAIL, FileSTUDENT_IMG);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                TempData["CRUDAction"] = "_PartialConfirmSaved";
                return RedirectToAction("Index");

            } //End if (ModelState.IsValid)

            return View(poViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM poViewModel, HttpPostedFileBase FileSTUDENT_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_EDIT;

            oVAL = new Student_Validation(poViewModel.DETAIL);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel.DETAIL, FileSTUDENT_IMG);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                TempData["CRUDAction"] = "_PartialConfirmSaved";
                return RedirectToAction("Index");
            }
            return View(poViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_DELETE;

            oCRUD.Delete(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            TempData["CRUDAction"] = "_PartialConfirmDeleted";
            return RedirectToAction("Index");
        }

    } //End public partial class StudentController : Controller
} //End namespace APPBASE.Controllers
