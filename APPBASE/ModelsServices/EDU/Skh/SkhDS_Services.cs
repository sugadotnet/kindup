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
    public class SkhDS
    {
        //Constructor
        public SkhDS() { } //End public SkhDS
        public List<SkhlistitemVM> getDatalist(SkhVM poViewModel = null)
        {
            List<SkhlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skh_infos
                           select new SkhlistitemVM
                           {
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               THEME_ID = tb.THEME_ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               ID = tb.ID,
                               ACTIVITY = tb.ACTIVITY,
                               INDICATOR = tb.INDICATOR,
                               MEDIA = tb.MEDIA
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
                    if (poViewModel.FILTER_THEME_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.THEME_ID == poViewModel.FILTER_THEME_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhlistVM> getDatalist()
        public List<SkhlistitemVM> getDatalist(SkhstudentVM poViewModel = null)
        {
            List<SkhlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skh_infos
                           select new SkhlistitemVM
                           {
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               THEME_ID = tb.THEME_ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               ID = tb.ID,
                               ACTIVITY = tb.ACTIVITY,
                               INDICATOR = tb.INDICATOR,
                               MEDIA = tb.MEDIA
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
                    if (poViewModel.FILTER_THEME_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.THEME_ID == poViewModel.FILTER_THEME_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhlistVM> getDatalist()
        public SkhdetailVM getData(int? id = null)
        {
            SkhdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skh_infos
                           where tb.ID == id
                           select new SkhdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               THEME_ID = tb.THEME_ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               ACTIVITY = tb.ACTIVITY,
                               INDICATOR = tb.INDICATOR,
                               MEDIA = tb.MEDIA,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               THEME_DESC = tb.THEME_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SkhdetailVM getData(int? id = null)


        public List<SkhlookupVM> getDatalist_lookup()
        {
            List<SkhlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skh_infos
                           select new SkhlookupVM
                           {
                               ID = tb.ID,
                               ACTIVITY = tb.ACTIVITY,
                               INDICATOR = tb.INDICATOR,
                               MEDIA = tb.MEDIA
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhlookupVM> getDatalist_lookup()
    } //End public class SkhDS
} //End namespace APPBASE.Models
