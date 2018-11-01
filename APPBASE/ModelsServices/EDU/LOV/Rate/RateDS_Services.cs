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
    public class RateDS
    {
        //Constructor
        public RateDS() { } //End public RateDS
        public List<RatelistVM> getDatalist()
        {
            List<RatelistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Rates
                           select new RatelistVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<RatelistVM> getDatalist()
        public RatedetailVM getData(int? id = null)
        {
            RatedetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Rates
                           where tb.ID == id
                           select new RatedetailVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public RatedetailVM getData(int? id = null)


        public List<RatelookupVM> getDatalist_lookup()
        {
            List<RatelookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Rates
                           select new RatelookupVM
                           {
                               ID = tb.ID,
                               LOV_CODE = tb.LOV_CODE,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<RatelookupVM> getDatalist_lookup()
    } //End public class RateDS
} //End namespace APPBASE.Models
