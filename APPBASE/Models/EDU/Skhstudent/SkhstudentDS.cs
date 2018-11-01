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
    [Table("VWEDU01SKH_STUDENT_INFO")]
    public partial class Skhstudent_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? SKH_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public string RESULT_DESC { get; set; }
        public string RESULT_FEEDBACK { get; set; }
        public int? RATEA_ID { get; set; }
        public int? RATESE_ID { get; set; }
        public int? RATEB_ID { get; set; }
        public int? RATEK_ID { get; set; }
        public int? RATEMH_ID { get; set; }
        public int? RATEMK_ID { get; set; }
        public int? RATES_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public int? THEME_ID { get; set; }
        public string THEME_CODE { get; set; }
        public string THEME_DESC { get; set; }
        public Byte? WEEKNUM { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string ACTIVITY { get; set; }
        public string INDICATOR { get; set; }
        public string MEDIA { get; set; }
        public string NAME { get; set; }
        public string NICKNAME { get; set; }
        public string NIS { get; set; }
        public string NISN { get; set; }
        public string PINREG { get; set; }
        public string REGNO { get; set; }
        public DateTime? REG_DT { get; set; }
        public int? BRANCH_ID { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string RATEA_CODE { get; set; }
        public string RATEA_DESC { get; set; }
        public string RATESE_CODE { get; set; }
        public string RATESE_DESC { get; set; }
        public string RATEB_CODE { get; set; }
        public string RATEB_DESC { get; set; }
        public string RATEK_CODE { get; set; }
        public string RATEK_DESC { get; set; }
        public string RATEMH_CODE { get; set; }
        public string RATEMH_DESC { get; set; }
        public string RATEMK_CODE { get; set; }
        public string RATEMK_DESC { get; set; }
        public string RATES_CODE { get; set; }
        public string RATES_DESC { get; set; }
    } //End public partial class Skhstudent_info
} //End namespace APPBASE.Models

