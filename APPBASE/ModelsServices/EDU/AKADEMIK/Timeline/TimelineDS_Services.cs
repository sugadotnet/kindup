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
    public class TimelineDS
    {
        //Constructor
        public TimelineDS() { } //End public TimelineDS
        public List<TimelinelistVM> getDatalist()
        {
            List<TimelinelistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Timeline_infos
                           select new TimelinelistVM
                           {
                               ID = tb.ID,
                               YEAR_ID = tb.YEAR_ID,
                               DATEFROM = tb.DATEFROM,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               TIMELINE_TYPE = tb.TIMELINE_TYPE,
                               SHARED_GROUP = tb.SHARED_GROUP,
                               SHARED_PRIVATE = tb.SHARED_PRIVATE
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<TimelinelistVM> getDatalist()
        public TimelinedetailVM getData(int? id = null)
        {
            TimelinedetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Timeline_infos
                           where tb.ID == id
                           select new TimelinedetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_ID = tb.YEAR_ID,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               FULL_DESC = tb.FULL_DESC,
                               TIMELINE_TYPE = tb.TIMELINE_TYPE,
                               SHARED_GROUP = tb.SHARED_GROUP,
                               SHARED_PRIVATE = tb.SHARED_PRIVATE,
                               YEAR_DESC = tb.YEAR_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public TimelinedetailVM getData(int? id = null)


        public List<TimelinelookupVM> getDatalist_lookup()
        {
            List<TimelinelookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Timeline_infos
                           select new TimelinelookupVM
                           {
                               ID = tb.ID,
                               YEAR_ID = tb.YEAR_ID,
                               TITLE = tb.TITLE,
                               TIMELINE_TYPE = tb.TIMELINE_TYPE,
                               SHARED_GROUP = tb.SHARED_GROUP,
                               SHARED_PRIVATE = tb.SHARED_PRIVATE
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<TimelinelookupVM> getDatalist_lookup()
    } //End public class TimelineDS
} //End namespace APPBASE.Models
