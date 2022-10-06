using System;
using System.Collections.Generic;

namespace StoreFront.UI.MVC.Models
{
    public partial class GolfStore
    {
        public GolfStore()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
