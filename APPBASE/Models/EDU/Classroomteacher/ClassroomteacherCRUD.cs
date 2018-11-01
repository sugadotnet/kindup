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
    [Table("EDU01CLASSROOM_TEACHER")]
    public partial class Classroomteacher : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? EMPLOYEE_ID { get; set; }
    } //End public partial class Classroomteacher : CRUD
} //End namespace APPBASE.Models
