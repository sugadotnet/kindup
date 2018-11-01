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
    public partial class Skhstudenth_Validation
    {
        private void Validate_RESULT_DESC()
        {
            Boolean bIsvalid = true;
            //[RESULT_DESC] - Required
            if (oViewModel.RESULT_DESC == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RESULT_DESC1";
                oMSG.VAL_ERRMSG = "RESULT_DESC harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            ////[RESULT_DESC] - Unique
            //if (oDS.isExists_RESULT_DESC(oViewModel.RESULT_DESC))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "RESULT_DESC2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.RESULT_DESC + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[RESULT_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RESULT_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RESULT_DESC()
    } //End public partial class Skhstudenth_Validation
} //End namespace APPBASE.Models
