using System;
using System.Collections.Generic;

namespace StoreFront.UI.MVC.Models
{
    public partial class EquipmentType
    {
        public EquipmentType()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int EquipmentTypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
