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
using APPBASE;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Transaction_in_Validation
    {
        private Transaction_indetailVM oViewModel;
        private Transaction_inDS oDS;
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor 1
        public Transaction_in_Validation(Transaction_indetailVM poViewModel)
        {
            oViewModel = poViewModel;
            this.oDS = new Transaction_inDS();
        } //End public Transaction_in_Validation()
        //Constructor 2
        public Transaction_in_Validation(Transaction_indetailVM poViewModel, Transaction_inDS poDS)
        {
            oViewModel = poViewModel;
            this.oDS = poDS;
        } //End public Transaction_in_Validation()
        public void Validate_Create()
        {
            //Validate_ID();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_ID();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_ID();
        } //End public void Validate_Delete()
    } //End public partial class Transaction_in_Validation
} //End namespace APPBASE.Models
