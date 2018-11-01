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
    public class ClassroomteacherDS
    {
        //Constructor
        public ClassroomteacherDS() { } //End public ClassroomteacherDS
        public List<ClassroomteacherdetailVM> getDatalist(int? idClassroom = null)
        {
            List<ClassroomteacherdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classroomteacher_infos
                           select new ClassroomteacherdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               EMPLOYEE_NICKNAME = tb.EMPLOYEE_NICKNAME,
                               EMPLOYEE_SENTRA_ID = tb.EMPLOYEE_SENTRA_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC

                           };
                if (idClassroom != null) {
                    oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == idClassroom).OrderBy(fld => fld.EMPLOYEE_NAME);
                }
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClassroomteacherlistVM> getDatalist()
        public ClassroomteacherdetailVM getData(int? id = null)
        {
            ClassroomteacherdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classroomteacher_infos
                           where tb.ID == id
                           select new ClassroomteacherdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC,
                               CLASSROOM_VOLUME = tb.CLASSROOM_VOLUME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               EMPLOYEE_NICKNAME = tb.EMPLOYEE_NICKNAME,
                               EMPLOYEE_SENTRA_ID = tb.EMPLOYEE_SENTRA_ID,
                               EMPLOYEE_IMG = tb.EMPLOYEE_IMG,
                               USER_ROLE_ID = tb.USER_ROLE_ID,
                               USER_IMG = tb.USER_IMG,
                               USER_BRANCH_ID = tb.USER_BRANCH_ID,
                               USER_USERNAME = tb.USER_USERNAME,
                               USER_DISPLAY_NAME = tb.USER_DISPLAY_NAME,
                               USER_EMAIL = tb.USER_EMAIL,
                               USER_BRANCH_TYPE = tb.USER_BRANCH_TYPE,
                               USER_BRANCH_DESC = tb.USER_BRANCH_DESC,
                               EMPLOYEE_SENTRA_CODE = tb.EMPLOYEE_SENTRA_CODE,
                               EMPLOYEE_SENTRA_NAME = tb.EMPLOYEE_SENTRA_NAME,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ClassroomteacherdetailVM getData(int? id = null)


        public List<ClassroomteacherdetailVM> getDatalist_lookup()
        {
            List<ClassroomteacherdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classroomteacher_infos
                           select new ClassroomteacherdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               EMPLOYEE_NICKNAME = tb.EMPLOYEE_NICKNAME,
                               EMPLOYEE_SENTRA_ID = tb.EMPLOYEE_SENTRA_ID
                               
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClassroomteacherlookupVM> getDatalist_lookup()
    } //End public class ClassroomteacherDS
} //End namespace APPBASE.Models
