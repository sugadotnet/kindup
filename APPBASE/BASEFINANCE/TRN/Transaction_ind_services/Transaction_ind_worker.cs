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
    public class Transaction_ind_worker
    {
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }
        protected Transaction_inddetailVM oViewModel;
        protected Transaction_indetailVM oViewModel_header;

        //Constructor 1
        public Transaction_ind_worker() { } //End Constructor
        public Transaction_inddetailVM setMonthRange(Transaction_indetailVM poViewModel, Transaction_inddetailVM poViewModel_detail)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            Transaction_inddetailVM vResult = poViewModel_detail;
            try
            {
                vResult.TRND_ITEMID = oViewModel.MONTH1;
                vResult.TRND_QTY = (oViewModel.MONTH2 - oViewModel.MONTH1) + 1;
            } //End try
            catch (Exception e) { this.isERR = true; this.ERRMSG = "Error service worker setMonthRange: " + e.Message; } //End catch
            return vResult;
        } //End public void Update
    } //End public class Transaction_indCRUD
} //End namespace APPBASE.Models
