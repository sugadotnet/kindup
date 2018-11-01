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
        //HEADER
        protected Transaction_indetailVM _HEADER_data;
        public Transaction_indetailVM HEADER_data { set { this._HEADER_data = value; } }

        //DETAIL
        protected Transaction_inddetailVM _DETAIL_data;
        public Transaction_inddetailVM DETAIL_data { set { this._DETAIL_data = value; } }
        //DETAIL list
        protected List<Transaction_inddetailVM> _DETAIL_datalist;
        public List<Transaction_inddetailVM> DETAIL_datalist { set { this._DETAIL_datalist = value; } }

        //INSTALLEMNT / HEADER PENDAFTARAN
        protected Installment_indetailVM _HEADER_inst_data;
        public Installment_indetailVM HEADER_inst_data { set { this._HEADER_inst_data = value; } }
    } //End Method
} //End namespace APPBASE.Models
