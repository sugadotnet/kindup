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
    public class SkhstudentdDS
    {
        //Constructor
        public SkhstudentdDS() { } //End public SkhstudentdDS
        public List<SkhstudentdlistVM> getDatalist()
        {
            List<SkhstudentdlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudentd_infos
                           select new SkhstudentdlistVM
                           {
                               ID = tb.ID,
                               EVALUATION_DESC = tb.EVALUATION_DESC,
                               RATE_CODE = tb.RATE_CODE,
                               RATE_DESC = tb.RATE_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhstudentdlistVM> getDatalist()
        public SkhstudentddetailVM getData(int? id = null)
        {
            SkhstudentddetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudentd_infos
                           where tb.ID == id
                           select new SkhstudentddetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               STUDENTSKH_ID = tb.STUDENTSKH_ID,
                               EVALUATION_ID = tb.EVALUATION_ID,
                               RATE_ID = tb.RATE_ID,
                               EVALUATION_CODE = tb.EVALUATION_CODE,
                               EVALUATION_DESC = tb.EVALUATION_DESC,
                               RATE_CODE = tb.RATE_CODE,
                               RATE_DESC = tb.RATE_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SkhstudentddetailVM getData(int? id = null)


        public List<SkhstudentdlookupVM> getDatalist_lookup()
        {
            List<SkhstudentdlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudentd_infos
                           select new SkhstudentdlookupVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhstudentdlookupVM> getDatalist_lookup()
    } //End public class SkhstudentdDS
} //End namespace APPBASE.Models
