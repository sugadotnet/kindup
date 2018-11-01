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
    public class Installment_inCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        private DBMAINContext db;
        private Installment_in oModel;
        //Constructor 1
        public Installment_inCRUD() {
            this.db = new DBMAINContext();
        } //End Constructor 1
        //Constructor 2
        public Installment_inCRUD(DBMAINContext poDB) {
            this.db = poDB;
        } //End Constructor 2

        public void Create(Installment_indetailVM poViewModel) {
            try
            {
                this.oModel = new Installment_in();
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                //Process CRUD
                this.db.Installment_ins.Add(this.oModel);
                this.db.SaveChanges();
                this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(Installment_indetailVM poViewModel)
        {
            try
            {
                this.oModel = this.db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
                //Process CRUD
                this.db.Entry(this.oModel).State = EntityState.Modified;
                this.db.SaveChanges();
                this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                this.oModel = this.db.Installment_ins.Find(id);
                this.db.Installment_ins.Remove(oModel);
                this.db.SaveChanges();
                this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
    } //End public class Installment_inCRUD
} //End namespace APPBASE.Models
