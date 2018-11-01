﻿using System;
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
    [Table("VMEDU01SUGGEST_INFO")]
    public partial class Suggest_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public string TITLE { get; set; }
        public string SHORT_DESC { get; set; }
        public string FULL_DESC { get; set; }
        public string SHORT_FEEDBACK { get; set; }
        public string FULL_FEEDBACK { get; set; }
        public string PARENT_DISPLAY_NAME { get; set; }
        public string PARENT_ROLE_DISPLAY_NAME { get; set; }
        public string PARENT_RES_NIS { get; set; }
        public string PARENT_RES_NAME { get; set; }
        public Byte? PARENT_RES_CLASSTYPE_ID { get; set; }
        public string PARENT_RES_CLASSTYPE_DESC { get; set; }
        public string HQ_DISPLAY_NAME { get; set; }
        public string HQ_ROLE_DISPLAY_NAME { get; set; }
        public string HQ_RES_NIP { get; set; }
        public string HQ_RES_NAME { get; set; }
        public Byte? HQ_RES_JOBTITLE_ID { get; set; }
        public string HQ_JOBTITLE_DESC { get; set; }
        public string HQ_BRANCH_DESC { get; set; }
    } //End public partial class Suggest_info
} //End namespace APPBASE.Models
