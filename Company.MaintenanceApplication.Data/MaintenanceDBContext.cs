using Company.MaintenanceApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data
{
   public  class MaintenanceDBContext:DbContext
    {
        public MaintenanceDBContext() : base("name=MaintenanceDBContext")
        {
        }

        public virtual DbSet<EquipmentMaster> EquipmentMaster { get; set; }
        public virtual DbSet<EquipmentTagMaster> EquipmentTagMaster { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
