using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Filters;
using APPBASE.Svcbiz;

namespace APPBASE.Controllers
{
    public class HomeController : Controller
    {
        [MyActionFilterAttribute]
        public ActionResult Index()
        {
            if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_P) {
                return RedirectToAction("Indexparent", "LHStudent");
            }
            if (hlpConfig.SessionInfo.getAppRoleId() == valFLAG.FLAG_ROLE_CT)
            {
                return RedirectToAction("Index", "LHStudent");
            }
            return View();
        }
        public ActionResult About()
        {
            var oDS = new AboutusDS();
           
            return View(oDS.getData());
        }
        public ActionResult Contact()
        {
            return View();
        }
    } //End public class HomeController : Controller
} //End namespace APPBASE.Controllers
