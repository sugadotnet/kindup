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
    public partial class PaymentVM : FilterdataVM
    {
        public List<Monthly_paymentVM> MONTHLY_LIST { get; set; }
    } //End class
    public partial class Monthly_paymentVM
    {
        public StudentlistitemVM STUDENT { get; set; }
        public List<MonthsppVM> MONTHS { get; set; }
    } //End class
} //End namespace APPBASE.Models
