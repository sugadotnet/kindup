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
    public class SkhstudentDS
    {
        //Constructor
        public SkhstudentDS() { } //End public SkhstudentDS
        public List<SkhstudentlistitemVM> getDatalist(SkhstudentVM poViewModel = null)
        {
            List<SkhstudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudent_infos
                           select new SkhstudentlistitemVM
                           {
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               THEME_ID = tb.THEME_ID,
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               SKH_ID = tb.SKH_ID,
                               MEDIA = tb.MEDIA,
                               STUDENT_ID = tb.STUDENT_ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               RATEA_DESC = tb.RATEA_CODE,
                               RATESE_DESC = tb.RATESE_CODE,
                               RATEB_DESC = tb.RATEB_CODE,
                               RATEK_DESC = tb.RATEK_CODE,
                               RATEMH_DESC = tb.RATEMH_CODE,
                               RATEMK_DESC = tb.RATEMK_CODE,
                               RATES_DESC = tb.RATES_CODE
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
        } //End public List<SkhstudentlistVM> getDatalist()
        public List<SkhstudentlistitemVM> getDatalist(int? id = null)
        {
            List<SkhstudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudent_infos
                           select new SkhstudentlistitemVM
                           {
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               THEME_ID = tb.THEME_ID,
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               SKH_ID = tb.SKH_ID,
                               MEDIA = tb.MEDIA,
                               STUDENT_ID = tb.STUDENT_ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               RATEA_DESC = tb.RATEA_CODE,
                               RATESE_DESC = tb.RATESE_CODE,
                               RATEB_DESC = tb.RATEB_CODE,
                               RATEK_DESC = tb.RATEK_CODE,
                               RATEMH_DESC = tb.RATEMH_CODE,
                               RATEMK_DESC = tb.RATEMK_CODE,
                               RATES_DESC = tb.RATES_CODE
                           };
                if (id != null) { oQRY = oQRY.Where(fld => fld.SKH_ID == id); } //End if (id != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhstudentlistVM> getDatalist()

        public SkhstudentdetailVM getData(int? id = null)
        {
            SkhstudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudent_infos
                           where tb.ID == id
                           select new SkhstudentdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               SKH_ID = tb.SKH_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               RESULT_DESC = tb.RESULT_DESC,
                               RESULT_FEEDBACK = tb.RESULT_FEEDBACK,
                               RATEA_ID = tb.RATEA_ID,
                               RATESE_ID = tb.RATESE_ID,
                               RATEB_ID = tb.RATEB_ID,
                               RATEK_ID = tb.RATEK_ID,
                               RATEMH_ID = tb.RATEMH_ID,
                               RATEMK_ID = tb.RATEMK_ID,
                               RATES_ID = tb.RATES_ID,
                               YEAR_ID = tb.YEAR_ID,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               THEME_ID = tb.THEME_ID,
                               THEME_CODE = tb.THEME_CODE,
                               THEME_DESC = tb.THEME_DESC,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               ACTIVITY = tb.ACTIVITY,
                               INDICATOR = tb.INDICATOR,
                               MEDIA = tb.MEDIA,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               BRANCH_ID = tb.BRANCH_ID,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               RATEA_CODE = tb.RATEA_CODE,
                               RATEA_DESC = tb.RATEA_DESC,
                               RATESE_CODE = tb.RATESE_CODE,
                               RATESE_DESC = tb.RATESE_DESC,
                               RATEB_CODE = tb.RATEB_CODE,
                               RATEB_DESC = tb.RATEB_DESC,
                               RATEK_CODE = tb.RATEK_CODE,
                               RATEK_DESC = tb.RATEK_DESC,
                               RATEMH_CODE = tb.RATEMH_CODE,
                               RATEMH_DESC = tb.RATEMH_DESC,
                               RATEMK_CODE = tb.RATEMK_CODE,
                               RATEMK_DESC = tb.RATEMK_DESC,
                               RATES_CODE = tb.RATES_CODE,
                               RATES_DESC = tb.RATES_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SkhstudentdetailVM getData(int? id = null)

        public List<SkhstudentlookupVM> getDatalist_lookup()
        {
            List<SkhstudentlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Skhstudent_infos
                           select new SkhstudentlookupVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SkhstudentlookupVM> getDatalist_lookup()
    } //End public class SkhstudentDS
} //End namespace APPBASE.Models
