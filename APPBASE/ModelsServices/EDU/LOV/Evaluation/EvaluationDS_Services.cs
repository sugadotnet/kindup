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
    public class EvaluationDS
    {
        //Constructor
        public EvaluationDS() { } //End public EvaluationDS
        public List<EvaluationlistVM> getDatalist()
        {
            List<EvaluationlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Evaluations
                           select new EvaluationlistVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<EvaluationlistVM> getDatalist()
        public EvaluationdetailVM getData(int? id = null)
        {
            EvaluationdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Evaluations
                           where tb.ID == id
                           select new EvaluationdetailVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public EvaluationdetailVM getData(int? id = null)


        public List<EvaluationlookupVM> getDatalist_lookup()
        {
            List<EvaluationlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Evaluations
                           select new EvaluationlookupVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<EvaluationlookupVM> getDatalist_lookup()
    } //End public class EvaluationDS
} //End namespace APPBASE.Models
