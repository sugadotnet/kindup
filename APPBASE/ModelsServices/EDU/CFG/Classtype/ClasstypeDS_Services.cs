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
    public class ClasstypeDS
    {
        private DBMAINContext db;

        //Constructor 1
        public ClasstypeDS() {
            this.db = new DBMAINContext();
        } //End public ClasstypeDS
        //Constructor 2
        public ClasstypeDS(DBMAINContext poDB)
        {
            this.db = poDB;
        } //End public ClasstypeDS
        public List<ClasstypelistVM> getDatalist()
        {
            List<ClasstypelistVM> vReturn;
            var oQRY = from tb in db.Classtypes
                       select new ClasstypelistVM
                       {
                           ID = tb.ID,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<ClasstypelistVM> getDatalist()
        public ClasstypedetailVM getData(int? id = null)
        {
            ClasstypedetailVM oReturn;
            var oQRY = from tb in db.Classtypes
                       where tb.ID == id
                       select new ClasstypedetailVM
                       {
                           ID = tb.ID,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC
                       };
            oReturn = oQRY.SingleOrDefault();
            return oReturn;
        } //End public ClasstypedetailVM getData(int? id = null)
        public List<ClasstypelookupVM> getDatalist_lookup()
        {
            List<ClasstypelookupVM> vReturn;
            var oQRY = from tb in db.Classtypes
                       select new ClasstypelookupVM
                       {
                           ID = tb.ID,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<ClasstypelookupVM> getDatalist_lookup()

    } //End public class ClasstypeDS
} //End namespace APPBASE.Models

