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
    public class Spp_paymentDS
    {
        protected DBMAINContext db;
        protected List<Monthly_paymentVM> oData_results;

        protected List<StudentlistitemVM> oData_students;
        protected List<MonthsppVM> oData_months;
        protected List<Transaction_inddetailVM> oData_transactions;
        
        //Constructor 1
        public Spp_paymentDS() { this.db = new DBMAINContext(); } //End Constructor
        //Constructor 2
        public Spp_paymentDS(DBMAINContext poDB) { this.db = poDB; }  //End Constructor
        //Constructor 3
        public Spp_paymentDS(DBMAINContext poDB,
            List<StudentlistitemVM> poViewModel_students,
            List<MonthsppVM> poViewModel_months,
            List<Transaction_inddetailVM> poViewModel_transactions) {

            this.db = poDB;
            this.oData_students = poViewModel_students;
            this.oData_months = poViewModel_months;
            this.oData_transactions = poViewModel_transactions;
        }  //End Constructor

        public List<Monthly_paymentVM> getdatalist() {
            this.oData_results = new List<Monthly_paymentVM>();
            foreach (var item_student in oData_students)
            {
                Monthly_paymentVM Result_item = new Monthly_paymentVM();
                Result_item.STUDENT = new StudentlistitemVM();
                Result_item.STUDENT.InjectFrom(item_student);

                Result_item.MONTHS = new List<MonthsppVM>();
                foreach (var item_month in this.oData_months)
                {
                    MonthsppVM oMonth = new MonthsppVM();
                    oMonth.InjectFrom(item_month);
                    Result_item.MONTHS.Add(oMonth);
                } //end loop

                //Result_item.MONTHS = this.oData_months;
                var TRANSACTIONS = this.oData_transactions
                    .Where(fld =>
                    fld.STUDENT_ID == item_student.ID &&
                    fld.TRND_TYPEID == valFLAG.FLAG_TRINTYPE_SPP &&
                    fld.TRND_ITEMID != null &&
                    fld.TRND_QTY != null).OrderBy(fld => fld.TRND_ITEMID).ToList();

                foreach (var item_trn in TRANSACTIONS) {
                    int nStart = (int)item_trn.TRND_ITEMID;
                    int nQty = (int)item_trn.TRND_QTY;
                    int nLength = nStart + nQty;
                    for (int i = nStart; i < nLength; i++)
                    {
                        int nIndex = Result_item.MONTHS.FindIndex(fld => fld.ID == i);
                        Result_item.MONTHS[nIndex].ISPAYED = 1;
                    } //end loop
                } //end loop
                this.oData_results.Add(Result_item);

            } //end loop

            //Return
            return this.oData_results;
        } //end if
    } //End public class Transaction_inDS
} //End namespace APPBASE.Models
