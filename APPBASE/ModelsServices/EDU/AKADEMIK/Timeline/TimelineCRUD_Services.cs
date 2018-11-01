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
    public class TimelineCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }
        public TimelinedetailVM oVM { get; set; }

        //Constructor
        public TimelineCRUD() { } //End public TimelineCRUD()

        //Constructor 1
        public TimelineCRUD(CallendardetailVM poVM=null) {
            //Map Form Data
            if (poVM != null) {
                this.oVM = new TimelinedetailVM();
                this.oVM.InjectFrom(poVM);
                this.oVM.ID = poVM.TIMELINE_ID;
            } //End if (poVM != null)
        } //End public TimelineCRUD()
        //Constructor 2
        public TimelineCRUD(ActivitydetailVM poVM=null) {
            //Map Form Data
            if (poVM != null) {
                this.oVM = new TimelinedetailVM();
                this.oVM.InjectFrom(poVM);
                this.oVM.ID = poVM.TIMELINE_ID;
            } //End if (poVM != null)
        } //End public TimelineCRUD()
        //Constructor 3
        public TimelineCRUD(AnnouncementdetailVM poVM=null) {
            if (poVM != null) {
                //Map Form Data
                this.oVM = new TimelinedetailVM();
                this.oVM.InjectFrom(poVM);
                this.oVM.ID = poVM.TIMELINE_ID;
            } //End if (poVM != null)
        } //End public TimelineCRUD()
        //Constructor 4
        public TimelineCRUD(SuggestdetailVM poVM = null)
        {
            if (poVM != null)
            {
                //Map Form Data
                this.oVM = new TimelinedetailVM();
                this.oVM.InjectFrom(poVM);
                this.oVM.ID = poVM.TIMELINE_ID;
            } //End if (poVM != null)
        } //End public TimelineCRUD()
        //Constructor 5
        public TimelineCRUD(WarningdetailVM poVM = null)
        {
            if (poVM != null)
            {
                //Map Form Data
                this.oVM = new TimelinedetailVM();
                this.oVM.InjectFrom(poVM);
                this.oVM.ID = poVM.TIMELINE_ID;
            } //End if (poVM != null)
        } //End public TimelineCRUD()

        public void Create() { this.Create(this.oVM); }
        public void Create(TimelinedetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    poViewModel.SHORT_DESC = poViewModel.FULL_DESC;
                    Timeline oModel = new Timeline();
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Process CRUD
                    db.Timelines.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update() { this.Update(this.oVM); }
        public void Update(TimelinedetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    poViewModel.SHORT_DESC = poViewModel.FULL_DESC;
                    Timeline oModel = db.Timelines.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
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
                    Timeline oModel = db.Timelines.Find(id);
                    db.Timelines.Remove(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
    } //End public class TimelineCRUD
} //End namespace APPBASE.Models

