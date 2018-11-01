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
    public class DoaDS
    {
        //Constructor
        public DoaDS() { } //End public DoaDS
        public List<DoadetailVM> getDatalist()
        {
            List<DoadetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Doas
                           select new DoadetailVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<DoalistVM> getDatalist()
        public DoadetailVM getData(int? id = null)
        {
            DoadetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Doas
                           where tb.ID == id
                           select new DoadetailVM
                           {
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public DoadetailVM getData(int? id = null)


        public List<DoadetailVM> getDatalist_lookup()
        {
            List<DoadetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Doas
                           select new DoadetailVM
                           {

                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<DoalookupVM> getDatalist_lookup()
    } //End public class DoaDS
} //End namespace APPBASE.Models
