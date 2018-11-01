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
    [Table("EDU01PROMISED")]
    public partial class Promised : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public Byte? WEEKNUM { get; set; }
        public DateTime? DATEFROM { get; set; }
        public DateTime? DATETO { get; set; }
        public int? THEME_ID { get; set; }
        public string DALIL { get; set; }
        public string SUBTHEME { get; set; }
        public string PROM_DESC { get; set; }
        public string PROM_VOCAB { get; set; }
        public string PROM_VALUE { get; set; }
        public string PROM_PILAR { get; set; }
        public string PROM_MA { get; set; }
        public string PROM_SE { get; set; }
        public string PROM_DOA { get; set; }
        public string PROM_BACAAN { get; set; }
        public string PROM_SONG { get; set; }
        public string PROM_LANG { get; set; }
        public string PROM_WRITING { get; set; }
        public string PROM_MATH { get; set; }
        public string PROM_ARTH { get; set; }
        public string PROM_BALOK { get; set; }
        public string PROM_SCIENCE { get; set; }
        public string PROM_ISLAMIC { get; set; }
        public string PROM_GROSSM { get; set; }
        public string PROM_SHAPE { get; set; }
        public string PROM_COLOR { get; set; }
        public string PROM_NUMBER { get; set; }
        public string PROM_ASMAULHUSNA { get; set; }
        public string PROM_KTHOYYIBAH { get; set; }
        public string PROM_LANGARAB { get; set; }
        public string PROM_HURUFA { get; set; }
        public string PROM_ANGKAA { get; set; }
    } //End public partial class Promised : CRUD
} //End namespace APPBASE.Models

