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
    public partial class Sentra_Validation
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
            ////[ID] - Unique
            //if (oDS.isExists_ID(oViewModel.ID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "ID2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.ID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

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
        private void Validate_SENTRA_NAME()
        {
            Boolean bIsvalid = true;
            //[SENTRA_NAME] - Required
            if ((oViewModel.SENTRA_NAME == "") || (oViewModel.SENTRA_NAME == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "SENTRA_NAME1";
                oMSG.VAL_ERRMSG = "Nama sentra harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[SENTRA_NAME] - Unique
            //if (oDS.isExists_SENTRA_NAME(oViewModel.SENTRA_NAME))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "SENTRA_NAME2";
            //    oMSG.VAL_ERRMSG = "SENTRA_NAME " + oViewModel.SENTRA_NAME + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[SENTRA_NAME] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "SENTRA_NAME0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_SENTRA_NAME()
    } //End public partial class Sentra_Validation
} //End namespace APPBASE.Models
