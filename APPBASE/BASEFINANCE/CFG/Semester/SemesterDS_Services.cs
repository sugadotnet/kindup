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

namespace APPBASE.Models
{
    public partial class SemesterDS
    {
        public Byte? getData_currentSemesterID()
        {
            SysinfoDS oDSSysinfo = new SysinfoDS();
            //Semester 1 / Semeseter 2
            return getData_SemesterID(oDSSysinfo.getData().SYSDATE);
        } //End public int? getData_currentSemesterID()
        public Byte? getData_SemesterID(DateTime? pdDatetime = null)
        {
            Byte? vReturn = null;

            if (pdDatetime != null)
            {
                int nMonth = pdDatetime.Value.Month;
                //Semester 1 / Semeseter 2
                if ((nMonth >= 7) && (nMonth <= 12)) vReturn = 1; else vReturn = 2;
            } //End if (pdDatetime != null)

            return vReturn;
        } //End public int? getData_currentSemesterID()
    } //End public class SemesterDS
} //End namespace APPBASE.Models

