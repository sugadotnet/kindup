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
        //KWITANSI
        public ActionResult Kwitansiprint(int? id)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            //if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null) { return RedirectToAction("Index"); } //End if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null)
            //Transaction_indetailVM oViewmodel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransactionView_inID()];
            var oData = oDS.getData(id);
            oData.DETAIL = oDSDetail.getDatalist_detail(oData.ID);
            return View(oData);
        }
    } //End Controller
} //End namespace
