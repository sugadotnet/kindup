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
    public partial class YearDS
    {
        private DBMAINContext db;
        //Constructor 1
        public YearDS() { this.db = new DBMAINContext(); } //End public YearDS
        public List<YearlistVM> getDatalist()
        {
            List<YearlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           select new YearlistVM
                           {
                               ID = tb.ID,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<YearlistVM> getDatalist()
        public YeardetailVM getData(int? id = null)
        {
            YeardetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           where tb.ID == id
                           select new YeardetailVM
                           {
                               ID = tb.ID,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public YeardetailVM getData(int? id = null)

        public List<YearlookupVM> getDatalist_lookup()
        {
            List<YearlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           select new YearlookupVM
                           {
                               ID = tb.ID,
                               YEAR_DESC = tb.YEAR_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<YearlookupVM> getDatalist_lookup()
    } //End public class YearDS
} //End namespace APPBASE.Models

