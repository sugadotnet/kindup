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
    public class SuggestDS
    {
        //Constructor
        public SuggestDS() { } //End public SuggestDS
        public List<SuggestlistVM> getDatalist()
        {
            List<SuggestlistVM> vReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Suggest_infos
                           select new SuggestlistVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               SHORT_FEEDBACK = tb.SHORT_FEEDBACK
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SuggestlistVM> getDatalist()
        public SuggestdetailVM getData(int? id = null)
        {
            SuggestdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Suggest_infos
                           where tb.ID == id
                           select new SuggestdetailVM
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
                               SHORT_FEEDBACK = tb.SHORT_FEEDBACK,
                               FULL_FEEDBACK = tb.FULL_FEEDBACK,
                               PARENT_DISPLAY_NAME = tb.PARENT_DISPLAY_NAME,
                               PARENT_ROLE_DISPLAY_NAME = tb.PARENT_ROLE_DISPLAY_NAME,
                               PARENT_RES_NIS = tb.PARENT_RES_NIS,
                               PARENT_RES_NAME = tb.PARENT_RES_NAME,
                               PARENT_RES_CLASSTYPE_ID = tb.PARENT_RES_CLASSTYPE_ID,
                               PARENT_RES_CLASSTYPE_DESC = tb.PARENT_RES_CLASSTYPE_DESC,
                               HQ_DISPLAY_NAME = tb.HQ_DISPLAY_NAME,
                               HQ_ROLE_DISPLAY_NAME = tb.HQ_ROLE_DISPLAY_NAME,
                               HQ_RES_NIP = tb.HQ_RES_NIP,
                               HQ_RES_NAME = tb.HQ_RES_NAME,
                               HQ_RES_JOBTITLE_ID = tb.HQ_RES_JOBTITLE_ID,
                               HQ_JOBTITLE_DESC = tb.HQ_JOBTITLE_DESC,
                               HQ_BRANCH_DESC = tb.HQ_BRANCH_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SuggestdetailVM getData(int? id = null)


        public List<SuggestlookupVM> getDatalist_lookup()
        {
            List<SuggestlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Suggest_infos
                           select new SuggestlookupVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               SHORT_FEEDBACK = tb.SHORT_FEEDBACK
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SuggestlookupVM> getDatalist_lookup()
    } //End public class SuggestDS
} //End namespace APPBASE.Models
