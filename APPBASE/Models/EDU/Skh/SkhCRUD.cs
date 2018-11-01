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
    [Table("EDU01SKH")]
    public partial class Skh : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public Byte? WEEKNUM { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public int? THEME_ID { get; set; }
        public string ACTIVITY { get; set; }
        public string INDICATOR { get; set; }
        public string MEDIA { get; set; }
    } //End public partial class Skh : CRUD
} //End namespace APPBASE.Models
