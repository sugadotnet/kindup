using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcbiz;


namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class Transaction_insppController : Transaction_inController
    {
        //SERVICE Header
        protected Transaction_in_worker oSERVICE_worker;
        protected Transaction_in_mapper oSERVICE_mapper;
        //SERVICE Detail
        protected Transaction_ind_worker oSERVICE_worker_detail;
        protected Transaction_ind_mapper oSERVICE_mapper_detail;
        //DS
        protected Installment_inDS oDS_inst;
        //OBL
        protected Transaction_insppBL oBL_trn;

        //Init
        protected override void initConstructor(DBMAINContext poDB)
        {
            base.initConstructor(poDB);
            //SERVICE Header
            this.oSERVICE_worker = new Transaction_in_worker();
            this.oSERVICE_mapper = new Transaction_in_mapper();
            //SERVICE Detail
            this.oSERVICE_worker_detail = new Transaction_ind_worker();
            this.oSERVICE_mapper_detail = new Transaction_ind_mapper();

            //BL
            this.oBL_trn = new Transaction_insppBL(poDB);
            //DS
            oDS_inst = new Installment_inDS(poDB);
            //OTHERS
            this.oDatastudent.DETAIL.STUDENTSTS_ID = 4; //Calon Siswa
        } //End initConstructor
        //Constructor 1
        public Transaction_insppController(): base()
        {
            //DBContext
            //this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public Transaction_insppController(DBMAINContext poDB): base(poDB)
        {
            //DBContext
            //this.initConstructor(poDB);
        } //End Constructor 2
    } //End Controller
} //End namespace
