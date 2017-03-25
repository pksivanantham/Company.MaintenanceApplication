namespace Company.MaintenanceApplication.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipmentMaster")]
    public partial class EquipmentMaster
    {
        [Key]
        public int EquipmentID { get; set; }

        [StringLength(1000)]
        public string EquipmentTag { get; set; }

        [StringLength(1000)]
        public string EquipmentName { get; set; }

        [StringLength(1000)]
        public string PlantType { get; set; }
    }
}
