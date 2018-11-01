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
        public JsonResult getDatalist_ByClassroom(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            oFilter = new StudentVM();
            oFilter.FILTER_CLASSROOM_ID = (byte)id;
            this.oData_list = oDS.getDatalist_aktif(oFilter);
            return Json(this.oData, JsonRequestBehavior.AllowGet);
        }
    } //End class
} //End namespace