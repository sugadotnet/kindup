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
    public class SkhstudenthDS
    {
        //Constructor
        public SkhstudenthDS() { } //End public SkhstudenthDS
        public List<SkhstudenthlistVM> getDatalist()
        {
            List<SkhstudenthlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudenth_infos
                           select new SkhstudenthlistVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               SKH_ID = tb.SKH_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               NIS = tb.NIS,
                               NAME = tb.NAME,
                               RESULT_DESC = tb.RESULT_DESC,
                               RESULT_FEEDBACK = tb.RESULT_FEEDBACK
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhstudenthlistVM> getDatalist()
        public SkhstudenthdetailVM getData(int? id = null)
        {
            SkhstudenthdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudenth_infos
                           where tb.ID == id
                           select new SkhstudenthdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               SKH_ID = tb.SKH_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               RESULT_DESC = tb.RESULT_DESC,
                               RESULT_FEEDBACK = tb.RESULT_FEEDBACK,
                               YEAR_ID = tb.YEAR_ID,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               ACTIVITY = tb.ACTIVITY,
                               INDICATOR = tb.INDICATOR,
                               MEDIA = tb.MEDIA,
                               NAME = tb.NAME,
                               NICKNAME = tb.NICKNAME,
                               NIS = tb.NIS,
                               NISN = tb.NISN,
                               PINREG = tb.PINREG,
                               REGNO = tb.REGNO,
                               REG_DT = tb.REG_DT,
                               BRANCH_ID = tb.BRANCH_ID,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SkhstudenthdetailVM getData(int? id = null)


        public List<SkhstudenthlookupVM> getDatalist_lookup()
        {
            List<SkhstudenthlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudenth_infos
                           select new SkhstudenthlookupVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhstudenthlookupVM> getDatalist_lookup()
    } //End public class SkhstudenthDS
} //End namespace APPBASE.Models
