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
    [Table("VWEDU01CLASSROOM_TEACHER_INFO")]
    public partial class Classroomteacher_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_NAME { get; set; }
        public string CLASSROOM_DESC { get; set; }
        public Byte? CLASSROOM_VOLUME { get; set; }
        public string EMPLOYEE_NIP { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_NICKNAME { get; set; }
        public int? EMPLOYEE_SENTRA_ID { get; set; }
        public string EMPLOYEE_IMG { get; set; }
        public int? USER_ROLE_ID { get; set; }
        public string USER_IMG { get; set; }
        public int? USER_BRANCH_ID { get; set; }
        public string USER_USERNAME { get; set; }
        public string USER_DISPLAY_NAME { get; set; }
        public string USER_EMAIL { get; set; }
        public Byte? USER_BRANCH_TYPE { get; set; }
        public string USER_BRANCH_DESC { get; set; }
        public string EMPLOYEE_SENTRA_CODE { get; set; }
        public string EMPLOYEE_SENTRA_NAME { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
    } //End public partial class Classroomteacher_info
} //End namespace APPBASE.Models
