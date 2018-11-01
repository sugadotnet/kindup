using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Models
{
    #region Default Context Area
        public partial class DBMAINContext : DbContext
        {
            //Timeline
            public DbSet<Timeline> Timelines { get; set; }
            public DbSet<Timeline_info> Timeline_infos { get; set; }
            //Callendar
            public DbSet<Callendar> Callendars { get; set; }
            public DbSet<Callendar_info> Callendar_infos { get; set; }
            //Acitivity
            public DbSet<Activity> Activitys { get; set; }
            public DbSet<Activity_info> Activity_infos { get; set; }
            //Announcement
            public DbSet<Announcement> Announcements { get; set; }
            public DbSet<Announcement_info> Announcement_infos { get; set; }
            //Suggest
            public DbSet<Suggest> Suggests { get; set; }
            public DbSet<Suggest_info> Suggest_infos { get; set; }
            //Warning
            public DbSet<Warning> Warnings { get; set; }
            public DbSet<Warning_info> Warning_infos { get; set; }

            //CFG - Branch
            public DbSet<Branch> Branchs { get; set; }
            public DbSet<Branch_info> Branch_infos { get; set; }
            public DbSet<BranchHQ_info> BranchHQ_infos { get; set; }
            public DbSet<Branchall_info> Branchall_infos { get; set; }
            //CFG - Year
            public DbSet<Year> Years { get; set; }
            //CFG - Semester
            public DbSet<Semester> Semesters { get; set; }
            //CFG - Classtype
            public DbSet<Classtype> Classtypes { get; set; }
            //CFG - Aboutus
            public DbSet<Aboutus> Aboutuss { get; set; }
            //CFG - Classroom
            public DbSet<Classroom> Classrooms { get; set; }
            //CFG - Photogallery
            public DbSet<Photogallery> Photogallerys { get; set; }
            //Sentra
            public DbSet<Sentra> Sentras { get; set; }



            //LOV - Bloodtype
            public DbSet<Bloodtype> Bloodtypes { get; set; }
            //LOV - Education
            public DbSet<Education> Educations { get; set; }
            //LOV - Gender
            public DbSet<Gender> Genders { get; set; }
            //LOV - Jobtype
            public DbSet<Jobtype> Jobtypes { get; set; }
            //LOV - Religion
            public DbSet<Religion> Religions { get; set; }
            //LOV - Marital
            public DbSet<Marital> Maritals { get; set; }
            //LOV - Emplsts
            public DbSet<Emplsts> Emplstss { get; set; }
            //LOV - Jobtitle
            public DbSet<Jobtitle> Jobtitles { get; set; }
            //LOV - Evaluation
            public DbSet<Evaluation> Evaluations { get; set; }
            //LOV - Themes
            public DbSet<Theme> Themes { get; set; }
            //LOV - Rate
            public DbSet<Rate> Rates { get; set; }
            //LOV - Incometype
            public DbSet<Incometype> Incometypes { get; set; }
            //City
            public DbSet<City> Citys { get; set; }
            //Mood
            public DbSet<Mood> Moods { get; set; }
            //Studentsts
            public DbSet<Studentsts> Studentstss { get; set; }
            //Empmutationsts
            public DbSet<Empmutationsts> Empmutationstss { get; set; }
            //Attendance
            public DbSet<Attendance> Attendances { get; set; }
            //Doa
            public DbSet<Doa> Doas { get; set; }
            //Song
            public DbSet<Song> Songs { get; set; }


            //Tatib
            public DbSet<Basicmaterial> Basicmaterials { get; set; }
            //Tatib
            public DbSet<Tatib> Tatibs { get; set; }
            //Promised
            public DbSet<Promised> Promiseds { get; set; }
            public DbSet<Promised_info> Promised_infos { get; set; }
            //Skm
            public DbSet<Skm> Skms { get; set; }
            public DbSet<Skm_info> Skm_infos { get; set; }
            //Skh
            public DbSet<Skh> Skhs { get; set; }
            public DbSet<Skh_info> Skh_infos { get; set; }
            //Skhstudenth
            public DbSet<Skhstudenth> Skhstudenths { get; set; }
            public DbSet<Skhstudenth_info> Skhstudenth_infos { get; set; }
            //Skhstudentd
            public DbSet<Skhstudentd> Skhstudentds { get; set; }
            public DbSet<Skhstudentd_info> Skhstudentd_infos { get; set; }
            //Skhstudent
            public DbSet<Skhstudent> Skhstudents { get; set; }
            public DbSet<Skhstudent_info> Skhstudent_infos { get; set; }
            //LHStudent
            public DbSet<LHStudent> LHStudents { get; set; }
            public DbSet<LHStudent_info> LHStudent_infos { get; set; }
            //Classroomteacher
            public DbSet<Classroomteacher> Classroomteachers { get; set; }
            public DbSet<Classroomteacher_info> Classroomteacher_infos { get; set; }


            
            //Student
            public DbSet<Student> Students { get; set; }
            public DbSet<Student_info> Student_infos { get; set; }
            //Employee
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Employee_info> Employee_infos { get; set; }



        } //End public class DBMAINContext : DbContext
    #endregion
} //End namespace APPBASE.Models