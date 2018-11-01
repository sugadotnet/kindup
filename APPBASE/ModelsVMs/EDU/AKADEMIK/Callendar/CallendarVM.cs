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
    public partial class CallendarlistVM
    {
        public int? ID { get; set; }
        public int? YEAR_ID { get; set; }
        public DateTime? DATEFROM { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
    } //End public partial class CallendarlistVM
    public partial class CallendardetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
        public string FULL_DESC { get; set; }
        public Byte? TIMELINE_TYPE { get; set; }
        public int? SHARED_GROUP { get; set; }
        public int? SHARED_PRIVATE { get; set; }
        public string YEAR_DESC { get; set; }
    } //End public partial class CallendardetailVM
    public partial class CallendarhiddenVM
    {
        public int? TIMELINE_ID { get; set; }
        public Byte? TIMELINE_TYPE { get; set; }
        public int? SHARED_GROUP { get; set; }
    } //End public partial class CallendardetailVM

    public partial class CallendarlookupVM
    {
        public int? ID { get; set; }
        public int? YEAR_ID { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
    } //End public partial class CallendarlistVM

} //End namespace APPBASE.Models
