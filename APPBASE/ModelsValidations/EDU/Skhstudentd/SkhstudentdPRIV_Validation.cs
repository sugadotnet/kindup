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
    public partial class Skhstudentd_Validation
    {
        private void Validate_EVALUATION_DESC()
        {
            Boolean bIsvalid = true;
            //[EVALUATION_DESC] - Required
            if (oViewModel.EVALUATION_DESC == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "EVALUATION_DESC1";
                oMSG.VAL_ERRMSG = "EVALUATION_DESC harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            ////[EVALUATION_DESC] - Unique
            //if (oDS.isExists_EVALUATION_DESC(oViewModel.EVALUATION_DESC))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "EVALUATION_DESC2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.EVALUATION_DESC + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[EVALUATION_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "EVALUATION_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_EVALUATION_DESC()
    } //End public partial class Skhstudentd_Validation
} //End namespace APPBASE.Models
