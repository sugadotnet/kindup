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
    //public partial class SonglistVM
    //{
    //    public int? ID { get; set; }
    //} //End public partial class SonglistVM

    public partial class SongdetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
    } //End public partial class SongdetailVM

    //public partial class SonglookupVM
    //{
    //    public int? ID { get; set; }
    //} //End public partial class SonglistVM

} //End namespace APPBASE.Models
