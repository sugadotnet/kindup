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
    public partial class SemesterDS
    {
        //Constructor
        public SemesterDS() { } //End public SemesterDS
        public List<SemesterlistVM> getDatalist()
        {
            List<SemesterlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Semesters
                           select new SemesterlistVM
                           {
                               ID = tb.ID,
                               SEMESTER_DESC = tb.SEMESTER_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SemesterlistVM> getDatalist()
        public SemesterdetailVM getData(int? id = null)
        {
            SemesterdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Semesters
                           where tb.ID == id
                           select new SemesterdetailVM
                           {
                               ID = tb.ID,
                               SEMESTER_DESC = tb.SEMESTER_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SemesterdetailVM getData(int? id = null)

        public List<SemesterlookupVM> getDatalist_lookup()
        {
            List<SemesterlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Semesters
                           select new SemesterlookupVM
                           {
                               ID = tb.ID,
                               SEMESTER_DESC = tb.SEMESTER_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SemesterlistVM> getDatalist()
    } //End public class SemesterDS
} //End namespace APPBASE.Models

