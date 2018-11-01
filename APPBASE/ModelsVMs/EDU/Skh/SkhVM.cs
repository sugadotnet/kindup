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
    public partial class SkhVM : FilterdataVM
    {
        public List<SkhlistitemVM> LIST { get; set; }
        public SkhdetailVM DETAIL { get; set; }
    } //End public partial class SkhlistVM
    public partial class SkhlistitemVM
    {
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public Byte? WEEKNUM { get; set; }
        public DateTime? DATEFROM { get; set; }
        public int? THEME_ID { get; set; }

        public int? ID { get; set; }
        public string ACTIVITY { get; set; }
        public string INDICATOR { get; set; }
        public string MEDIA { get; set; }
    } //End public partial class SkhlistVM
    public partial class SkhdetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public int? THEME_ID { get; set; }
        public Byte? WEEKNUM { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string ACTIVITY { get; set; }
        public string INDICATOR { get; set; }
        public string MEDIA { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public string THEME_CODE { get; set; }
        public string THEME_DESC { get; set; }
    } //End public partial class SkhdetailVM

    public partial class SkhlookupVM
    {
        public int? ID { get; set; }
        public string ACTIVITY { get; set; }
        public string INDICATOR { get; set; }
        public string MEDIA { get; set; }
    } //End public partial class SkhlistVM

} //End namespace APPBASE.Models
