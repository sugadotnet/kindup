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
using Omu.ValueInjecter.Injections;

namespace APPBASE.Models
{
    public class CallendarCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }
        public int? TIMELINE_ID { get; set; }

        //Constructor
        public CallendarCRUD() { } //End public CallendarCRUD()
        public void Create(CallendardetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    poViewModel.SHORT_DESC = poViewModel.FULL_DESC;
                    Callendar oModel = new Callendar();
                    //Map Form Data
                    //oModel.InjectFrom(poViewModel);
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Process CRUD
                    db.Callendars.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(CallendardetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    poViewModel.SHORT_DESC = poViewModel.FULL_DESC;
                    Callendar oModel = db.Callendars.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                    CallendarhiddenVM oModelhidden = new CallendarhiddenVM();
                    oModelhidden.InjectFrom(oModel);
                    poViewModel.InjectFrom(oModelhidden);

                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.ID = oModel.ID;
                    this.TIMELINE_ID = oModel.TIMELINE_ID;
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
                    Callendar oModel = db.Callendars.Find(id);
                    db.Callendars.Remove(oModel);
                    if (oModel.TIMELINE_ID != null) {
                        Timeline oModeltimeline = db.Timelines.Find(oModel.TIMELINE_ID);
                        if (oModeltimeline != null) { db.Timelines.Remove(oModeltimeline); } //End if (oModeltimeline != null)
                    } //End if (oModel.TIMELINE_ID != null)

                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
    } //End public class CallendarCRUD
} //End namespace APPBASE.Models

