using System;
using System.Collections.Generic;
using System.Linq;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Transaction_inBL
    {
        private Boolean saveDETAIL()
        {
            //HEADER
            this._HEADER_result.ID = _CRUD.ID;
            this._HEADER_inst_result.ID = _CRUD_inst.ID;
            //DETAIL
            foreach (var item in this._DETAIL_resultlist)
            {
                item.TRN_ID = this._HEADER_result.ID;
                item.INST_ID = this._HEADER_inst_result.ID;
                //Code detail mapping here...

                //this._DETAIL_resultlist.Add(item);
                this._DETAIL_result = item;
                this._CRUD_detail.Create(this._DETAIL_result);
                if (_CRUD_detail.isERR)
                {
                    _CRUD.Delete(this._HEADER_result.ID);
                    _CRUD_inst.Delete(this._HEADER_inst_result.ID);
                    return false;
                } //End if
            } //End foreach
            //Return
            return true;
        } //End Method
    } //End Method
} //End namespace APPBASE.Models
