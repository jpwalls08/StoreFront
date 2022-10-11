using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; //Added to create allow IFormFile type
using Microsoft.AspNetCore.Mvc;//Added this using statement automatically -- We typed [ModelMetadataType] over a partial
using System.ComponentModel.DataAnnotations.Schema;


namespace StoreFront.DATA.EF.Models//.Metadata
{
    //public class Partials
    //{
    //}

    [ModelMetadataType(typeof(EquipmentMetadata))]
    public partial class Equipment { }

    public partial class Equipment
    {
        [NotMapped] //Access to that property and not hooked up to our DB
        public IFormFile? Image { get; set; }
    }

    [ModelMetadataType(typeof(EquipmentTypesMetadata))]
    public partial class EquipmentTypes { }

    [ModelMetadataType(typeof(EquipmentStatusMetadata))]
    public partial class EquipmentStatus { }

    [ModelMetadataType(typeof(GolfStoresMetadata))]
    public partial class GolfStores { }
}
