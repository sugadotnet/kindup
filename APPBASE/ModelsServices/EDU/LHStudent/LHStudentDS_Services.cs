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
    public class LHStudentDS
    {
        //Constructor
        public LHStudentDS() { } //End public LHStudentDS
        public List<LHStudentdetailVM> getDatalist(int? idStudent = null, DateTime? idDate = null)
        {
            List<LHStudentdetailVM> vReturn = getDatalist_base(idStudent, null, null, idDate);

            vReturn = vReturn.OrderByDescending(fld => fld.LH_DT).ToList();

            return vReturn;
        } //End public List<LHStudentlistVM> getDatalist()
        public List<LHStudentdetailVM> getDatalist_report(LHStudentVM poViewModel)
        {
            List<LHStudentdetailVM> vReturn = getDatalist_base(null, poViewModel.FILTER_CLASSTYPE_ID, poViewModel.FILTER_CLASSROOM_ID, poViewModel.FILTER_DATE);

            vReturn = vReturn.OrderByDescending(fld => fld.LH_DT).ToList();

            return vReturn;
        } //End public List<LHStudentlistVM> getDatalist()

        public List<LHStudentdetailVM> getDatalist_base(
            int? idStudent = null, int? pnClasstypeID = null, int? pnClassroomID = null,
            DateTime? idDate = null)
        {
            List<LHStudentdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.LHStudent_infos
                           select new LHStudentdetailVM
                           {
                               ID = tb.ID,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               SENTRA_ID = tb.SENTRA_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               LH_DT = tb.LH_DT,
                               LH_NOTES = tb.LH_NOTES,
                               LH_COMMENTS = tb.LH_COMMENTS,
                               MOOD_ID = tb.MOOD_ID,
                               TIMELINE_ID = tb.TIMELINE_ID,

                               ABSENSI_HADIR = tb.ABSENSI_HADIR,
                               ABSENSI_IN = tb.ABSENSI_IN,
                               ABSENSI_OUT = tb.ABSENSI_OUT,

                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               SENTRA_NAME = tb.SENTRA_NAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               MOOD_CODE = tb.MOOD_CODE,
                               MOOD_DESC = tb.MOOD_DESC,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               FTHR_IMG = tb.FTHR_IMG,
                               MTHR_IMG = tb.MTHR_IMG,
                               EMPLOYEE_IMG = tb.EMPLOYEE_IMG,
                               ABSENSI_CODE = tb.ABSENSI_CODE,
                               ABSENSI_DESC = tb.ABSENSI_DESC,
                               ABSENSI_COUNT = tb.ABSENSI_COUNT
                           };
                if (idStudent != null) { oQRY = oQRY.Where(fld => fld.STUDENT_ID == idStudent); }
                if (pnClasstypeID != null) { oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == pnClasstypeID); }
                if (pnClassroomID != null) { oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == pnClassroomID); }
                if (idDate != null)
                {
                    oQRY = oQRY.Where(fld =>
                    fld.LH_DT.Value.Year == idDate.Value.Year &&
                    fld.LH_DT.Value.Month == idDate.Value.Month &&
                    fld.LH_DT.Value.Day == idDate.Value.Day);
                }
                vReturn = oQRY.OrderByDescending(fld => fld.LH_DT).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<LHStudentlistVM> getDatalist()

        public LHStudentdetailVM getData_ori(int? id = null)
        {
            LHStudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.LHStudent_infos
                           where tb.ID == id
                           select new LHStudentdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               SENTRA_ID = tb.SENTRA_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               LH_DT = tb.LH_DT,
                               LH_NOTES = tb.LH_NOTES,
                               LH_COMMENTS = tb.LH_COMMENTS,
                               MOOD_ID = tb.MOOD_ID,
                               TIMELINE_ID = tb.TIMELINE_ID,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               SENTRA_CODE = tb.SENTRA_CODE,
                               SENTRA_NAME = tb.SENTRA_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               EMPLOYEE_NICKNAME = tb.EMPLOYEE_NICKNAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NISN = tb.STUDENT_NISN,
                               STUDENT_PINREG = tb.STUDENT_PINREG,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                               STUDENT_FTHR_NAME = tb.STUDENT_FTHR_NAME,
                               STUDENT_MTHR_NAME = tb.STUDENT_MTHR_NAME
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public LHStudentdetailVM getData_ori(int? id = null)

        public LHStudentdetailVM getData(int? id = null)
        {
            LHStudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.LHStudent_infos
                           where tb.ID == id
                           select new LHStudentdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               SENTRA_ID = tb.SENTRA_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               LH_DT = tb.LH_DT,
                               LH_NOTES = tb.LH_NOTES,
                               LH_COMMENTS = tb.LH_COMMENTS,
                               MOOD_ID = tb.MOOD_ID,
                               TIMELINE_ID = tb.TIMELINE_ID,
                               ABSENSI_HADIR = tb.ABSENSI_HADIR,
                               ABSENSI_IN = tb.ABSENSI_IN,
                               ABSENSI_OUT = tb.ABSENSI_OUT,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               SENTRA_CODE = tb.SENTRA_CODE,
                               SENTRA_NAME = tb.SENTRA_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               EMPLOYEE_NICKNAME = tb.EMPLOYEE_NICKNAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NISN = tb.STUDENT_NISN,
                               STUDENT_PINREG = tb.STUDENT_PINREG,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                               STUDENT_FTHR_NAME = tb.STUDENT_FTHR_NAME,
                               STUDENT_MTHR_NAME = tb.STUDENT_MTHR_NAME,
                               MOOD_CODE = tb.MOOD_CODE,
                               MOOD_DESC = tb.MOOD_DESC,
                               ABSENSI_CODE = tb.ABSENSI_CODE,
                               ABSENSI_DESC = tb.ABSENSI_DESC,
                               ABSENSI_COUNT = tb.ABSENSI_COUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public LHStudentdetailVM getData(int? id = null)
        public LHStudentdetailVM getData(int? idStudent = null, DateTime? idDate=null)
        {
            LHStudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.LHStudent_infos
                           where tb.STUDENT_ID == idStudent && tb.LH_DT==idDate
                           select new LHStudentdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               SENTRA_ID = tb.SENTRA_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               LH_DT = tb.LH_DT,
                               LH_NOTES = tb.LH_NOTES,
                               LH_COMMENTS = tb.LH_COMMENTS,
                               MOOD_ID = tb.MOOD_ID,
                               TIMELINE_ID = tb.TIMELINE_ID,
                               ABSENSI_HADIR = tb.ABSENSI_HADIR,
                               ABSENSI_IN = tb.ABSENSI_IN,
                               ABSENSI_OUT = tb.ABSENSI_OUT,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               SENTRA_CODE = tb.SENTRA_CODE,
                               SENTRA_NAME = tb.SENTRA_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME,
                               EMPLOYEE_NICKNAME = tb.EMPLOYEE_NICKNAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NISN = tb.STUDENT_NISN,
                               STUDENT_PINREG = tb.STUDENT_PINREG,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                               STUDENT_FTHR_NAME = tb.STUDENT_FTHR_NAME,
                               STUDENT_MTHR_NAME = tb.STUDENT_MTHR_NAME,
                               MOOD_CODE = tb.MOOD_CODE,
                               MOOD_DESC = tb.MOOD_DESC,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               FTHR_IMG = tb.FTHR_IMG,
                               MTHR_IMG = tb.MTHR_IMG,
                               EMPLOYEE_IMG = tb.EMPLOYEE_IMG,
                               ABSENSI_CODE = tb.ABSENSI_CODE,
                               ABSENSI_DESC = tb.ABSENSI_DESC,
                               ABSENSI_COUNT = tb.ABSENSI_COUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public LHStudentdetailVM getData(int? id = null)
        public LHStudentdetailVM getData_ID(int? idEmployee, int? idStudent, DateTime? idDate)
        {
            LHStudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.LHStudent_infos
                           where tb.EMPLOYEE_ID==idEmployee && tb.STUDENT_ID == idStudent &&
                           (tb.LH_DT.Value.Day == idDate.Value.Day && tb.LH_DT.Value.Month == idDate.Value.Month && tb.LH_DT.Value.Year == idDate.Value.Year)
                           select new LHStudentdetailVM
                           { ID = tb.ID };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public LHStudentdetailVM getData(int? id = null)

        public LHStudentdetailVM getData_create(LHStudentVM poViewModel = null)
        {
            LHStudentdetailVM oReturn = this.getData(poViewModel.FILTER_ID, poViewModel.FILTER_DATE);

            if (oReturn == null) {
                oReturn = new LHStudentdetailVM();
                oReturn.BRANCH_ID = poViewModel.DETAIL_STUDENT.BRANCH_ID;
                oReturn.YEAR_ID = poViewModel.FILTER_YEAR_ID;
                oReturn.SEMESTER_ID = poViewModel.FILTER_SEMESTER_ID;
                oReturn.CLASSTYPE_ID = poViewModel.FILTER_CLASSTYPE_ID;
                oReturn.CLASSTYPE_NAME = poViewModel.FILTER_CLASSTYPE_NAME;
                oReturn.CLASSROOM_ID = poViewModel.FILTER_CLASSROOM_ID;
                oReturn.CLASSROOM_NAME = poViewModel.FILTER_CLASSROOM_NAME;
                oReturn.SENTRA_ID = poViewModel.DETAIL_USER.SENTRA_ID;
                oReturn.SENTRA_NAME = poViewModel.FILTER_SENTRA_NAME;

                oReturn.LH_DT = poViewModel.FILTER_DATE;
                oReturn.STUDENT_ID = poViewModel.FILTER_ID;
                oReturn.STUDENT_NAME = poViewModel.DETAIL_STUDENT.NAME;
                oReturn.EMPLOYEE_ID = poViewModel.DETAIL_USER.RES_ID;
                oReturn.EMPLOYEE_NAME = poViewModel.DETAIL_USER.DISPLAY_NAME;
            }

            return oReturn;
        } //End public LHStudentdetailVM getData_create(int? id = null)
        public List<LHStudentlookupVM> getDatalist_lookup()
        {
            List<LHStudentlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.LHStudent_infos
                           select new LHStudentlookupVM
                           {
                               ID = tb.ID,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               SENTRA_ID = tb.SENTRA_ID,
                               EMPLOYEE_ID = tb.EMPLOYEE_ID,
                               STUDENT_ID = tb.STUDENT_ID,
                               LH_DT = tb.LH_DT,
                               MOOD_ID = tb.MOOD_ID,
                               TIMELINE_ID = tb.TIMELINE_ID,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               EMPLOYEE_NIP = tb.EMPLOYEE_NIP,
                               EMPLOYEE_NAME = tb.EMPLOYEE_NAME
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<LHStudentlookupVM> getDatalist_lookup()
    } //End public class LHStudentDS
} //End namespace APPBASE.Models

