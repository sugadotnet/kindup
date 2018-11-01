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
    public class Transaction_indDS
    {
        private DBMAINContext db;
        //Constructor 1
        public Transaction_indDS() {
            this.db = new DBMAINContext();
        } //End Constructor
        //Constructor 2
        public Transaction_indDS(DBMAINContext poDB)
        {
            this.db = poDB;
        } //End Constructor

        public List<Transaction_inddetailVM> getDatalist()
        {
            List<Transaction_inddetailVM> vReturn;
            var oQRY = from tb in this.db.Transaction_ind_infos
                       select new Transaction_inddetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TRND_METHODID = tb.TRND_METHODID,
                           TRND_TYPEID = tb.TRND_TYPEID,
                           TRND_SUBTYPEID = tb.TRND_SUBTYPEID,
                           TRND_ITEMTYPEID = tb.TRND_ITEMTYPEID,
                           TRND_ITEMID = tb.TRND_ITEMID,
                           TRND_QTY = tb.TRND_QTY,
                           TRND_PRICE = tb.TRND_PRICE,
                           TRND_AMOUNT = tb.TRND_AMOUNT,
                           TRND_PRICEBASE = tb.TRND_PRICEBASE,
                           TRND_QTYBASE = tb.TRND_QTYBASE,
                           TRND_AMOUNTBASE = tb.TRND_AMOUNTBASE,
                           TRND_DESC = tb.TRND_DESC,
                           TRN_ID = tb.TRN_ID,
                           INST_ID = tb.INST_ID,
                           INSTD_ID = tb.INSTD_ID,
                           INSTD_SEQNO = tb.INSTD_SEQNO,
                           TRINMETHOD_CODE = tb.TRINMETHOD_CODE,
                           TRINMETHOD_SHORTDESC = tb.TRINMETHOD_SHORTDESC,
                           TRINMETHOD_DESC = tb.TRINMETHOD_DESC,
                           TRINTYPE_CODE = tb.TRINTYPE_CODE,
                           TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                           TRINTYPE_DESC = tb.TRINTYPE_DESC,
                           TRINSUBTYPE_CODE = tb.TRINSUBTYPE_CODE,
                           TRINSUBTYPE_SHORTDESC = tb.TRINSUBTYPE_SHORTDESC,
                           TRINSUBTYPE_DESC = tb.TRINSUBTYPE_DESC,
                           ITEMTYPE_CODE = tb.ITEMTYPE_CODE,
                           ITEMTYPE_SHORTDESC = tb.ITEMTYPE_SHORTDESC,
                           ITEMTYPE_DESC = tb.ITEMTYPE_DESC,
                           ITEM_CODE = tb.ITEM_CODE,
                           ITEM_SHORTDESC = tb.ITEM_SHORTDESC,
                           ITEM_DESC = tb.ITEM_DESC,
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
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                           INST_DT = tb.INST_DT,
                           INST_STS = tb.INST_STS,
                           INST_STARTDT = tb.INST_STARTDT,
                           INST_ENDDT = tb.INST_ENDDT,
                           INST_TYPEID = tb.INST_TYPEID,
                           INST_SUBTYPEID = tb.INST_SUBTYPEID,
                           INST_QTYBASE = tb.INST_QTYBASE,
                           INST_PRICEBASE = tb.INST_PRICEBASE,
                           INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                           INST_QTY = tb.INST_QTY,
                           INST_AMOUNT = tb.INST_AMOUNT,
                           INST_DESC = tb.INST_DESC,
                           INST_CACHE_YEAR_CODE = tb.INST_CACHE_YEAR_CODE,
                           INST_CACHE_YEAR_SHORTDESC = tb.INST_CACHE_YEAR_SHORTDESC,
                           INST_CACHE_YEAR_DESC = tb.INST_CACHE_YEAR_DESC,
                           INST_CACHE_YEAR_FROM = tb.INST_CACHE_YEAR_FROM,
                           INST_CACHE_YEAR_TO = tb.INST_CACHE_YEAR_TO
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<Transaction_indlistVM> getDatalist()
        public Transaction_inddetailVM getData(int? id = null)
        {
            Transaction_inddetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Transaction_ind_infos
                           where tb.ID == id
                           select new Transaction_inddetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TRND_METHODID = tb.TRND_METHODID,
                               TRND_TYPEID = tb.TRND_TYPEID,
                               TRND_SUBTYPEID = tb.TRND_SUBTYPEID,
                               TRND_ITEMTYPEID = tb.TRND_ITEMTYPEID,
                               TRND_ITEMID = tb.TRND_ITEMID,
                               TRND_QTY = tb.TRND_QTY,
                               TRND_PRICE = tb.TRND_PRICE,
                               TRND_AMOUNT = tb.TRND_AMOUNT,
                               TRND_PRICEBASE = tb.TRND_PRICEBASE,
                               TRND_QTYBASE = tb.TRND_QTYBASE,
                               TRND_AMOUNTBASE = tb.TRND_AMOUNTBASE,
                               TRND_DESC = tb.TRND_DESC,
                               TRN_ID = tb.TRN_ID,
                               INST_ID = tb.INST_ID,
                               INSTD_ID = tb.INSTD_ID,
                               INSTD_SEQNO = tb.INSTD_SEQNO,
                               TRINMETHOD_CODE = tb.TRINMETHOD_CODE,
                               TRINMETHOD_SHORTDESC = tb.TRINMETHOD_SHORTDESC,
                               TRINMETHOD_DESC = tb.TRINMETHOD_DESC,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINSUBTYPE_CODE = tb.TRINSUBTYPE_CODE,
                               TRINSUBTYPE_SHORTDESC = tb.TRINSUBTYPE_SHORTDESC,
                               TRINSUBTYPE_DESC = tb.TRINSUBTYPE_DESC,
                               ITEMTYPE_CODE = tb.ITEMTYPE_CODE,
                               ITEMTYPE_SHORTDESC = tb.ITEMTYPE_SHORTDESC,
                               ITEMTYPE_DESC = tb.ITEMTYPE_DESC,
                               ITEM_CODE = tb.ITEM_CODE,
                               ITEM_SHORTDESC = tb.ITEM_SHORTDESC,
                               ITEM_DESC = tb.ITEM_DESC,
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
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NISN = tb.STUDENT_NISN,
                               STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                               STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                               INST_DT = tb.INST_DT,
                               INST_STS = tb.INST_STS,
                               INST_STARTDT = tb.INST_STARTDT,
                               INST_ENDDT = tb.INST_ENDDT,
                               INST_TYPEID = tb.INST_TYPEID,
                               INST_SUBTYPEID = tb.INST_SUBTYPEID,
                               INST_QTYBASE = tb.INST_QTYBASE,
                               INST_PRICEBASE = tb.INST_PRICEBASE,
                               INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                               INST_QTY = tb.INST_QTY,
                               INST_AMOUNT = tb.INST_AMOUNT,
                               INST_DESC = tb.INST_DESC,
                               INST_CACHE_YEAR_CODE = tb.INST_CACHE_YEAR_CODE,
                               INST_CACHE_YEAR_SHORTDESC = tb.INST_CACHE_YEAR_SHORTDESC,
                               INST_CACHE_YEAR_DESC = tb.INST_CACHE_YEAR_DESC,
                               INST_CACHE_YEAR_FROM = tb.INST_CACHE_YEAR_FROM,
                               INST_CACHE_YEAR_TO = tb.INST_CACHE_YEAR_TO
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Transaction_inddetailVM getData(int? id = null)

        public List<Transaction_inddetailVM> getDatalist_byFilter(StudentVM poViewModel = null)
        {
            List<Transaction_inddetailVM> vReturn;
            var oQRY = from tb in this.db.Transaction_ind_infos
                       select new Transaction_inddetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TRND_METHODID = tb.TRND_METHODID,
                           TRND_TYPEID = tb.TRND_TYPEID,
                           TRND_SUBTYPEID = tb.TRND_SUBTYPEID,
                           TRND_ITEMTYPEID = tb.TRND_ITEMTYPEID,
                           TRND_ITEMID = tb.TRND_ITEMID,
                           TRND_QTY = tb.TRND_QTY,
                           TRND_PRICE = tb.TRND_PRICE,
                           TRND_AMOUNT = tb.TRND_AMOUNT,
                           TRND_PRICEBASE = tb.TRND_PRICEBASE,
                           TRND_QTYBASE = tb.TRND_QTYBASE,
                           TRND_AMOUNTBASE = tb.TRND_AMOUNTBASE,
                           TRND_DESC = tb.TRND_DESC,
                           TRN_ID = tb.TRN_ID,
                           INST_ID = tb.INST_ID,
                           INSTD_ID = tb.INSTD_ID,
                           INSTD_SEQNO = tb.INSTD_SEQNO,
                           TRINMETHOD_CODE = tb.TRINMETHOD_CODE,
                           TRINMETHOD_SHORTDESC = tb.TRINMETHOD_SHORTDESC,
                           TRINMETHOD_DESC = tb.TRINMETHOD_DESC,
                           TRINTYPE_CODE = tb.TRINTYPE_CODE,
                           TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                           TRINTYPE_DESC = tb.TRINTYPE_DESC,
                           TRINSUBTYPE_CODE = tb.TRINSUBTYPE_CODE,
                           TRINSUBTYPE_SHORTDESC = tb.TRINSUBTYPE_SHORTDESC,
                           TRINSUBTYPE_DESC = tb.TRINSUBTYPE_DESC,
                           ITEMTYPE_CODE = tb.ITEMTYPE_CODE,
                           ITEMTYPE_SHORTDESC = tb.ITEMTYPE_SHORTDESC,
                           ITEMTYPE_DESC = tb.ITEMTYPE_DESC,
                           ITEM_CODE = tb.ITEM_CODE,
                           ITEM_SHORTDESC = tb.ITEM_SHORTDESC,
                           ITEM_DESC = tb.ITEM_DESC,
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
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                           INST_DT = tb.INST_DT,
                           INST_STS = tb.INST_STS,
                           INST_STARTDT = tb.INST_STARTDT,
                           INST_ENDDT = tb.INST_ENDDT,
                           INST_TYPEID = tb.INST_TYPEID,
                           INST_SUBTYPEID = tb.INST_SUBTYPEID,
                           INST_QTYBASE = tb.INST_QTYBASE,
                           INST_PRICEBASE = tb.INST_PRICEBASE,
                           INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                           INST_QTY = tb.INST_QTY,
                           INST_AMOUNT = tb.INST_AMOUNT,
                           INST_DESC = tb.INST_DESC,
                           INST_CACHE_YEAR_CODE = tb.INST_CACHE_YEAR_CODE,
                           INST_CACHE_YEAR_SHORTDESC = tb.INST_CACHE_YEAR_SHORTDESC,
                           INST_CACHE_YEAR_DESC = tb.INST_CACHE_YEAR_DESC,
                           INST_CACHE_YEAR_FROM = tb.INST_CACHE_YEAR_FROM,
                           INST_CACHE_YEAR_TO = tb.INST_CACHE_YEAR_TO
                       };

            if (poViewModel != null)
            {
                if (poViewModel.FILTER_BRANCH_ID != null)
                {
                    oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                } //End if (poViewModel.YEAR_ID != null)
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
                if (poViewModel.FILTER_CLASSTYPE_ID != null)
                {
                    oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                } //End if (poViewModel.CLASSTYPE_ID != null)
            } //End if (poViewModel != null)
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<Transaction_indlistVM> getDatalist()


        //TRN_DT
        //CLASSTYPE_ID
        //CLASSLEVEL_ID
        //CLASSROOM_ID
        //CLASSMAJOR_ID
        //STUDENT_ID
        public List<Transaction_inddetailVM> getDatalist_detail(
            int? pnTRN_ID = null, 
            DateTime? pdTRN_DT = null, int? pnCLASSTYPE_ID = null, int? pnCLASSLEVEL_ID=null,
            int? pnCLASSROOM_ID = null, int? pnCLASSMAJOR_ID = null, int? pnSTUDENT_ID=null)
        {
            List<Transaction_inddetailVM> vReturn;
            var oQRY = from tb in this.db.Transaction_ind_infos
                       select new Transaction_inddetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TRND_METHODID = tb.TRND_METHODID,
                           TRND_TYPEID = tb.TRND_TYPEID,
                           TRND_SUBTYPEID = tb.TRND_SUBTYPEID,
                           TRND_ITEMTYPEID = tb.TRND_ITEMTYPEID,
                           TRND_ITEMID = tb.TRND_ITEMID,
                           TRND_QTY = tb.TRND_QTY,
                           TRND_PRICE = tb.TRND_PRICE,
                           TRND_AMOUNT = tb.TRND_AMOUNT,
                           TRND_PRICEBASE = tb.TRND_PRICEBASE,
                           TRND_QTYBASE = tb.TRND_QTYBASE,
                           TRND_AMOUNTBASE = tb.TRND_AMOUNTBASE,
                           TRND_DESC = tb.TRND_DESC,
                           TRN_ID = tb.TRN_ID,
                           INST_ID = tb.INST_ID,
                           INSTD_ID = tb.INSTD_ID,
                           INSTD_SEQNO = tb.INSTD_SEQNO,
                           TRINMETHOD_CODE = tb.TRINMETHOD_CODE,
                           TRINMETHOD_SHORTDESC = tb.TRINMETHOD_SHORTDESC,
                           TRINMETHOD_DESC = tb.TRINMETHOD_DESC,
                           TRINTYPE_CODE = tb.TRINTYPE_CODE,
                           TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                           TRINTYPE_DESC = tb.TRINTYPE_DESC,
                           TRINSUBTYPE_CODE = tb.TRINSUBTYPE_CODE,
                           TRINSUBTYPE_SHORTDESC = tb.TRINSUBTYPE_SHORTDESC,
                           TRINSUBTYPE_DESC = tb.TRINSUBTYPE_DESC,
                           ITEMTYPE_CODE = tb.ITEMTYPE_CODE,
                           ITEMTYPE_SHORTDESC = tb.ITEMTYPE_SHORTDESC,
                           ITEMTYPE_DESC = tb.ITEMTYPE_DESC,
                           ITEM_CODE = tb.ITEM_CODE,
                           ITEM_SHORTDESC = tb.ITEM_SHORTDESC,
                           ITEM_DESC = tb.ITEM_DESC,
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
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                           INST_DT = tb.INST_DT,
                           INST_STS = tb.INST_STS,
                           INST_STARTDT = tb.INST_STARTDT,
                           INST_ENDDT = tb.INST_ENDDT,
                           INST_TYPEID = tb.INST_TYPEID,
                           INST_SUBTYPEID = tb.INST_SUBTYPEID,
                           INST_QTYBASE = tb.INST_QTYBASE,
                           INST_PRICEBASE = tb.INST_PRICEBASE,
                           INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                           INST_QTY = tb.INST_QTY,
                           INST_AMOUNT = tb.INST_AMOUNT,
                           INST_DESC = tb.INST_DESC,
                           INST_CACHE_YEAR_CODE = tb.INST_CACHE_YEAR_CODE,
                           INST_CACHE_YEAR_SHORTDESC = tb.INST_CACHE_YEAR_SHORTDESC,
                           INST_CACHE_YEAR_DESC = tb.INST_CACHE_YEAR_DESC,
                           INST_CACHE_YEAR_FROM = tb.INST_CACHE_YEAR_FROM,
                           INST_CACHE_YEAR_TO = tb.INST_CACHE_YEAR_TO
                       };
            //TRN_ID
            if (pnTRN_ID != null) oQRY = oQRY.Where(fld => fld.TRN_ID == pnTRN_ID);
            else
            {
                //TRN_DT
                if (pdTRN_DT != null) oQRY = oQRY.Where(fld => fld.TRN_DT == pdTRN_DT);
                //CLASSTYPE_ID
                if (pnCLASSTYPE_ID != null) oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == pnCLASSTYPE_ID);
                //CLASSLEVEL_ID
                if (pnCLASSLEVEL_ID != null) oQRY = oQRY.Where(fld => fld.CLASSLEVEL_ID == pnCLASSLEVEL_ID);
                //CLASSROOM_ID
                if (pnCLASSROOM_ID != null) oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == pnCLASSROOM_ID);
                //CLASSMAJOR_ID
                if (pnCLASSMAJOR_ID != null) oQRY = oQRY.Where(fld => fld.CLASSMAJOR_ID == pnCLASSMAJOR_ID);
                //STUDENT_ID
                if (pnSTUDENT_ID != null) oQRY = oQRY.Where(fld => fld.STUDENT_ID == pnSTUDENT_ID);
            } //End if (pnTRN_ID != null)

            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<Transaction_indlistVM> getDatalist()
        public List<Transaction_inddetailVM> getDatalist_detail(int? pnTRN_ID)
        {
            return this.getDatalist_detail(pnTRN_ID, null, null, null, null, null, null);
        } //End public List<Transaction_inddetailVM> getDatalist_detail(int? pnTRN_ID)
        public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT)
        {
            return this.getDatalist_detail(null, pdTRN_DT, null, null, null, null, null);
        } //End public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT)
        public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT, int? pnCLASSTYPE_ID)
        {
            return this.getDatalist_detail(null, pdTRN_DT, pnCLASSTYPE_ID, null, null, null, null);
        } //End public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT, int? pnCLASSTYPE_ID)
        public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT, int? pnCLASSTYPE_ID, int? pnSTUDENT_ID)
        {
            return this.getDatalist_detail(null, pdTRN_DT, pnCLASSTYPE_ID, null, null, null, pnSTUDENT_ID);
        } //End public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT, int? pnCLASSTYPE_ID, int? pnSTUDENT_ID)
        public List<Transaction_inddetailVM> getDatalist_detail(int? pnSTUDENT_ID, int? pnTRINTYPE_ID, DateTime? pdCACHE_YEAR_FROM, DateTime? pdCACHE_YEAR_TO)
        {
            List<Transaction_inddetailVM> vReturn = this.getDatalist_detail(null, null, null, null, null, null, pnSTUDENT_ID);
            vReturn = vReturn.Where(fld => fld.TRND_TYPEID == pnTRINTYPE_ID).ToList();
            vReturn = vReturn.Where(fld => fld.TRN_DT >= pdCACHE_YEAR_FROM && fld.TRN_DT <= pdCACHE_YEAR_TO).ToList();
            vReturn = vReturn.ToList();
            return vReturn;
        } //End public List<Transaction_inddetailVM> getDatalist_detail(DateTime? pdTRN_DT, int? pnCLASSTYPE_ID, int? pnSTUDENT_ID)

        public List<Transaction_inddetailVM>getDatalist_report(
            int? pnTRINTYPE_ID,
            int? pnYEAR_ID, DateTime? pdTRN_DT=null,
            int? pnCLASSTYPE_ID = null, int? pnCLASSROOM_ID = null) {
            List<Transaction_inddetailVM> oData = this.getDatalist();

            //TRINTYPE
            if (pnTRINTYPE_ID != null) oData = oData.Where(fld => fld.TRND_TYPEID == pnTRINTYPE_ID).ToList();
            //YEAR
            if (pnYEAR_ID != null) oData = oData.Where(fld => fld.YEAR_ID == pnYEAR_ID).ToList();
            //TRN_DATE
            if (pdTRN_DT != null) oData = oData.Where(fld => fld.TRN_DT == pdTRN_DT).ToList();
            //CLASSTYPE
            if (pnCLASSTYPE_ID != null) oData = oData.Where(fld => fld.CLASSTYPE_ID == pnCLASSTYPE_ID).ToList();
            //CLASSROOM
            if (pnCLASSROOM_ID != null) oData = oData.Where(fld => fld.CLASSROOM_ID == pnCLASSROOM_ID).ToList();

            return oData;
        } //End method
        
        public List<Transaction_inddetailVM> getDatalist_lookup()
        {
            List<Transaction_inddetailVM> vReturn;

            var oQRY = from tb in this.db.Transaction_ind_infos
                       select new Transaction_inddetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TRND_METHODID = tb.TRND_METHODID,
                           TRND_TYPEID = tb.TRND_TYPEID,
                           TRND_SUBTYPEID = tb.TRND_SUBTYPEID,
                           TRND_ITEMTYPEID = tb.TRND_ITEMTYPEID,
                           TRND_ITEMID = tb.TRND_ITEMID,
                           TRND_QTY = tb.TRND_QTY,
                           TRND_PRICE = tb.TRND_PRICE,
                           TRND_AMOUNT = tb.TRND_AMOUNT,
                           TRND_PRICEBASE = tb.TRND_PRICEBASE,
                           TRND_QTYBASE = tb.TRND_QTYBASE,
                           TRND_AMOUNTBASE = tb.TRND_AMOUNTBASE,
                           TRND_DESC = tb.TRND_DESC,
                           TRN_ID = tb.TRN_ID,
                           INST_ID = tb.INST_ID,
                           INSTD_ID = tb.INSTD_ID,
                           INSTD_SEQNO = tb.INSTD_SEQNO,
                           TRINMETHOD_CODE = tb.TRINMETHOD_CODE,
                           TRINMETHOD_SHORTDESC = tb.TRINMETHOD_SHORTDESC,
                           TRINMETHOD_DESC = tb.TRINMETHOD_DESC,
                           TRINTYPE_CODE = tb.TRINTYPE_CODE,
                           TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                           TRINTYPE_DESC = tb.TRINTYPE_DESC,
                           TRINSUBTYPE_CODE = tb.TRINSUBTYPE_CODE,
                           TRINSUBTYPE_SHORTDESC = tb.TRINSUBTYPE_SHORTDESC,
                           TRINSUBTYPE_DESC = tb.TRINSUBTYPE_DESC,
                           ITEMTYPE_CODE = tb.ITEMTYPE_CODE,
                           ITEMTYPE_SHORTDESC = tb.ITEMTYPE_SHORTDESC,
                           ITEMTYPE_DESC = tb.ITEMTYPE_DESC,
                           ITEM_CODE = tb.ITEM_CODE,
                           ITEM_SHORTDESC = tb.ITEM_SHORTDESC,
                           ITEM_DESC = tb.ITEM_DESC,
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
                           CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           STUDENT_NAME = tb.STUDENT_NAME,
                           STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                           STUDENT_NIS = tb.STUDENT_NIS,
                           STUDENT_NISN = tb.STUDENT_NISN,
                           STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                           STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                           INST_DT = tb.INST_DT,
                           INST_STS = tb.INST_STS,
                           INST_STARTDT = tb.INST_STARTDT,
                           INST_ENDDT = tb.INST_ENDDT,
                           INST_TYPEID = tb.INST_TYPEID,
                           INST_SUBTYPEID = tb.INST_SUBTYPEID,
                           INST_QTYBASE = tb.INST_QTYBASE,
                           INST_PRICEBASE = tb.INST_PRICEBASE,
                           INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                           INST_QTY = tb.INST_QTY,
                           INST_AMOUNT = tb.INST_AMOUNT,
                           INST_DESC = tb.INST_DESC,
                           INST_CACHE_YEAR_CODE = tb.INST_CACHE_YEAR_CODE,
                           INST_CACHE_YEAR_SHORTDESC = tb.INST_CACHE_YEAR_SHORTDESC,
                           INST_CACHE_YEAR_DESC = tb.INST_CACHE_YEAR_DESC,
                           INST_CACHE_YEAR_FROM = tb.INST_CACHE_YEAR_FROM,
                           INST_CACHE_YEAR_TO = tb.INST_CACHE_YEAR_TO
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<Transaction_indlookupVM> getDatalist_lookup()
    } //End public class Transaction_indDS
} //End namespace APPBASE.Models
