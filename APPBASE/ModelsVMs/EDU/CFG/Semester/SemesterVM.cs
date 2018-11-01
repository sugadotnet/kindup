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
//using APPBASE.Svcapp;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class SemesterlistVM {
        public int? ID { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
    } //End public partial class SemesterlistVM
    public partial class SemesterdetailVM
    {
        public int? ID { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
    } //End public partial class SemesterdetailVM

    public partial class SemesterlookupVM
    {
        public int? ID { get; set; }
        public string SEMESTER_DESC { get; set; }
    } //End public partial class SemesterlistVM

} //End namespace APPBASE.Models
