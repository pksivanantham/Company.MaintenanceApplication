using Company.MaintenanceApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data
{
   public  class MaintenanceDBContext:DbContext, IMaintenanceDBContext
    {
        public MaintenanceDBContext() : base("name=MaintenanceDBContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        
        /// Commented this because we used repository pattern for access the Db layer

        //public virtual DbSet<EquipmentMaster> EquipmentMaster { get; set; }
        //public virtual DbSet<EquipmentTagMaster> EquipmentTagMaster { get; set; }
        //public virtual DbSet<Maintenance> Maintenance { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //We are using Code First approach to access the db
            modelBuilder.Entity<EquipmentMaster>().ToTable("EquipmentMaster");
            modelBuilder.Entity<EquipmentTagMaster>().ToTable("EquipmentTagMaster");
            modelBuilder.Entity<Maintenance>().ToTable("Maintenance");

            //To remove the convention that pluralizing the table names
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

       public new  IDbSet<T> Set<T>() where T:class
        {
            return base.Set<T>();
        }
    }
}
