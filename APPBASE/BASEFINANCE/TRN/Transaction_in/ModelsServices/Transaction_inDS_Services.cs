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
    public class Transaction_inDS
    {
        private DBMAINContext db;
        //Constructor 1
        public Transaction_inDS() {
            this.db = new DBMAINContext();
        } //End public Transaction_inDS
        //Constructor 2
        public Transaction_inDS(DBMAINContext poDB)
        {
            this.db = poDB;
        } //End public Transaction_inDS
        public List<Transaction_indetailVM> getDatalist()
        {
            List<Transaction_indetailVM> vReturn;
            var oQRY = from tb in db.Transaction_in_infos
                       select new Transaction_indetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           SEMESTER_ID = tb.SEMESTER_ID,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID,
                           CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                           CLASSROOM_ID = tb.CLASSROOM_ID,
                           CLASSMAJOR_ID = tb.CLASSMAJOR_ID,
                           TRN_DT = tb.TRN_DT,
                           TRN_STS = tb.TRN_STS,
                           TRN_AMOUNT = tb.TRN_AMOUNT,
                           TRN_TERBILANG = tb.TRN_TERBILANG,
                           TRN_DESC = tb.TRN_DESC,
                           STUDENT_ID = tb.STUDENT_ID,
                           RECEIPT_NO = tb.RECEIPT_NO,
                           RECEIPT_PRINTDT = tb.RECEIPT_PRINTDT,
                           RECEIPT_PAIDBY = tb.RECEIPT_PAIDBY,
                           RECEIPT_RECEIVEDBY = tb.RECEIPT_RECEIVEDBY,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           SEMESTER_DESC = tb.SEMESTER_DESC,
                           SEMESTER_NUM = tb.SEMESTER_NUM,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<Transaction_inlistVM> getDatalist()
        public Transaction_indetailVM getData(int? id = null, int? pnCREATEBY=null)
        {
            Transaction_indetailVM oReturn;
            var oQRY = from tb in db.Transaction_in_infos
                       where tb.ID == id
                       select new Transaction_indetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           SEMESTER_ID = tb.SEMESTER_ID,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID,
                           CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                           CLASSROOM_ID = tb.CLASSROOM_ID,
                           CLASSMAJOR_ID = tb.CLASSMAJOR_ID,
                           TRN_DT = tb.TRN_DT,
                           TRN_STS = tb.TRN_STS,
                           TRN_AMOUNT = tb.TRN_AMOUNT,
                           TRN_TERBILANG = tb.TRN_TERBILANG,
                           TRN_DESC = tb.TRN_DESC,
                           STUDENT_ID = tb.STUDENT_ID,
                           RECEIPT_NO = tb.RECEIPT_NO,
                           RECEIPT_PRINTDT = tb.RECEIPT_PRINTDT,
                           RECEIPT_PAIDBY = tb.RECEIPT_PAIDBY,
                           RECEIPT_RECEIVEDBY = tb.RECEIPT_RECEIVEDBY,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           SEMESTER_DESC = tb.SEMESTER_DESC,
                           SEMESTER_NUM = tb.SEMESTER_NUM,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID
                       };
            oReturn = oQRY.SingleOrDefault();
            return oReturn;
        } //End public Transaction_indetailVM getData(int? id = null)

        public Transaction_indetailVM getData_last()
        {
            Transaction_indetailVM oReturn;
            var oQRY = from tb in db.Transaction_in_infos
                       select new Transaction_indetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           SEMESTER_ID = tb.SEMESTER_ID,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID,
                           CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                           CLASSROOM_ID = tb.CLASSROOM_ID,
                           CLASSMAJOR_ID = tb.CLASSMAJOR_ID,
                           TRN_DT = tb.TRN_DT,
                           TRN_STS = tb.TRN_STS,
                           TRN_AMOUNT = tb.TRN_AMOUNT,
                           TRN_TERBILANG = tb.TRN_TERBILANG,
                           TRN_DESC = tb.TRN_DESC,
                           STUDENT_ID = tb.STUDENT_ID,
                           RECEIPT_NO = tb.RECEIPT_NO,
                           RECEIPT_PRINTDT = tb.RECEIPT_PRINTDT,
                           RECEIPT_PAIDBY = tb.RECEIPT_PAIDBY,
                           RECEIPT_RECEIVEDBY = tb.RECEIPT_RECEIVEDBY,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           SEMESTER_DESC = tb.SEMESTER_DESC,
                           SEMESTER_NUM = tb.SEMESTER_NUM,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID
                       };
            oReturn = oQRY.OrderByDescending(fld => fld.ID).FirstOrDefault();
            return oReturn;
        } //End public Transaction_indetailVM getData_last()

        public List<Transaction_indetailVM> getDatalist_lookup()
        {
            List<Transaction_indetailVM> vReturn;
            var oQRY = from tb in db.Transaction_in_infos
                       select new Transaction_indetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           SEMESTER_ID = tb.SEMESTER_ID,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID,
                           CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                           CLASSROOM_ID = tb.CLASSROOM_ID,
                           CLASSMAJOR_ID = tb.CLASSMAJOR_ID,
                           TRN_DT = tb.TRN_DT,
                           TRN_STS = tb.TRN_STS,
                           TRN_AMOUNT = tb.TRN_AMOUNT,
                           TRN_TERBILANG = tb.TRN_TERBILANG,
                           TRN_DESC = tb.TRN_DESC,
                           STUDENT_ID = tb.STUDENT_ID,
                           RECEIPT_NO = tb.RECEIPT_NO,
                           RECEIPT_PRINTDT = tb.RECEIPT_PRINTDT,
                           RECEIPT_PAIDBY = tb.RECEIPT_PAIDBY,
                           RECEIPT_RECEIVEDBY = tb.RECEIPT_RECEIVEDBY,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           SEMESTER_DESC = tb.SEMESTER_DESC,
                           SEMESTER_NUM = tb.SEMESTER_NUM,
                           CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<Transaction_inlookupVM> getDatalist_lookup()
    } //End public class Transaction_inDS
} //End namespace APPBASE.Models
