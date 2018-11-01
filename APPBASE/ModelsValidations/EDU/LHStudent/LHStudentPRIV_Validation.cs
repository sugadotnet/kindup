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
        private void Validate_ID()
        {
            Boolean bIsvalid = true;

            ////[ID] - Required
            //if (oViewModel.ID == null)
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "ID1";
            //    oMSG.VAL_ERRMSG = "ID harus diisi";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[ID] - Unique
            if (oDS.getData_ID(oViewModel.EMPLOYEE_ID, oViewModel.STUDENT_ID, oViewModel.LH_DT)!=null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ID1";
                oMSG.VAL_ERRMSG = "Laporan tanggal " + hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oViewModel.LH_DT) + " sudah pernah diinput";
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

        private void Validate_LH_DT()
        {
            Boolean bIsvalid = true;
            //[LH_DT] - Required
            if (oViewModel.LH_DT == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LH_DT1";
                oMSG.VAL_ERRMSG = "Tanggal Laporan Harian harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[LH_DT] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LH_DT0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_LH_DT()

        private void Validate_LH_NOTES()
        {
            Boolean bIsvalid = true;
            //[LH_NOTES] - Required
            if ((oViewModel.LH_NOTES == "") || (oViewModel.LH_NOTES == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LH_NOTES1";
                oMSG.VAL_ERRMSG = "Catatan guru harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[LH_NOTES] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LH_NOTES0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_LH_NOTES()

        private void Validate_MOOD_ID()
        {
            Boolean bIsvalid = true;
            //[MOOD_ID] - Required
            if ((oViewModel.MOOD_ID == 0) || (oViewModel.MOOD_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "MOOD_ID1";
                oMSG.VAL_ERRMSG = "Mood of the day harus dipili";
                aValidationMSG.Add(oMSG);
            } //End if

            //[MOOD_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "MOOD_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_MOOD_ID()

        private void Validate_ABSENSI_HADIR()
        {
            Boolean bIsvalid = true;
            //[ABSENSI_HADIR] - Required
            if ((oViewModel.ABSENSI_HADIR == 0) || (oViewModel.ABSENSI_HADIR == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ABSENSI_HADIR1";
                oMSG.VAL_ERRMSG = "Absensi harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[ABSENSI_HADIR] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ABSENSI_HADIR0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ABSENSI_HADIR()
    } //End public partial class LHStudent_Validation
} //End namespace APPBASE.Models
