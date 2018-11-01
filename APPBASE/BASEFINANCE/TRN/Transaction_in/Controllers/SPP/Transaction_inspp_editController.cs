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
    public partial class Transaction_insppController : Transaction_inController
    {
        public override ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oDatadetail = this.oDSDetail.getData(id);
            if (this.oDatadetail != null)
            {
                this.oData = this.oDS.getData(this.oDatadetail.TRN_ID);
                this.oData.DETAIL = this.oDSDetail.getDatalist_detail(this.oData.ID);
                //Set Month
                this.setMonth();
                //Get history pembayaran
                //this.oData.HIST = this.oDSDetail.getDatalist_detail(this.oData.STUDENT_ID, 1, this.oData.CACHE_YEAR_FROM, this.oData.CACHE_YEAR_TO);
            } //End if
            if (this.oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        [HttpPost]
        public override ActionResult Edit(Transaction_indetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_EDIT;
            this.oViewModel = poViewModel;
            this.oData = this.oDS.getData(this.oViewModel.ID);
            this.oData.DETAIL = this.oDSDetail.getDatalist_detail(this.oData.ID);
            if (this.oData.DETAIL != null) {
                if (this.oData.DETAIL.Count > 0) {
                    this.oDatadetail = this.oData.DETAIL.FirstOrDefault();

                    //Process Header
                    this.oViewModel = this.oSERVICE_worker.setMonthRange(this.oViewModel);
                    this.oViewModel = this.oSERVICE_mapper.Update_mapper(this.oViewModel, this.oData);
                    this.oCRUD.Update(this.oViewModel);
                    //Process Detail
                    this.oDatadetail = this.oSERVICE_worker_detail.setMonthRange(this.oViewModel, this.oDatadetail);
                    this.oDatadetail = this.oSERVICE_mapper_detail.Update_mapper(this.oViewModel, this.oDatadetail);
                    this.oCRUD_detail.Update(this.oDatadetail);
                } //end if
            } //end if

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            TempData["CRUDAction"] = "_PartialConfirmDeleted";
            return RedirectToAction("Create", new { id = this.oDatadetail.STUDENT_ID, id2 = this.oDatadetail.YEAR_ID });
        }
    } //End Controller
} //End namespace
