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
    public partial class SentralistVM
    {
        public int? ID { get; set; }
        public string SENTRA_CODE { get; set; }
        public string SENTRA_NAME { get; set; }
    } //End public partial class SentralistVM
    public partial class SentradetailVM
    {
        public int? ID { get; set; }
        public string SENTRA_CODE { get; set; }
        public string SENTRA_NAME { get; set; }
        public string SENTRA_DESC { get; set; }
        public Byte? SENTRA_VOLUME { get; set; }
    } //End public partial class SentradetailVM

    public partial class SentralookupVM
    {
        public int? ID { get; set; }
        public string SENTRA_CODE { get; set; }
        public string SENTRA_NAME { get; set; }
    } //End public partial class SentralistVM

} //End namespace APPBASE.Models

