﻿using System;
using System.Collections.Generic;

namespace StoreFront.UI.MVC.Models
{
    public partial class Equipment
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
        public decimal EquipmentPrice { get; set; }
        public string? EquipmentDescription { get; set; }
        public int? StoreId { get; set; }
        public int? EquipmentTypeId { get; set; }
        public int? StatusId { get; set; }

        public virtual EquipmentType? EquipmentType { get; set; }
        public virtual EquipmentStatus? Status { get; set; }
        public virtual GolfStore? Store { get; set; }
    }
}
