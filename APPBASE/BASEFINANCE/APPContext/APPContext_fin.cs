using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Models
{
    public partial class DBMAINContext : DbContext
    {
        //CFG - Mainconfig
        public DbSet<Mainconfig> Mainconfigs { get; set; }
        public DbSet<Mainconfig_info> Mainconfig_infos { get; set; }
        //Monthspp
        public DbSet<Monthspp> Monthspps { get; set; }
        //Trintype
        public DbSet<Trintype> Trintypes { get; set; }


        //Transaction_in
        public DbSet<Transaction_in> Transaction_ins { get; set; }
        public DbSet<Transaction_in_info> Transaction_in_infos { get; set; }
        //Transaction_ind
        public DbSet<Transaction_ind> Transaction_inds { get; set; }
        public DbSet<Transaction_ind_info> Transaction_ind_infos { get; set; }

        //Installment_in
        public DbSet<Installment_in> Installment_ins { get; set; }
        public DbSet<Installment_in_info> Installment_in_infos { get; set; }
        //Installment_ind
        public DbSet<Installment_ind> Installment_inds { get; set; }
        public DbSet<Installment_ind_info> Installment_ind_infos { get; set; }
    }
} //End public class DBMAINContext : DbContext} //End namespace APPBASE.Models