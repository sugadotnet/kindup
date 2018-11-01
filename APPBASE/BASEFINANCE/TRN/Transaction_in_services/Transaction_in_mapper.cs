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
    public partial class Transaction_in_mapper
    {
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor 1
        public Transaction_in_mapper() { } //End constructor

        public Transaction_indetailVM Update_mapper(Transaction_indetailVM poViewModel, Transaction_indetailVM poModel)
        {
            Transaction_indetailVM vResult = poModel;
            try
            {
                vResult.TRN_DT = poViewModel.TRN_DT;
                vResult.MONTH1 = poViewModel.MONTH1;
                vResult.MONTH2 = poViewModel.MONTH2;
                vResult.TRN_AMOUNT = poViewModel.TRN_AMOUNT;
                vResult.TRN_DESC = poViewModel.TRN_DESC;
            } //End try
            catch (Exception e) { this.isERR = true; this.ERRMSG = "Error mapping CRUD Update: " + e.Message; } //End catch

            return vResult;
        } //End method
    } //End public class Transaction_inCRUD
} //End namespace APPBASE.Models
