using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA.EF.Models//.Metadata
{
    public class EquipmentTypesMetadata
    {
        public int EquipmentTypeId { get; set; } //PK

        [Required(ErrorMessage = "*Equipment Type is required")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        [Display(Name = "Equipment Type")]
        public string TypeName { get; set; }

    }

    public class EquipmentMetadata
    {
        public int EquipmentId { get; set; } //PK

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Cannot exceed 200 characters")]
        [Display(Name = "Name")]
        public string EquipmentName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [Range(0, (double)decimal.MaxValue)]
        public int EquipmentPrice { get; set; }

        [StringLength(1500, ErrorMessage = "Cannot exceed 1500 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Equipment Description")]
        public string? EquipmentDescription { get; set; }
        
        public int? StoreId { get; set; }

        public int? EquipmentTypeId { get; set; }

        public int? StatusId { get; set; }

        [StringLength(100)]
        [Display(Name = "Image")]
        public string? ProductImage { get; set; }

    }

    public class EquipmentStatusMetadata
    {
        public int StatusId { get; set; } //PK


        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public string StatusName { get; set; }

    }

    public class GolfStoresMetadata
    {
        public int StoreId { get; set; } //PK

        [Required(ErrorMessage = "Store is required")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        [Display(Name = "Store")]
        public string StoreName { get; set; } = null!;


        //[Required(ErrorMessage = "Phone Number is required")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; } = null!;


        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string? Region { get; set; }


        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string? Country { get; set; }


        [StringLength(10, ErrorMessage = "Cannot exceed 10 characters")]
        [DataType(DataType.PostalCode)]
        public string? ZipCode { get; set; }


        [StringLength(10, ErrorMessage = "Cannot exceed 10 characters")]
        public string? State { get; set; }


        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string? Address { get; set; }

    }

}
