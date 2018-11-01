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
        protected Transaction_inCRUD _CRUD;
        public Transaction_inCRUD CRUD { get { return this._CRUD; } set { this._CRUD = value; } }

        //DETAIL
        protected Transaction_indCRUD _CRUD_detail;
        public Transaction_indCRUD CRUD_detail { get { return this._CRUD_detail; } set { this._CRUD_detail = value; } }

        //INSTALLEMNT / HEADER PENDAFTARAN
        protected Installment_inCRUD _CRUD_inst;
        public Installment_inCRUD CRUD_inst { get { return this._CRUD_inst; } set { this._CRUD_inst = value; } }

    } //End Method
} //End namespace APPBASE.Models
