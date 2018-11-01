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
    public partial class StudentDS
    {
        //Constructor
        public StudentDS() { } //End public StudentDS
        public List<StudentlistitemVM> getDatalist(StudentVM poViewModel = null)
        {
            List<StudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           select new StudentlistitemVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME=tb.NAME,
                               NIS=tb.NIS
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentlistitemVM> getDatalist_calon(StudentVM poViewModel = null)
        {
            List<StudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID == 4 //Calon siswa
                           select new StudentlistitemVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentlistitemVM> getDatalist_aktif(StudentVM poViewModel = null)
        {
            List<StudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID == 1 || tb.STUDENTSTS_ID == null
                           select new StudentlistitemVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if
                    if (poViewModel.FILTER_CLASSROOM_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == poViewModel.FILTER_CLASSROOM_ID);
                    } //End if
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentlistitemVM> getDatalist_lulus(StudentVM poViewModel = null)
        {
            List<StudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID == 3
                           select new StudentlistitemVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentlistitemVM> getDatalist_pindah(StudentVM poViewModel = null)
        {
            List<StudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID == 2
                           select new StudentlistitemVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentlistitemVM> getDatalist_aktif2(StudentVM poViewModel = null)
        {
            List<StudentlistitemVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID == 1 || tb.STUDENTSTS_ID == 4
                           select new StudentlistitemVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if
                    if (poViewModel.FILTER_CLASSROOM_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == poViewModel.FILTER_CLASSROOM_ID);
                    } //End if
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        
        public StudentdetailVM getData(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               NAME = tb.NAME,
                               NICKNAME = tb.NICKNAME,
                               NIS = tb.NIS,
                               NISN = tb.NISN,
                               PINREG = tb.PINREG,
                               REGNO = tb.REGNO,
                               REG_DT = tb.REG_DT,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               SEX_ID = tb.SEX_ID,
                               POB = tb.POB,
                               DOB = tb.DOB,
                               RELIGION_ID = tb.RELIGION_ID,
                               NATIONALITY_ID = tb.NATIONALITY_ID,
                               LANGUAGE = tb.LANGUAGE,
                               ETHNIC = tb.ETHNIC,
                               CHILD_SEQ = tb.CHILD_SEQ,
                               CHILD_QTY = tb.CHILD_QTY,
                               ADDR_COUNTRY_ID = tb.ADDR_COUNTRY_ID,
                               ADDR_CITY = tb.ADDR_CITY,
                               ADDR_ZIP = tb.ADDR_ZIP,
                               ADDR_STREET1 = tb.ADDR_STREET1,
                               ADDR_STREET2 = tb.ADDR_STREET2,
                               HOME_PHONE = tb.HOME_PHONE,
                               CELL_PHONE = tb.CELL_PHONE,
                               EMAIL = tb.EMAIL,
                               PREV_SCHOOL_NAME = tb.PREV_SCHOOL_NAME,
                               PREV_SCHOOL_ADDR = tb.PREV_SCHOOL_ADDR,
                               BLOOD_TYPE_ID = tb.BLOOD_TYPE_ID,
                               WEIGHT_KG = tb.WEIGHT_KG,
                               HEIGHT_CM = tb.HEIGHT_CM,
                               MEDICAL_STORY1 = tb.MEDICAL_STORY1,
                               MEDICAL_STORY2 = tb.MEDICAL_STORY2,
                               FTHR_NAME = tb.FTHR_NAME,
                               FTHR_POB = tb.FTHR_POB,
                               FTHR_DOB = tb.FTHR_DOB,
                               FTHR_RELIGION_ID = tb.FTHR_RELIGION_ID,
                               FTHR_NATIONALITY_ID = tb.FTHR_NATIONALITY_ID,
                               FTHR_EDU_ID = tb.FTHR_EDU_ID,
                               FTHR_JOB_ID = tb.FTHR_JOB_ID,
                               FTHR_JOB_COMPANY = tb.FTHR_JOB_COMPANY,
                               FTHR_JOB_ADDR1 = tb.FTHR_JOB_ADDR1,
                               FTHR_JOB_ADDR2 = tb.FTHR_JOB_ADDR2,
                               FTHR_INCOME = tb.FTHR_INCOME,
                               FTHR_EMAIL = tb.FTHR_EMAIL,
                               FTHR_HOMEPHONE = tb.FTHR_HOMEPHONE,
                               FTHR_CELLPHONE = tb.FTHR_CELLPHONE,
                               FTHR_ADDR_COUNTRY_ID = tb.FTHR_ADDR_COUNTRY_ID,
                               FTHR_ADDR_CITY = tb.FTHR_ADDR_CITY,
                               FTHR_ADDR_ZIP = tb.FTHR_ADDR_ZIP,
                               FTHR_ADDR_STREET1 = tb.FTHR_ADDR_STREET1,
                               FTHR_ADDR_STREET2 = tb.FTHR_ADDR_STREET2,
                               MTHR_NAME = tb.MTHR_NAME,
                               MTHR_POB = tb.MTHR_POB,
                               MTHR_DOB = tb.MTHR_DOB,
                               MTHR_RELIGION_ID = tb.MTHR_RELIGION_ID,
                               MTHR_NATIONALITY_ID = tb.MTHR_NATIONALITY_ID,
                               MTHR_EDU_ID = tb.MTHR_EDU_ID,
                               MTHR_JOB_ID = tb.MTHR_JOB_ID,
                               MTHR_JOB_COMPANY = tb.MTHR_JOB_COMPANY,
                               MTHR_JOB_ADDR1 = tb.MTHR_JOB_ADDR1,
                               MTHR_JOB_ADDR2 = tb.MTHR_JOB_ADDR2,
                               MTHR_INCOME = tb.MTHR_INCOME,
                               MTHR_EMAIL = tb.MTHR_EMAIL,
                               MTHR_HOMEPHONE = tb.MTHR_HOMEPHONE,
                               MTHR_CELLPHONE = tb.MTHR_CELLPHONE,
                               MTHR_ADDR_COUNTRY_ID = tb.MTHR_ADDR_COUNTRY_ID,
                               MTHR_ADDR_CITY = tb.MTHR_ADDR_CITY,
                               MTHR_ADDR_ZIP = tb.MTHR_ADDR_ZIP,
                               MTHR_ADDR_STREET1 = tb.MTHR_ADDR_STREET1,
                               MTHR_ADDR_STREET2 = tb.MTHR_ADDR_STREET2,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               FTHR_IMG = tb.FTHR_IMG,
                               MTHR_IMG = tb.MTHR_IMG,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               STUDENTSTS_ID = tb.STUDENTSTS_ID,
                               NEXT_SCHOOL_NAME = tb.NEXT_SCHOOL_NAME,
                               NEXT_SCHOOL_DT = tb.NEXT_SCHOOL_DT,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               SEX_CODE = tb.SEX_CODE,
                               SEX_DESC = tb.SEX_DESC,
                               RELIGION_CODE = tb.RELIGION_CODE,
                               RELIGION_DESC = tb.RELIGION_DESC,
                               BLOOD_TYPE_CODE = tb.BLOOD_TYPE_CODE,
                               BLOOD_TYPE_DESC = tb.BLOOD_TYPE_DESC,
                               FTHR_RELIGION_CODE = tb.FTHR_RELIGION_CODE,
                               FTHR_RELIGION_DESC = tb.FTHR_RELIGION_DESC,
                               FTHR_EDU_CODE = tb.FTHR_EDU_CODE,
                               FTHR_EDU_DESC = tb.FTHR_EDU_DESC,
                               FTHR_JOB_CODE = tb.FTHR_JOB_CODE,
                               FTHR_JOB_DESC = tb.FTHR_JOB_DESC,
                               MTHR_RELIGION_CODE = tb.MTHR_RELIGION_CODE,
                               MTHR_RELIGION_DESC = tb.MTHR_RELIGION_DESC,
                               MTHR_EDU_CODE = tb.MTHR_EDU_CODE,
                               MTHR_EDU_DESC = tb.MTHR_EDU_DESC,
                               MTHR_JOB_CODE = tb.MTHR_JOB_CODE,
                               MTHR_JOB_DESC = tb.MTHR_JOB_DESC,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               STUDENTSTS_CODE = tb.STUDENTSTS_CODE,
                               STUDENTSTS_DESC = tb.STUDENTSTS_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)
        public StudentdetailVM getData_IDbyUserID(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {ID = tb.ID};
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)
        public StudentdetailVM getData_shortinfo(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {
                               ID = tb.ID,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               //CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               //CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)

        public StudentdetailVM getData_lookup(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               STUDENT_IMG = tb.STUDENT_IMG
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)

        public List<StudentdetailVM> getDatalist_outstandinglhs(DateTime? idDate,
            int? pnClasstypeID, int? pnClassroomID)
        {
            List<StudentdetailVM> vReturn;



            using (var db = new DBMAINContext())
            {
                var oData = new LHStudentDS().getDatalist(null, idDate);
                List<int?> oDatalist = new List<int?>();
                foreach (var item in oData)
                {
                    oDatalist.Add(item.STUDENT_ID);

                } //End foreach (var item in oData)

                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID != 2 && tb.STUDENTSTS_ID != 3
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               BRANCH_DESC = tb.BRANCH_DESC,

                               YEAR_ID = tb.YEAR_ID,
                               YEAR_DESC = tb.YEAR_DESC,

                               SEMESTER_ID = tb.SEMESTER_ID,
                               SEMESTER_DESC = tb.SEMESTER_DESC,

                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,

                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,

                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               STUDENT_IMG = tb.STUDENT_IMG
                           };
                if (oDatalist.Count > 0) oQRY = oQRY.Where(fld => !oDatalist.Contains(fld.ID));
                if (pnClasstypeID != null) oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == pnClasstypeID);
                if (pnClassroomID != null) oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == pnClassroomID);
                vReturn = oQRY.OrderBy(fld => fld.NAME).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<StudentdetailVM> getDatalist_classmate(int id = null)
        public List<StudentdetailVM> getDatalist_classmate(int? id)
        {
            List<StudentdetailVM> vReturn;



            using (var db = new DBMAINContext())
            {
                StudentdetailVM oData = new StudentDS().getData(id);
                int? idClasstype = oData.CLASSTYPE_ID;
                int? idClassroom = oData.CLASSROOM_ID;

                var oQRY = from tb in db.Student_infos
                           where tb.ID != id && tb.CLASSTYPE_ID == idClasstype &&
                           tb.CLASSROOM_ID == idClassroom
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               FTHR_IMG = tb.FTHR_IMG,
                               MTHR_IMG = tb.MTHR_IMG
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<StudentdetailVM> getDatalist_classmate(int id = null)
        public List<StudentdetailVM> getDatalist_lhstudent(LHStudentVM poViewModel = null)
        {
            List<StudentdetailVM> vReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.STUDENTSTS_ID != 2 && tb.STUDENTSTS_ID != 3
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_ID = tb.YEAR_ID,
                               YEAR_DESC = tb.YEAR_DESC,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_NAME = tb.CLASSTYPE_NAME,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               CLASSROOM_NAME = tb.CLASSROOM_NAME,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               STUDENTSTS_ID = tb.STUDENTSTS_ID
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSROOM_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == poViewModel.FILTER_CLASSROOM_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentlookupVM> getDatalist_lookup()
        {
            List<StudentlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           select new StudentlookupVM
                           {
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               STUDENT_IMG = tb.STUDENT_IMG
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
    } //End public class StudentDS
} //End namespace APPBASE.Models
