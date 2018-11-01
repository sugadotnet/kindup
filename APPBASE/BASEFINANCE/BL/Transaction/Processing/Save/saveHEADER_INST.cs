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
        private Boolean saveHEADER_INST() {
            //HEADER
            if (this._HEADER_inst_result.DTA_STS == 1)
                this._CRUD_inst.Create(this._HEADER_inst_result);
            else
                this._CRUD_inst.Update(this._HEADER_inst_result);

            if (this._CRUD_inst.isERR) return false;
            //Return
            return true;
        } //End Method
    } //End Method
} //End namespace APPBASE.Models
