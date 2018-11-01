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
    public class MoodDS
    {
        //Constructor
        public MoodDS() { } //End public MoodDS
        public List<MoodlistVM> getDatalist()
        {
            List<MoodlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Moods
                           select new MoodlistVM
                           {
                               ID = tb.ID,
                               LOV_CODE = tb.LOV_CODE,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<MoodlistVM> getDatalist()
        public MooddetailVM getData(int? id = null)
        {
            MooddetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Moods
                           where tb.ID == id
                           select new MooddetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               LOV_CODE = tb.LOV_CODE,
                               LOV_DESC = tb.LOV_DESC,
                               LOV_SEQNO = tb.LOV_SEQNO
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public MooddetailVM getData(int? id = null)


        public List<MoodlookupVM> getDatalist_lookup()
        {
            List<MoodlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Moods
                           select new MoodlookupVM
                           {
                               ID = tb.ID,
                               LOV_CODE = tb.LOV_CODE,
                               LOV_DESC = tb.LOV_DESC,
                               LOV_SEQNO = tb.LOV_SEQNO
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<MoodlookupVM> getDatalist_lookup()
    } //End public class MoodDS
} //End namespace APPBASE.Models
