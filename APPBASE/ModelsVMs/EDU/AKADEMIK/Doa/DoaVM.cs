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
    //public partial class DoalistVM
    //{
    //    public int? ID { get; set; }
    //} //End public partial class DoalistVM

    public partial class DoadetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
    } //End public partial class DoadetailVM

    //public partial class DoalookupVM
    //{
    //    public int? ID { get; set; }
    //} //End public partial class DoalistVM

} //End namespace APPBASE.Models

