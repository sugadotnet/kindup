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
    [Table("EDU01CFG_SENTRA")]
    public partial class Sentra : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public string SENTRA_CODE { get; set; }
        public string SENTRA_NAME { get; set; }
        public string SENTRA_DESC { get; set; }
        public Byte? SENTRA_VOLUME { get; set; }
    } //End public partial class Sentra : CRUD
} //End namespace APPBASE.Models
