using System;
using System.Collections.Generic;
using System.Linq;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Transaction_insppBL: Transaction_inBL
    {
        //Constructor 1
        public Transaction_insppBL(): base() { } //End Constructor
        //Constructor 2
        public Transaction_insppBL(DBMAINContext poDB) : base(poDB) { } //End Constructor
    } //End Class
} //End namespace APPBASE.Models
