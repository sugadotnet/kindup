using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Transaction_inBL
    {
        //Error
        protected string _ERRMSG_result;
        public string ERRMSG_result { get; set; }
        protected Boolean _RESULT;
        public Boolean RESULT { get { return this._RESULT; } }

        //HEADER
        protected Transaction_indetailVM _HEADER_result;
        public Transaction_indetailVM HEADER_result { get { return this._HEADER_result; } set { this._HEADER_result = value; } }
        //DETAIL
        protected Transaction_inddetailVM _DETAIL_result;
        public Transaction_inddetailVM DETAIL_result { get { return this._DETAIL_result; } set { this._DETAIL_result = value; } }
        //DETAIL list
        protected List<Transaction_inddetailVM> _DETAIL_resultlist;
        public List<Transaction_inddetailVM> DETAIL_resultlist { get { return this._DETAIL_resultlist; } set { this._DETAIL_resultlist = value; } }

        //INSTALLEMNT / HEADER PENDAFTARAN
        protected Installment_indetailVM _HEADER_inst_result;
        public Installment_indetailVM HEADER_inst_result { get { return this._HEADER_inst_result; } set { this._HEADER_inst_result = value; } }
    } //End Method
} //End namespace APPBASE.Models
