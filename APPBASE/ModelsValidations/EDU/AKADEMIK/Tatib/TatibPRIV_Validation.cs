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
    public partial class Tatib_Validation
    {
        private void Validate_ID()
        {
            Boolean bIsvalid = true;
            //[ID] - Required
            if (oViewModel.ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ID1";
                oMSG.VAL_ERRMSG = "ID harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ID()

        private void Validate_TITLE()
        {
            Boolean bIsvalid = true;
            //[TITLE] - Required
            if ((oViewModel.TITLE == "") || (oViewModel.TITLE == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "TITLE1";
                oMSG.VAL_ERRMSG = "TITLE harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[TITLE] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "TITLE0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_TITLE()
        private void Validate_FULL_DESC()
        {
            Boolean bIsvalid = true;
            //[FULL_DESC] - Required
            if ((oViewModel.FULL_DESC == "") || (oViewModel.FULL_DESC == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FULL_DESC1";
                oMSG.VAL_ERRMSG = "Deskripsi tata tertib harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[FULL_DESC] - Minimum 10 character
            if ((oViewModel.FULL_DESC != "") && (oViewModel.FULL_DESC.Length < 10))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FULL_DESC1";
                oMSG.VAL_ERRMSG = "Deskripsi tata tertib minimmal 10 karakter";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FULL_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FULL_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FULL_DESC()
    } //End public partial class Tatib_Validation
} //End namespace APPBASE.Models
