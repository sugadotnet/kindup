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
    public class AnnouncementDS
    {
        //Constructor
        public AnnouncementDS() { } //End public AnnouncementDS
        public List<AnnouncementlistVM> getDatalist(DateTime? idDate=null)
        {
            List<AnnouncementlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Announcement_infos
                           select new AnnouncementlistVM
                           {
                               ID = tb.ID,
                               YEAR_ID = tb.YEAR_ID,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };

                if (idDate != null) {
                    oQRY = oQRY.Where(fld => idDate.Value.Date.AddDays(-7) >= fld.DATEFROM.Value.Date &&
                           idDate.Value.Date <= fld.DATEFROM.Value.Date);
                } //End if (idDate != null)

                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<AnnouncementlistVM> getDatalist()
        public AnnouncementdetailVM getData(int? id = null)
        {
            AnnouncementdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Announcement_infos
                           where tb.ID == id
                           select new AnnouncementdetailVM
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
        } //End public AnnouncementdetailVM getData(int? id = null)


        public List<AnnouncementlookupVM> getDatalist_lookup()
        {
            List<AnnouncementlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Announcement_infos
                           select new AnnouncementlookupVM
                           {
                               ID = tb.ID,
                               YEAR_ID = tb.YEAR_ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<AnnouncementlookupVM> getDatalist_lookup()
    } //End public class AnnouncementDS
} //End namespace APPBASE.Models
