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
    public partial class AnnouncementlistVM
    {
        public int? ID { get; set; }
        public int? YEAR_ID { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
    } //End public partial class AnnouncementlistVM
    public partial class AnnouncementdetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
        [AllowHtml]
        public string FULL_DESC { get; set; }
        public Byte? TIMELINE_TYPE { get; set; }
        public int? SHARED_GROUP { get; set; }
        public int? SHARED_PRIVATE { get; set; }
        public string YEAR_DESC { get; set; }
    } //End public partial class AnnouncementdetailVM
    public partial class AnnouncementhiddenVM
    {
        public int? TIMELINE_ID { get; set; }
        public Byte? TIMELINE_TYPE { get; set; }
        public int? SHARED_GROUP { get; set; }
    } //End public partial class AnnouncementhiddenVM

    public partial class AnnouncementlookupVM
    {
        public int? ID { get; set; }
        public int? YEAR_ID { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
    } //End public partial class AnnouncementlistVM

} //End namespace APPBASE.Models
