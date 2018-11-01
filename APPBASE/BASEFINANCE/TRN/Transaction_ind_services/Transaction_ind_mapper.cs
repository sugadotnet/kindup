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
    public class Transaction_ind_mapper
    {
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        private DBMAINContext db;
        private Transaction_indetailVM oModel;
        protected Transaction_inddetailVM oViewModel;

        //Constructor 1
        public Transaction_ind_mapper() { } //End constructor

        public Transaction_inddetailVM Update_mapper(Transaction_indetailVM poViewModel, Transaction_inddetailVM poViewModel_detail)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            Transaction_inddetailVM vResult = poViewModel_detail;
            try
            {
                //Actual
                vResult.TRND_PRICE = oViewModel.TRN_AMOUNT;
                vResult.TRND_AMOUNT = oViewModel.TRN_AMOUNT;
                //Base
                vResult.TRND_PRICEBASE = oViewModel.TRN_AMOUNT;
                vResult.TRND_AMOUNTBASE = oViewModel.TRN_AMOUNT;
                vResult.TRND_QTYBASE = vResult.TRND_QTY;
                vResult.TRND_DESC = oViewModel.TRN_DESC;
            } //End try
            catch (Exception e) { this.isERR = true; this.ERRMSG = "Error mapping CRUD Update: " + e.Message; } //End catch

            return vResult;
        } //End method

    } //End public class Transaction_indCRUD
} //End namespace APPBASE.Models
