using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA.EF.Models//.Metadata
{
    //public class Partials
    //{
    //}

    [ModelMetadataType(typeof(EquipmentMetadata))]
    public partial class Equipment { }

    [ModelMetadataType(typeof(EquipmentTypesMetadata))]
    public partial class EquipmentTypes { }

    [ModelMetadataType(typeof(EquipmentStatusMetadata))]
    public partial class EquipmentStatus { }

    [ModelMetadataType(typeof(GolfStoresMetadata))]
    public partial class GolfStores { }
}
