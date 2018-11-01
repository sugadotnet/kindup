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
    public class SongDS
    {
        //Constructor
        public SongDS() { } //End public SongDS
        public List<SongdetailVM> getDatalist()
        {
            List<SongdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Songs
                           select new SongdetailVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SonglistVM> getDatalist()
        public SongdetailVM getData(int? id = null)
        {
            SongdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Songs
                           where tb.ID == id
                           select new SongdetailVM
                           {
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SongdetailVM getData(int? id = null)


        public List<SongdetailVM> getDatalist_lookup()
        {
            List<SongdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Songs
                           select new SongdetailVM
                           {

                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SonglookupVM> getDatalist_lookup()
    } //End public class SongDS
} //End namespace APPBASE.Models
