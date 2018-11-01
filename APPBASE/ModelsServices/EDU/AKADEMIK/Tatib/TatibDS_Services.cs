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
    public class TatibDS
    {
        //Constructor
        public TatibDS() { } //End public TatibDS
        public List<TatiblistVM> getDatalist()
        {
            List<TatiblistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Tatibs
                           select new TatiblistVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<TatiblistVM> getDatalist()
        public TatibdetailVM getData()
        {
            TatibdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Tatibs
                           select new TatibdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               FULL_DESC = tb.FULL_DESC
                           };
                oReturn = oQRY.FirstOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public TatibdetailVM getData(int? id = null)
        public TatibdetailVM getData_readmore(int? id = null)
        {
            TatibdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Tatibs
                           where tb.ID == id
                           select new TatibdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC,
                               FULL_DESC = tb.FULL_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public TatibdetailVM getData(int? id = null)


        public List<TatiblookupVM> getDatalist_lookup()
        {
            List<TatiblookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Tatibs
                           select new TatiblookupVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<TatiblookupVM> getDatalist_lookup()
    } //End public class TatibDS
} //End namespace APPBASE.Models
