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
        public override ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            this.oDatadetail = this.oDSDetail.getData(id);
            if (this.oDatadetail != null) {
                this.oData = this.oDS.getData(this.oDatadetail.TRN_ID);
                this.oData.DETAIL = this.oDSDetail.getDatalist_detail(this.oData.ID);
                //Set Month
                this.setMonth();
                //Get history pembayaran
                this.oData.HIST = this.oDSDetail.getDatalist_detail(this.oData.STUDENT_ID, 1, this.oData.CACHE_YEAR_FROM, this.oData.CACHE_YEAR_TO);
            } //End if
            if (this.oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        [HttpPost, ActionName("Delete")]
        public override ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.AC_MENU_ID = valMENU.KEUANGAN_SPP_DELETE;
            this.oDatadetail = this.oDSDetail.getData(id);
            this.oCRUD.Delete(this.oDatadetail.TRN_ID);
            this.oCRUD_detail.Delete(this.oDatadetail.ID);

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
