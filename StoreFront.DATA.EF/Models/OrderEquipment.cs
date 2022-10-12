using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class OrderEquipment
    {
        public int OrderEquipmentId { get; set; }
        public int EquipmentId { get; set; }
        public int OrderId { get; set; }
        public short? Quantity { get; set; }
        public decimal? EquipmentPrice { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;
    }
}
