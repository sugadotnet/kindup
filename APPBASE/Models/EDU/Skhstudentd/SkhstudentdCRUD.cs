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
    [Table("EDU01SKH_STUDENTD")]
    public partial class Skhstudentd : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? STUDENTSKH_ID { get; set; }
        public int? EVALUATION_ID { get; set; }
        public int? RATE_ID { get; set; }
    } //End public partial class Skhstudentd : CRUD
} //End namespace APPBASE.Models

