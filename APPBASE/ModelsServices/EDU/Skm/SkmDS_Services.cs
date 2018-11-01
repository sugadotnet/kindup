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
    public class SkmDS
    {
        //Constructor
        public SkmDS() { } //End public SkmDS
        public List<SkmlistitemVM> getDatalist(SkmVM poViewModel = null)
        {
            List<SkmlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skm_infos
                           select new SkmlistitemVM
                           {
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               ID = tb.ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               EVALUATION_DESC = tb.EVALUATION_DESC
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)

                    if (poViewModel.FILTER_WEEKNUM != null)
                    {
                        oQRY = oQRY.Where(fld => fld.WEEKNUM == poViewModel.FILTER_WEEKNUM);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_DATEFROM != null)
                    {
                        oQRY = oQRY.Where(fld => fld.DATEFROM == poViewModel.FILTER_DATEFROM);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)

                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkmlistVM> getDatalist()
        public SkmdetailVM getData(int? id = null)
        {
            SkmdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skm_infos
                           where tb.ID == id
                           select new SkmdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               EVALUATION_ID = tb.EVALUATION_ID,
                               SKM_DESC = tb.SKM_DESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               EVALUATION_CODE = tb.EVALUATION_CODE,
                               EVALUATION_DESC = tb.EVALUATION_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SkmdetailVM getData(int? id = null)


        public List<SkmlookupVM> getDatalist_lookup()
        {
            List<SkmlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skm_infos
                           select new SkmlookupVM
                           {
                               ID = tb.ID,
                               EVALUATION_DESC = tb.EVALUATION_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkmlookupVM> getDatalist_lookup()
    } //End public class SkmDS
} //End namespace APPBASE.Models
