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
    public partial class ClassroomController : Controller
    {
        public JsonResult getDatalist_ByClassType(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            this.oData = oDS.getDatalist_ByClassType(id);
            return Json(this.oData, JsonRequestBehavior.AllowGet);
        }
    } //End class
} //End namespace
