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
    public partial class LHStudent_Validation
    {
        private LHStudentVM oViewModelfilter;
        private LHStudentdetailVM oViewModel;
        private LHStudentDS oDS = new LHStudentDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor 1
        public LHStudent_Validation(LHStudentdetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public LHStudent_Validation()
        //Constructor 2
        public LHStudent_Validation(LHStudentVM poViewModel)
        {
            oViewModelfilter = poViewModel;
            oViewModel = poViewModel.DETAIL;
        } //End public LHStudent_Validation()
        public void Validate_Create()
        {
            Validate_ID();
            Validate_LH_DT();
            Validate_LH_NOTES();
            Validate_MOOD_ID();
            Validate_ABSENSI_HADIR();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_ID();
            Validate_LH_DT();
            Validate_LH_NOTES();
            Validate_MOOD_ID();
            Validate_ABSENSI_HADIR();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_ID();
        } //End public void Validate_Delete()
        public void Validate_Filter()
        {
        } //End public void Validate_Delete()
    } //End public partial class LHStudent_Validation
} //End namespace APPBASE.Models
