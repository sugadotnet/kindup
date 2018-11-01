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

namespace APPBASE.Models
{
    public class ClassroomDS
    {
        private DBMAINContext db;

        //Constructor 1
        public ClassroomDS() {
            this.db = new DBMAINContext();
        } //End public ClassroomDS
        //Constructor 2
        public ClassroomDS(DBMAINContext poDB)
        {
            this.db = poDB;
        } //End public ClassroomDS
        public List<ClassroomlistVM> getDatalist()
        {
            List<ClassroomlistVM> vReturn;
            var oQRY = from tb in db.Classrooms
                       select new ClassroomlistVM
                       {
                           ID = tb.ID,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<ClassroomlistVM> getDatalist()
        public ClassroomdetailVM getData(int? id = null)
        {
            ClassroomdetailVM oReturn;
            var oQRY = from tb in db.Classrooms
                       where tb.ID == id
                       select new ClassroomdetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSROOM_DESC = tb.CLASSROOM_DESC,
                           CLASSROOM_VOLUME = tb.CLASSROOM_VOLUME,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID
                       };
            oReturn = oQRY.SingleOrDefault();
            return oReturn;
        } //End public ClassroomdetailVM getData(int? id = null)

        public List<ClassroomlistVM> getDatalist_ByClassType(int? id = null)
        {
            List<ClassroomlistVM> vReturn = getDatalist();
            vReturn = vReturn.Where(f => f.CLASSTYPE_ID == id).ToList();
            return vReturn;
        } //End method

        public List<ClassroomlookupVM> getDatalist_lookup()
        {
            List<ClassroomlookupVM> vReturn;
            var oQRY = from tb in db.Classrooms
                       select new ClassroomlookupVM
                       {
                           ID = tb.ID,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<ClassroomlookupVM> getDatalist_lookup()
        public Select2VM getDatalist_select2ajax(string psSearch=null, int? idFilter1 = null)
        {
            Select2VM vReturn = new Select2VM();
            vReturn.items = new List<Select2detailVM>();
            List<ClassroomdetailVM> oTemp;


            var oQRY = from tb in db.Classrooms
                       select new ClassroomdetailVM
                       {
                           ID = tb.ID,
                           CLASSROOM_CODE = tb.CLASSROOM_CODE,
                           CLASSROOM_NAME = tb.CLASSROOM_NAME,
                           CLASSTYPE_ID = tb.CLASSTYPE_ID
                       };
            if ((psSearch != null) && (psSearch != "")) { oQRY = oQRY.Where(fld => (fld.CLASSROOM_CODE + fld.CLASSROOM_NAME).Contains(psSearch)); }
            if (idFilter1 != null) { oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == idFilter1); }
            oTemp = oQRY.ToList();

            vReturn.total_count = oTemp.Count;
            foreach (var item in oTemp)
            {
                Select2detailVM oItem = new Select2detailVM();
                oItem.id = item.ID.ToString();
                oItem.text = item.CLASSROOM_NAME;
                vReturn.items.Add(oItem);
            } //End foreach (var item in oTemp)
            return vReturn;
        } //End public Select2VM getDatalist_select2ajax()
    } //End public class ClassroomDS
} //End namespace APPBASE.Models
