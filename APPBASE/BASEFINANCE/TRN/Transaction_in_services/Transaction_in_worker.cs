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
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public partial class Transaction_in_worker
    {
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor 1
        public Transaction_in_worker() { } //End Constructor
        public Transaction_indetailVM setMonthRange(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM vResult = poViewModel;
            try
            {
                //Set Bulan SPP
                if (vResult.MONTH1 == null) vResult.MONTH1 = 1;
                if (vResult.MONTH2 == null) vResult.MONTH2 = vResult.MONTH1;
                if (vResult.MONTH2 == 0) vResult.MONTH2 = vResult.MONTH1;
            } //End try
            catch (Exception e) { this.isERR = true; this.ERRMSG = "Error Service worker setMonthRange: " + e.Message; } //End catch
            return vResult;
        } //End public void Update
    } //End public class Transaction_inCRUD
} //End namespace APPBASE.Models
