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
    [Table("EDU01LHSTUDENT")]
    public partial class LHStudent : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? SENTRA_ID { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public DateTime? LH_DT { get; set; }
        public string LH_NOTES { get; set; }
        public string LH_COMMENTS { get; set; }
        public Byte? MOOD_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
        public int? ABSENSI_HADIR { get; set; }
        public DateTime? ABSENSI_IN { get; set; }
        public DateTime? ABSENSI_OUT { get; set; }
    } //End public partial class LHStudent : CRUD
} //End namespace APPBASE.Models

