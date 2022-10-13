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


        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

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

    public class OrderMetadata
    {
        public int OrderId { get; set; } //PK

        [StringLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string UserId { get; set; } = null!;

        [Required(ErrorMessage = "*Order Date is required")]
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)] //{0:d} = MM/dd/yyyy
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "*Shipped To is required")]
        [Display(Name = "Shipped To")]
        [StringLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string ShipToName { get; set; } = null!;

        [Required(ErrorMessage = "*City is required")]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string ShipCity { get; set; } = null!;

        [Display(Name = "State")]
        [StringLength(2, ErrorMessage = "Cannot exceed 2 characters")]
        public string? ShipState { get; set; }

        [Required(ErrorMessage = "*Zip is required")]
        [Display(Name = "Shipped To")]
        [StringLength(5, ErrorMessage = "Cannot exceed 5 characters")]
        [DataType(DataType.PostalCode)]
        public string ShipZip { get; set; } = null!;
    }

    //public class OrderEquipmentMetadata
    //{
    //    public int OrderEquipmentId { get; set; }//PK

    //    [Required(ErrorMessage = "*ID is required")]
    //    [Display(Name = "ID")]
    //    public int EquipmentId { get; set; }

    //    [Required(ErrorMessage = "*Order")]
    //    public int OrderId { get; set; }
    //    public short? Quantity { get; set; }
    //    public decimal? EquipmentPrice { get; set; }
    //}

}
