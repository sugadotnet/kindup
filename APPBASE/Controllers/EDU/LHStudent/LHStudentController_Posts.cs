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
using APPBASE.Svcapp;

namespace APPBASE.Controllers
{
    public partial class LHStudentController : Controller
    {
        [HttpPost]
        public ActionResult Index(LHStudentVM poViewModel)
        {
            oVAL = new LHStudent_Validation(poViewModel);
            oVAL.Validate_Filter();

            ViewBag.isOutstanding = false;

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            
            if (ModelState.IsValid) { poViewModel.LISTITEM_STUDENT = oDSStudent.getDatalist_lhstudent(poViewModel); } //End if (ModelState.IsValid)

            prepareLookup();
            prepareLookupFilter();
            poViewModel.DETAIL_USER = oDSUser.getData(hlpConfig.SessionInfo.getAppUserId());
            if (poViewModel.FILTER_ACTION_TYPE !=null) {
                if (poViewModel.FILTER_ACTION_TYPE == 3) {
                    ViewBag.isOutstanding = true;
                    //var oData = oDSStudent.getDatalist_outstandinglhs(poViewModel.FILTER_DATE, poViewModel.FILTER_CLASSTYPE_ID, poViewModel.FILTER_CLASSROOM_ID);
                    poViewModel.LISTITEM_STUDENT = oDSStudent.getDatalist_outstandinglhs(poViewModel.FILTER_DATE, poViewModel.FILTER_CLASSTYPE_ID, poViewModel.FILTER_CLASSROOM_ID);
                    //return View("Indexoutstandingstudent", poViewModel);
                }
                else {
                    poViewModel.DETAIL_STUDENT = oDSStudent.getData_lookup(poViewModel.FILTER_ID);
                    poViewModel.DETAIL = oDS.getData_create(poViewModel);
                    //#arn Session["poViewModel"] = poViewModel;

                    if (poViewModel.DETAIL.ID == null) { ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE; return View("Create", poViewModel); }

                    if (poViewModel.DETAIL.ID != null) { ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE; return View("Edit", poViewModel); }
                }
            } //End if (poViewModel.FILTER_ACTION_TYPE !=null)

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Indexreport(LHStudentVM poViewModel)
        {
            LHStudentVM oViewModel = poViewModel;
            oVAL = new LHStudent_Validation(oViewModel);
            oVAL.Validate_Filter();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                TempData[this.TEMPDATA_RPTLHS] = oViewModel;
                return RedirectToAction("Reportlhs");
            } //End if (ModelState.IsValid)

            prepareLookup();
            prepareLookupFilter();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Create(LHStudentVM poViewModel)
        {

            oVAL = new LHStudent_Validation(poViewModel);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Create(poViewModel);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                poViewModel.DETAIL.ID = oCRUD.ID;

                TempData["poViewModel"] = Session["poViewModel"];
                Session.Remove("poViewModel");

                return RedirectToAction("Index");

            } //End if (ModelState.IsValid)

            prepareLookup();
            poViewModel.DETAIL_USER = oDSUser.getData(hlpConfig.SessionInfo.getAppUserId());
            poViewModel.DETAIL_STUDENT = oDSStudent.getData_lookup(poViewModel.FILTER_ID);
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(LHStudentVM poViewModel)
        {
            oVAL = new LHStudent_Validation(poViewModel);
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

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;

                TempData["poViewModel"] = Session["poViewModel"];
                Session.Remove("poViewModel");

                //return RedirectToAction("Details", new { id = oCRUD.ID });
                return RedirectToAction("Index");
            }

            prepareLookup();
            poViewModel.DETAIL_USER = oDSUser.getData(hlpConfig.SessionInfo.getAppUserId());
            poViewModel.DETAIL_STUDENT = oDSStudent.getData_lookup(poViewModel.FILTER_ID);
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            oCRUD.Delete(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
    } //End public partial class LHStudentController : Controller
} //End namespace APPBASE.Controllers
