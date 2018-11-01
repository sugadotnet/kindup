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
    public class Transaction_indCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        private DBMAINContext db;
        private Transaction_ind oModel;

        //Constructor 1
        public Transaction_indCRUD() {
            this.db = new DBMAINContext();
        } //End Constructor
        //Constructor 2
        public Transaction_indCRUD(DBMAINContext poDB)
        {
            this.db = poDB;
        } //End Constructor
        public void Create(Transaction_inddetailVM poViewModel)
        {
            try
            {
                this.oModel = new Transaction_ind();
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                //Process CRUD
                this.db.Transaction_inds.Add(oModel);
                this.db.SaveChanges();
                this.ID = oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(Transaction_inddetailVM poViewModel)
        {
            try
            {
                this.oModel = this.db.Transaction_inds.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
                //Process CRUD
                this.db.Entry(oModel).State = EntityState.Modified;
                this.db.SaveChanges();
                this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                this.oModel = this.db.Transaction_inds.Find(id);
                this.db.Transaction_inds.Remove(oModel);
                this.db.SaveChanges();
                this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
    } //End public class Transaction_indCRUD
} //End namespace APPBASE.Models
