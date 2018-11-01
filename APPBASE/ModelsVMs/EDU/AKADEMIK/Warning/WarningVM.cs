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
    public partial class WarninglistVM
    {
        public int? ID { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
    } //End public partial class WarninglistVM
    public partial class WarningdetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
        public string FULL_DESC { get; set; }
        public int? USERNAME_ID { get; set; }
        public string TEACHER_DISPLAY_NAME { get; set; }
        public string TEACHER_ROLE_DISPLAY_NAME { get; set; }
        public string TEACHER_RES_NIP { get; set; }
        public string TEACHER_RES_NAME { get; set; }
        public Byte? TEACHER_RES_JOBTITLE_ID { get; set; }
        public string TEACHER_JOBTITLE_DESC { get; set; }
        public string TEACHER_BRANCH_DESC { get; set; }
        public Byte? TIMELINE_TYPE { get; set; }
        public int? SHARED_GROUP { get; set; }
        public int? SHARED_PRIVATE { get; set; }
    } //End public partial class WarningdetailVM
    public partial class WarninghiddenVM
    {
        public int? TIMELINE_ID { get; set; }
        public Byte? TIMELINE_TYPE { get; set; }
        public int? SHARED_GROUP { get; set; }
    } //End public partial class WarninghiddenVM

    public partial class WarninglookupVM
    {
        public int? ID { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
    } //End public partial class WarninglistVM

} //End namespace APPBASE.Models
