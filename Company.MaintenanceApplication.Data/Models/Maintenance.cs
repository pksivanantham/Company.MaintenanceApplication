namespace Company.MaintenanceApplication.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maintenance")]
    public partial class Maintenance
    {
        public int MaintenanceID { get; set; }

        [StringLength(1000)]
        public string EquipmentTag { get; set; }

        [StringLength(1000)]
        public string EquipmentName { get; set; }

        [StringLength(1000)]
        public string AttendedBy { get; set; }

        public DateTime? AttendedDate { get; set; }

        [StringLength(1000)]
        public string Action { get; set; }

        [StringLength(1000)]
        public string Material { get; set; }

        [StringLength(1000)]
        public string PlantType { get; set; }
    }
}
