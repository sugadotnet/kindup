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
    public partial class ClasstypelistVM {
        public int? ID { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
    } //End public partial class ClasstypelistVM
    public partial class ClasstypedetailVM
    {
        public int? ID { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
    } //End public partial class ClasstypedetailVM

    public partial class ClasstypelookupVM
    {
        public int? ID { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
    } //End public partial class ClasstypelistVM

} //End namespace APPBASE.Models
