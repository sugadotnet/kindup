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
    public partial class Transaction_inController : Controller
    {
        public virtual ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            return View(this.oData);
        }

        [HttpPost]
        public virtual ActionResult Edit(Transaction_indetailVM poViewModel)
        {
            this.oVAL = new Transaction_in_Validation(poViewModel, oDS);
            this.oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Update(poViewModel);
                this.oCRUD.Commit();
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });
            }
            return View(poViewModel);
        }
        public virtual ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            return View(this.oData);
        }
        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(int? id)
        {
            this.oCRUD.Delete(id);
            this.oCRUD.Commit();
            if (this.oCRUD.isERR)
            {
                TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
        public virtual ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            return View(this.oData);
        }
    } //End Controller
} //End namespace
