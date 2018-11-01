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
    public partial class FilterdataVM
    {
        public int? FILTER_ID { get; set; }
        public int? FILTER_ACTION_TYPE { get; set; } //1=Create/2=Detail/21=Edit/22=Delete;
        public int? FILTER_SKH_ID { get; set; }
        public int? FILTER_SKHSTUDENT_ID { get; set; }

        public int? FILTER_BRANCH_ID { get; set; }
        public string FILTER_BRANCH_DESC { get; set; }

        public int? FILTER_YEAR_ID { get; set; }
        public string FILTER_YEAR_DESC { get; set; }
        public DateTime? FILTER_YEAR_FROM { get; set; }
        public DateTime? FILTER_YEAR_TO { get; set; }
        
        public Byte? FILTER_SEMESTER_ID { get; set; }
        public string FILTER_SEMESTER_DESC { get; set; }
        
        public Byte? FILTER_CLASSTYPE_ID { get; set; }
        public string FILTER_CLASSTYPE_NAME { get; set; }
        public string FILTER_CLASSTYPE_DESC { get; set; }

        public Byte? FILTER_CLASSROOM_ID { get; set; }
        public string FILTER_CLASSROOM_NAME { get; set; }
        public string FILTER_CLASSROOM_DESC { get; set; }

        public int? FILTER_SENTRA_ID { get; set; }
        public string FILTER_SENTRA_NAME { get; set; }
        public string FILTER_SENTRA_DESC { get; set; }

        public int? FILTER_THEME_ID { get; set; }
        public string FILTER_THEME_DESC { get; set; }
        public Byte? FILTER_WEEKNUM { get; set; }
        public DateTime? FILTER_DATEFROM { get; set; }
        public DateTime? FILTER_DATE { get; set; }
    } //End public partial class FilterdataVM
} //End namespace APPBASE.Models

