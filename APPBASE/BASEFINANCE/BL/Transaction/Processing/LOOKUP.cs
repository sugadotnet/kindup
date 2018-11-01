using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Transaction_inBL
    {
        //MONTH
        protected MonthsppVM _MONTH_lookup;
        public MonthsppVM MONTH_lookup { set { this.MONTH_lookup = value; } }
        //MONTH list
        protected List<MonthsppVM> _MONTH_lookuplist;
        public List<MonthsppVM> MONTH_lookuplist { set { this._MONTH_lookuplist = value; } }
    } //End Method
} //End namespace APPBASE.Models
