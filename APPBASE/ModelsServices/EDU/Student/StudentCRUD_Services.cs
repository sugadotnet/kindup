﻿using System;
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
using APPBASE.Svcutil;
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public class StudentCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor
        public StudentCRUD() { } //End public StudentCRUD()
        public void Create(StudentdetailVM poViewModel, HttpPostedFileBase poFileimage=null)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Student oModel = new Student();
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set Image file name
                    if (poFileimage != null) { oModel.STUDENT_IMG = Utility_FileUploadDownload.setImage_Student(); } //End if (poFileimage != null)
                    
                    //Process CRUD
                    db.Students.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;

                    //Save file
                    if (poFileimage != null)
                    {Utility_FileUploadDownload.saveImage_Student(poFileimage, oModel.STUDENT_IMG);} //End if (poFileimage != null)

                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(StudentdetailVM poViewModel, HttpPostedFileBase poFileimage=null)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Student oModel = db.Students.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set Image file name
                    if (poFileimage != null) { if ((oModel.STUDENT_IMG == null) || (oModel.STUDENT_IMG == "")) { oModel.STUDENT_IMG = Utility_FileUploadDownload.setImage_Student(); } } //End if (poFileimage != null)
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.ID = oModel.ID;

                    //Save file
                    if (poFileimage != null)
                    {
                        Utility_FileUploadDownload.saveImage_Student(poFileimage, oModel.STUDENT_IMG);
                    } //End if (poFileimage != null)
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Student oModel = db.Students.Find(id);
                    db.Students.Remove(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;

                    //Delete Image file name
                    Utility_FileUploadDownload.deleteImage_Student(oModel.STUDENT_IMG);
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete

    } //End public class StudentCRUD
} //End namespace APPBASE.Models

