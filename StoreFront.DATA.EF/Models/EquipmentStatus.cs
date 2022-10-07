using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class EquipmentStatus
    {
        public EquipmentStatus()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
