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
    public class PromisedDS
    {
        //Constructor
        public PromisedDS() { } //End public PromisedDS
        public List<PromisedlistitemVM> getDatalist(PromisedVM poViewModel = null)
        {
            List<PromisedlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Promised_infos
                           select new PromisedlistitemVM
                           {
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               ID = tb.ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               THEME_ID = tb.THEME_ID,
                               THEME_DESC = tb.THEME_DESC,
                               SUBTHEME = tb.SUBTHEME
                           };
                if (poViewModel != null) {
                    if (poViewModel.FILTER_YEAR_ID != null) {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null) {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null) {
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
        } //End public List<PromisedlistVM> getDatalist()
        public PromiseddetailVM getData(int? id = null)
        {
            PromiseddetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Promised_infos
                           where tb.ID == id
                           select new PromiseddetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               WEEKNUM = tb.WEEKNUM,
                               DATEFROM = tb.DATEFROM,
                               DATETO = tb.DATETO,
                               THEME_ID = tb.THEME_ID,
                               DALIL = tb.DALIL,
                               SUBTHEME = tb.SUBTHEME,
                               PROM_DESC = tb.PROM_DESC,
                               PROM_VOCAB = tb.PROM_VOCAB,
                               PROM_VALUE = tb.PROM_VALUE,
                               PROM_PILAR = tb.PROM_PILAR,
                               PROM_MA = tb.PROM_MA,
                               PROM_SE = tb.PROM_SE,
                               PROM_DOA = tb.PROM_DOA,
                               PROM_BACAAN = tb.PROM_BACAAN,
                               PROM_SONG = tb.PROM_SONG,
                               PROM_LANG = tb.PROM_LANG,
                               PROM_WRITING = tb.PROM_WRITING,
                               PROM_MATH = tb.PROM_MATH,
                               PROM_ARTH = tb.PROM_ARTH,
                               PROM_BALOK = tb.PROM_BALOK,
                               PROM_SCIENCE = tb.PROM_SCIENCE,
                               PROM_ISLAMIC = tb.PROM_ISLAMIC,
                               PROM_GROSSM = tb.PROM_GROSSM,
                               PROM_SHAPE = tb.PROM_SHAPE,
                               PROM_COLOR = tb.PROM_COLOR,
                               PROM_NUMBER = tb.PROM_NUMBER,
                               PROM_ASMAULHUSNA = tb.PROM_ASMAULHUSNA,
                               PROM_KTHOYYIBAH = tb.PROM_KTHOYYIBAH,
                               PROM_LANGARAB = tb.PROM_LANGARAB,
                               PROM_HURUFA = tb.PROM_HURUFA,
                               PROM_ANGKAA = tb.PROM_ANGKAA,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               THEME_CODE = tb.THEME_CODE,
                               THEME_DESC = tb.THEME_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public PromiseddetailVM getData(int? id = null)


        public List<PromisedlookupVM> getDatalist_lookup()
        {
            List<PromisedlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Promised_infos
                           select new PromisedlookupVM
                           {
                               ID = tb.ID,
                               THEME_DESC = tb.THEME_DESC,
                               SUBTHEME = tb.SUBTHEME
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<PromisedlookupVM> getDatalist_lookup()
    } //End public class PromisedDS
} //End namespace APPBASE.Models

