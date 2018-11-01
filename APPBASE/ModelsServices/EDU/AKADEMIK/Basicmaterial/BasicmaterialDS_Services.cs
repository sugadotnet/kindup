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
    public class BasicmaterialDS
    {
        //Constructor
        public BasicmaterialDS() { } //End public BasicmaterialDS
        public List<BasicmateriallistVM> getDatalist()
        {
            List<BasicmateriallistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Basicmaterials
                           select new BasicmateriallistVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE,
                               SHORT_DESC = tb.SHORT_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<BasicmateriallistVM> getDatalist()
        public BasicmaterialdetailVM getData()
        {
            BasicmaterialdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Basicmaterials
                           select new BasicmaterialdetailVM
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
        } //End public BasicmaterialdetailVM getData(int? id = null)
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


        public List<BasicmateriallookupVM> getDatalist_lookup()
        {
            List<BasicmateriallookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Basicmaterials
                           select new BasicmateriallookupVM
                           {
                               ID = tb.ID,
                               TITLE = tb.TITLE
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<BasicmateriallookupVM> getDatalist_lookup()
    } //End public class BasicmaterialDS
} //End namespace APPBASE.Models
