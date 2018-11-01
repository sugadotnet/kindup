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
    public partial class Skm_Validation
    {
        private void Validate_SKM_DESC()
        {
            Boolean bIsvalid = true;
            //[SKM_DESC] - Required
            if (oViewModel.SKM_DESC == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "SKM_DESC1";
                oMSG.VAL_ERRMSG = "SKM_DESC harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            ////[SKM_DESC] - Unique
            //if (oDS.isExists_SKM_DESC(oViewModel.SKM_DESC))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "SKM_DESC2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.SKM_DESC + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[SKM_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "SKM_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_SKM_DESC()

        private void Validate_FILTER_YEAR_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_YEAR_ID] - Required
            if (oViewModelfilter.FILTER_YEAR_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_YEAR_ID1";
                oMSG.VAL_ERRMSG = "Tahun ajaran harus dipilih";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_YEAR_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_YEAR_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_YEAR_ID()
        private void Validate_FILTER_SEMESTER_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_SEMESTER_ID] - Required
            if (oViewModelfilter.FILTER_SEMESTER_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_SEMESTER_ID1";
                oMSG.VAL_ERRMSG = "Semester harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_SEMESTER_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_SEMESTER_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_SEMESTER_ID()
        private void Validate_FILTER_CLASSTYPE_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_CLASSTYPE_ID] - Required
            if (oViewModelfilter.FILTER_CLASSTYPE_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_CLASSTYPE_ID1";
                oMSG.VAL_ERRMSG = "Kelas harus dipilih";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_CLASSTYPE_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_CLASSTYPE_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_CLASSTYPE_ID()
    } //End public partial class Skm_Validation
} //End namespace APPBASE.Models
