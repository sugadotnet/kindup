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
    public class CallendarDS
    {
        //Constructor
        public CallendarDS() { } //End public CallendarDS
        public List<CallendarlistVM> getDatalist()
        {
            List<CallendarlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Callendar_infos
                           select new CallendarlistVM
                           {
                               ID = tb.ID,
                               YEAR_ID = tb.YEAR_ID,
                               DATEFROM = tb.DATEFROM,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CallendarlistVM> getDatalist()
        public CallendardetailVM getData(int? id = null)
        {
            CallendardetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Callendar_infos
                           where tb.ID == id
                           select new CallendardetailVM
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
                               YEAR_DESC = tb.YEAR_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CallendardetailVM getData(int? id = null)


        public List<CallendarlookupVM> getDatalist_lookup()
        {
            List<CallendarlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Callendar_infos
                           select new CallendarlookupVM
                           {
                               ID = tb.ID,
                               YEAR_ID = tb.YEAR_ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CallendarlookupVM> getDatalist_lookup()
    } //End public class CallendarDS
} //End namespace APPBASE.Models
