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
using APPBASE;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Skh_Validation
    {
        private SkhVM oViewModelfilter;
        private SkhdetailVM oViewModel;
        private SkhDS oDS = new SkhDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor 1
        public Skh_Validation(SkhdetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public Skh_Validation()
        //Constructor 2
        public Skh_Validation(SkhVM poViewModel)
        {
            oViewModelfilter = poViewModel;
        } //End public Skh_Validation()
        public void Validate_Create()
        {
            Validate_ACTIVITY();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            Validate_ACTIVITY();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_ACTIVITY();
        } //End public void Validate_Delete()

        public void Validate_Filter()
        {
            Validate_FILTER_YEAR_ID();
            Validate_FILTER_SEMESTER_ID();
            Validate_FILTER_CLASSTYPE_ID();
            Validate_FILTER_THEME_ID();
        } //End public void Validate_Delete()
    } //End public partial class Skh_Validation
} //End namespace APPBASE.Models

