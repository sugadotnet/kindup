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
    public partial class LHStudentVM : FilterdataVM
    {
        public List<LHStudentdatesVM> DATES { get; set; }
        public List<StudentdetailVM> LISTITEM_STUDENT { get; set; }
        public List<LHStudentlistVM> LIST { get; set; }
        public List<LHStudentdetailVM> LISTRPT { get; set; }
        public LHStudentdetailVM DETAIL { get; set; }
        public StudentdetailVM DETAIL_STUDENT { get; set; }
        public UserdetailVM DETAIL_USER { get; set; }
    } //End public partial class LHStudentVM

    public partial class LHStudentdatesVM
    {
        public DateTime? LH_DT { get; set; }
        public string COMMPLETE_STS { get; set; }
    } //End public partial class LHStudentdatesVM
    public partial class LHStudentlistVM
    {
        public int? ID { get; set; }
        //Branch
        public int? BRANCH_ID { get; set; }
        public string BRANCH_DESC { get; set; }
        //Year
        public int? YEAR_ID { get; set; }
        public string YEAR_DESC { get; set; }
        //Semester
        public Byte? SEMESTER_ID { get; set; }
        public string SEMESTER_DESC { get; set; }
        //Classtype
        public Byte? CLASSTYPE_ID { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        //CLassroom
        public int? CLASSROOM_ID { get; set; }
        public string CLASSROOM_NAME { get; set; }
        //Sentra
        public int? SENTRA_ID { get; set; }
        public string SENTRA_NAME { get; set; }

        public int? EMPLOYEE_ID { get; set; }

        public string EMPLOYEE_NIP { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_NICKNAME { get; set; }

        public int? STUDENT_ID { get; set; }
        public string STUDENT_NIS { get; set; }
        public string STUDENT_NISN { get; set; }
        public string STUDENT_PINREG { get; set; }
        public string STUDENT_NAME { get; set; }
        public string STUDENT_NICKNAME { get; set; }

        public string MOOD_CODE { get; set; }
        public string MOOD_DESC { get; set; }

        public DateTime? LH_DT { get; set; }
        public string LH_NOTES { get; set; }
        public string LH_COMMENTS { get; set; }
        public Byte? MOOD_ID { get; set; }
        public int? TIMELINE_ID { get; set; }

        public int? ABSENSI_HADIR { get; set; }
        public DateTime? ABSENSI_IN { get; set; }
        public DateTime? ABSENSI_OUT { get; set; }

        public string ABSENSI_CODE { get; set; }
        public string ABSENSI_DESC { get; set; }
        public int? ABSENSI_COUNT { get; set; }
    } //End public partial class LHStudentlistVM
    public partial class LHStudentdetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public Byte? CLASSTYPE_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? SENTRA_ID { get; set; }
        public int? EMPLOYEE_ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public DateTime? LH_DT { get; set; }
        public string LH_NOTES { get; set; }
        public string LH_COMMENTS { get; set; }
        public Byte? MOOD_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
        public int? ABSENSI_HADIR { get; set; }
        public DateTime? ABSENSI_IN { get; set; }
        public DateTime? ABSENSI_OUT { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_NAME { get; set; }
        public string SENTRA_CODE { get; set; }
        public string SENTRA_NAME { get; set; }
        public string EMPLOYEE_NIP { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_NICKNAME { get; set; }
        public string EMPLOYEE_IMG { get; set; }
        public string STUDENT_NIS { get; set; }
        public string STUDENT_NISN { get; set; }
        public string STUDENT_PINREG { get; set; }
        public string STUDENT_NAME { get; set; }
        public string STUDENT_NICKNAME { get; set; }
        public string STUDENT_FTHR_NAME { get; set; }
        public string STUDENT_MTHR_NAME { get; set; }
        public string STUDENT_IMG { get; set; }
        public string FTHR_IMG { get; set; }
        public string MTHR_IMG { get; set; }
        public string MOOD_CODE { get; set; }
        public string MOOD_DESC { get; set; }
        public string ABSENSI_CODE { get; set; }
        public string ABSENSI_DESC { get; set; }
        public int? ABSENSI_COUNT { get; set; }
    } //End public partial class LHStudentdetailVM

    public partial class FilterLHSVM
    {
        public DateTime? FILTER_DATE { get; set; }

        public Byte? FILTER_CLASSTYPE_ID { get; set; }
        public string FILTER_CLASSTYPE_NAME { get; set; }

        public Byte? FILTER_CLASSROOM_ID { get; set; }
        public string FILTER_CLASSROOM_NAME { get; set; }
    } //End public partial class FilterLHSVM
    public partial class LHStudentlookupVM
    {
        public int? ID { get; set; }
        //Branch
        public int? BRANCH_ID { get; set; }
        public string BRANCH_DESC { get; set; }
        //Year
        public int? YEAR_ID { get; set; }
        public string YEAR_DESC { get; set; }
        //Semester
        public Byte? SEMESTER_ID { get; set; }
        public string SEMESTER_DESC { get; set; }
        //Classtype
        public Byte? CLASSTYPE_ID { get; set; }
        public string CLASSTYPE_NAME { get; set; }
        //CLassroom
        public int? CLASSROOM_ID { get; set; }
        public string CLASSROOM_NAME { get; set; }
        //Sentra
        public int? SENTRA_ID { get; set; }
        public string SENTRA_NAME { get; set; }

        public int? EMPLOYEE_ID { get; set; }

        public string EMPLOYEE_NIP { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_NICKNAME { get; set; }

        public int? STUDENT_ID { get; set; }
        public string STUDENT_NIS { get; set; }
        public string STUDENT_NISN { get; set; }
        public string STUDENT_PINREG { get; set; }
        public string STUDENT_NAME { get; set; }
        public string STUDENT_NICKNAME { get; set; }

        public string MOOD_CODE { get; set; }
        public string MOOD_DESC { get; set; }

        public DateTime? LH_DT { get; set; }
        public string LH_NOTES { get; set; }
        public string LH_COMMENTS { get; set; }
        public Byte? MOOD_ID { get; set; }
        public int? TIMELINE_ID { get; set; }
    } //End public partial class LHStudentlistVM

} //End namespace APPBASE.Models
