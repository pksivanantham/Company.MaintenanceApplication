namespace Company.MaintenanceApplication.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipmentTagMaster")]
    public partial class EquipmentTagMaster
    {
        [Key]
        public int EquipmentTagID { get; set; }

        [StringLength(255)]
        public string EquipmentTag { get; set; }

        [StringLength(255)]
        public string PlantType { get; set; }
    }
}
