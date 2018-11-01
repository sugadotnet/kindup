using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public class ThemeDS
    {
        //Constructor
        public ThemeDS() { } //End public ThemeDS
        public List<ThemelistVM> getDatalist()
        {
            List<ThemelistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Themes
                           select new ThemelistVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ThemelistVM> getDatalist()
        public ThemedetailVM getData(int? id = null)
        {
            ThemedetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Themes
                           where tb.ID == id
                           select new ThemedetailVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ThemedetailVM getData(int? id = null)


        public List<ThemelookupVM> getDatalist_lookup()
        {
            List<ThemelookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Themes
                           select new ThemelookupVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ThemelookupVM> getDatalist_lookup()
    } //End public class ThemeDS
} //End namespace APPBASE.Models
