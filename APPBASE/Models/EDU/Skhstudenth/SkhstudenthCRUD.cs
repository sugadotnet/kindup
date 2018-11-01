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
    [Table("EDU01SKH_STUDENTH")]
    public partial class Skhstudenth : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? SKH_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public string RESULT_DESC { get; set; }
        public string RESULT_FEEDBACK { get; set; }
    } //End public partial class Skhstudenth : CRUD
} //End namespace APPBASE.Models
