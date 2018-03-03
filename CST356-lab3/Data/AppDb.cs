using CST356_lab3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CST356_lab3.Data
{
    public class AppDb : DbContext
    {
        public AppDb()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Classes> Classes { get; set; }

        public System.Data.Entity.DbSet<CST356_lab3.ViewModel.ViewUserModel> ViewUserModels { get; set; }

        public System.Data.Entity.DbSet<CST356_lab3.ViewModel.ViewClassesModel> ViewClassesModels { get; set; }

        public System.Data.Entity.DbSet<CST356_lab3.Data.Entities.BootStrap> BootStraps { get; set; }
    }
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDb>
    {
        // intentionally left blank
    }
}