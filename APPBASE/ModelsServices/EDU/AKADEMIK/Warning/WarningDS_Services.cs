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
    public class WarningDS
    {
        //Constructor
        public WarningDS() { } //End public WarningDS
        public List<WarninglistVM> getDatalist()
        {
            List<WarninglistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Warning_infos
                           select new WarninglistVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<WarninglistVM> getDatalist()
        public WarningdetailVM getData(int? id = null)
        {
            WarningdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Warning_infos
                           where tb.ID == id
                           select new WarningdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_ID = tb.YEAR_ID,
                               TIMELINE_ID = tb.TIMELINE_ID,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               FULL_DESC = tb.FULL_DESC,
                               USERNAME_ID = tb.USERNAME_ID,
                               TEACHER_DISPLAY_NAME = tb.TEACHER_DISPLAY_NAME,
                               TEACHER_ROLE_DISPLAY_NAME = tb.TEACHER_ROLE_DISPLAY_NAME,
                               TEACHER_RES_NIP = tb.TEACHER_RES_NIP,
                               TEACHER_RES_NAME = tb.TEACHER_RES_NAME,
                               TEACHER_RES_JOBTITLE_ID = tb.TEACHER_RES_JOBTITLE_ID,
                               TEACHER_JOBTITLE_DESC = tb.TEACHER_JOBTITLE_DESC,
                               TEACHER_BRANCH_DESC = tb.TEACHER_BRANCH_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public WarningdetailVM getData(int? id = null)


        public List<WarninglookupVM> getDatalist_lookup()
        {
            List<WarninglookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Warning_infos
                           select new WarninglookupVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<WarninglookupVM> getDatalist_lookup()
    } //End public class WarningDS
} //End namespace APPBASE.Models
