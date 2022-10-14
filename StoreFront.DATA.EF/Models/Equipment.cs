using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            OrderEquipments = new HashSet<OrderEquipment>();
        }

        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
        public decimal EquipmentPrice { get; set; }
        public string? EquipmentDescription { get; set; }
        public int? StoreId { get; set; }
        public int? EquipmentTypeId { get; set; }
        public int? StatusId { get; set; }
        public string? ProductImage { get; set; }
        public int? UnitsInStock { get; set; }

        public virtual EquipmentType? EquipmentType { get; set; }
        public virtual EquipmentStatus? Status { get; set; }
        public virtual GolfStore? Store { get; set; }
        public virtual ICollection<OrderEquipment> OrderEquipments { get; set; }
    }
}
