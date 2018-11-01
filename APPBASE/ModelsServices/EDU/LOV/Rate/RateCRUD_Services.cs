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
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public class RateCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor
        public RateCRUD() { } //End public RateCRUD()
        public void Create(RatedetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Rate oModel = new Rate();
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Process CRUD
                    db.Rates.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(RatedetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Rate oModel = db.Rates.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.ID = oModel.ID;
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
                    Rate oModel = db.Rates.Find(id);
                    db.Rates.Remove(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
    } //End public class RateCRUD
} //End namespace APPBASE.Models

