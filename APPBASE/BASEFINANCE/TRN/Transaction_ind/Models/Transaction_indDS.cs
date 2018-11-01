﻿using System;
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
    [Table("VWEDU01TRN_IND_INFO")]
    public partial class Transaction_ind_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? TRND_METHODID { get; set; }
        public int? TRND_TYPEID { get; set; }
        public int? TRND_SUBTYPEID { get; set; }
        public int? TRND_ITEMTYPEID { get; set; }
        public int? TRND_ITEMID { get; set; }
        public decimal? TRND_QTY { get; set; }
        public decimal? TRND_PRICE { get; set; }
        public decimal? TRND_AMOUNT { get; set; }
        public decimal? TRND_PRICEBASE { get; set; }
        public decimal? TRND_QTYBASE { get; set; }
        public decimal? TRND_AMOUNTBASE { get; set; }
        public string TRND_DESC { get; set; }
        public int? TRN_ID { get; set; }
        public int? INST_ID { get; set; }
        public int? INSTD_ID { get; set; }
        public int? INSTD_SEQNO { get; set; }
        public string TRINMETHOD_CODE { get; set; }
        public string TRINMETHOD_SHORTDESC { get; set; }
        public string TRINMETHOD_DESC { get; set; }
        public string TRINTYPE_CODE { get; set; }
        public string TRINTYPE_SHORTDESC { get; set; }
        public string TRINTYPE_DESC { get; set; }
        public string TRINSUBTYPE_CODE { get; set; }
        public string TRINSUBTYPE_SHORTDESC { get; set; }
        public string TRINSUBTYPE_DESC { get; set; }
        public string ITEMTYPE_CODE { get; set; }
        public string ITEMTYPE_SHORTDESC { get; set; }
        public string ITEMTYPE_DESC { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_SHORTDESC { get; set; }
        public string ITEM_DESC { get; set; }
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
        public string CLASSTYPE_DESC { get; set; }
        public string CLASSROOM_DESC { get; set; }
        public string STUDENT_NAME { get; set; }
        public string STUDENT_NICKNAME { get; set; }
        public string STUDENT_NIS { get; set; }
        public string STUDENT_NISN { get; set; }
        public Byte? STUDENT_CLASSTYPE_ID { get; set; }
        public int? STUDENT_CLASSROOM_ID { get; set; }
        public DateTime? INST_DT { get; set; }
        public Byte? INST_STS { get; set; }
        public DateTime? INST_STARTDT { get; set; }
        public DateTime? INST_ENDDT { get; set; }
        public Byte? INST_TYPEID { get; set; }
        public Byte? INST_SUBTYPEID { get; set; }
        public decimal? INST_QTYBASE { get; set; }
        public decimal? INST_PRICEBASE { get; set; }
        public decimal? INST_AMOUNTBASE { get; set; }
        public decimal? INST_QTY { get; set; }
        public decimal? INST_AMOUNT { get; set; }
        public string INST_DESC { get; set; }
        public string INST_CACHE_YEAR_CODE { get; set; }
        public string INST_CACHE_YEAR_SHORTDESC { get; set; }
        public string INST_CACHE_YEAR_DESC { get; set; }
        public DateTime? INST_CACHE_YEAR_FROM { get; set; }
        public DateTime? INST_CACHE_YEAR_TO { get; set; }
    } //End public partial class Transaction_ind_info
} //End namespace APPBASE.Models
