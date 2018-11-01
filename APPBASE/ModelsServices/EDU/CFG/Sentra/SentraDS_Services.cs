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
    public class SentraDS
    {
        //Constructor
        public SentraDS() { } //End public SentraDS
        public List<SentralistVM> getDatalist()
        {
            List<SentralistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Sentras
                           select new SentralistVM
                           {
                               ID = tb.ID,
                               SENTRA_CODE = tb.SENTRA_CODE,
                               SENTRA_NAME = tb.SENTRA_NAME,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SentralistVM> getDatalist()
        public SentradetailVM getData(int? id = null)
        {
            SentradetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Sentras
                           where tb.ID == id
                           select new SentradetailVM
                           {
                               ID = tb.ID,
                               SENTRA_CODE = tb.SENTRA_CODE,
                               SENTRA_NAME = tb.SENTRA_NAME,
                               SENTRA_DESC = tb.SENTRA_DESC,
                               SENTRA_VOLUME = tb.SENTRA_VOLUME
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SentradetailVM getData(int? id = null)


        public List<SentralookupVM> getDatalist_lookup()
        {
            List<SentralookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Sentras
                           select new SentralookupVM
                           {
                               ID = tb.ID,
                               SENTRA_CODE = tb.SENTRA_CODE,
                               SENTRA_NAME = tb.SENTRA_NAME,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SentralookupVM> getDatalist_lookup()
    } //End public class SentraDS
} //End namespace APPBASE.Models

