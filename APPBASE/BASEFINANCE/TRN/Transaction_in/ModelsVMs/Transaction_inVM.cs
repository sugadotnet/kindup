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
    public partial class Transaction_indetailVM {
        public List<StudentdetailVM> STUDENTS;
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public int? SEMESTER_ID { get; set; }
        public int? CLASSTYPE_ID { get; set; }
        public int? CLASSLEVEL_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? CLASSMAJOR_ID { get; set; }
        public DateTime? TRN_DT { get; set; }
        public Byte? TRN_STS { get; set; }
        public decimal? TRN_AMOUNT { get; set; }
        public string TRN_TERBILANG { get; set; }
        public string TRN_DESC { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? RECEIPT_NO { get; set; }
        public DateTime? RECEIPT_PRINTDT { get; set; }
        public string RECEIPT_PAIDBY { get; set; }
        public string RECEIPT_RECEIVEDBY { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_NAME { get; set; }
        public string CLASSROOM_DESC { get; set; }
        public string STUDENT_NAME { get; set; }
        public string STUDENT_NICKNAME { get; set; }
        public string STUDENT_NIS { get; set; }
        public string STUDENT_NISN { get; set; }
        public Byte? STUDENT_CLASSTYPE_ID { get; set; }
        public int? STUDENT_CLASSROOM_ID { get; set; }

        //EXTRA CUSTOM-YEARS
        public List<YearlistVM> YEARS { get; set; }
        //EXTRA CUSTOM-MONTHS
        public List<MonthsppVM> MONTHS { get; set; }
        public Byte? MONTH1 { get; set; } //EXTRA CUSTOM-SPP
        public string MONTH1_SHORTDESC { get; set; }
        public Byte? MONTH2 { get; set; } //EXTRA CUSTOM-SPP
        public string MONTH2_SHORTDESC { get; set; }

        //CUSTOM
        public string TRN_AMOUNT_S { get; set; }
        //STUDENT-CUSTOM
        public string PINREG { get; set; }
        public string REGNO { get; set; }
        public DateTime? REG_DT { get; set; }
        //PATCH
        public string STUDENT_IMG { get; set; }
        //Relation-TRANSACTIN
        public List<Transaction_inddetailVM> DETAIL { get; set; }
        //Relation-TRANSACTIN HISTORY
        public List<Transaction_inddetailVM> HIST { get; set; }
        //EXTRA CUSTOM
        public int? ActionID { get; set; }
        public DateTime? SYSDATE { get; set; }
        //EXTRA CUSTOM-TRINTYPE
        public int? TRINTYPE_ID { get; set; }
        public string TRINTYPE_CODE { get; set; }
        public string TRINTYPE_SHORTDESC { get; set; }
        public string TRINTYPE_DESC { get; set; }
        //EXTRA CUSTOM-TRINMETHOD
        public int? TRINMETHOD_ID { get; set; }
        public string TRINMETHOD_CODE { get; set; }
        public string TRINMETHOD_SHORTDESC { get; set; }
        public string TRINMETHOD_DESC { get; set; }

        //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
        public decimal? TRND_PRICEBASE { get; set; }
        public decimal? TRND_QTYBASE { get; set; }
        public decimal? TRND_AMOUNTBASE { get; set; }
        public string TRND_AMOUNTBASE_S { get; set; }

        //METHOD
        public void InjectFromStudentVM(StudentdetailVM poViewModel)
        {
            this.STUDENT_NAME = poViewModel.NAME;
            this.STUDENT_NICKNAME = poViewModel.NICKNAME;
            this.STUDENT_NIS = poViewModel.NIS;
            this.STUDENT_NISN = poViewModel.NISN;

            //ALTERED
            //this.IS_PINDAHAN = poViewModel.IS_PINDAHAN;
            //this.SPP_AMOUNT = poViewModel.SPP_AMOUNT;

            //Custom
            this.STUDENT_IMG = poViewModel.STUDENT_IMG;
            this.STUDENT_CLASSTYPE_ID = poViewModel.CLASSTYPE_ID;
            //this.STUDENT_CLASSTYPE_CODE = poViewModel.CLASSTYPE_CODE;
            //this.STUDENT_CLASSTYPE_SHORTDESC = poViewModel.CLASSTYPE_SHORTDESC;
            this.STUDENT_CLASSROOM_ID = poViewModel.CLASSROOM_ID;
            //this.STUDENT_CLASSROOM_CODE = poViewModel.CLASSROOM_CODE;
            //this.STUDENT_CLASSROOM_SHORTDESC = poViewModel.CLASSROOM_SHORTDESC;
            //this.STUDENT_CLASSLEVEL_ID = poViewModel.CLASSLEVEL_ID;
            //this.STUDENT_CLASSLEVEL_CODE = poViewModel.CLASSLEVEL_CODE;
            //this.STUDENT_CLASSLEVEL_SHORTDESC = poViewModel.CLASSLEVEL_SHORTDESC;
            //this.STUDENT_CLASSLEVEL_NUM = poViewModel.CLASSLEVEL_NUM;
        } //End public void InjectFromStudentVM(StudentdetailVM poViewModel)
        public void InjectFromYearVM(YeardetailVM poViewModel)
        {
            this.YEAR_ID = poViewModel.ID;
            //this.YEAR_CODE = poViewModel.YEAR_CODE;
            //this.YEAR_SHORTDESC = poViewModel.YEAR_SHORTDESC;
            this.YEAR_DESC = poViewModel.YEAR_DESC;
            this.YEAR_FROM = poViewModel.YEAR_FROM;
            this.YEAR_TO = poViewModel.YEAR_TO;
        } //End public void InjectFromYearVM(YeardetailVM poViewModel)
        public void InjectReceipt()
        {
            this.RECEIPT_RECEIVEDBY = hlpConfig.SessionInfo.getAppUserdisplayname();
        } //End public void InjectReceipt()
        public string getTRN_DT()
        {
            if (this.TRN_DT!=null)
            return hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.TRN_DT);

            return hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.SYSDATE);
        } //End public string getSYSDATE()
        public string getSYSDATE()
        {
            //return hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(new SysinfoDS().getSYSDATE()); ;
            return hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.SYSDATE);
        } //End public string getSYSDATE()
        public void setSYSDATE()
        {
            this.SYSDATE = new SysinfoDS().getSYSDATE();
        } //End public void setSYSDATE()
    } //End public partial class Transaction_indetailVM
} //End namespace APPBASE.Models
