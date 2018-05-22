using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Colour { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int Stock { get; set; }

        public int? ReorderQuantity { get; set; }

        public string DeliveryLeadTimes { get; set; }

        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }
    }
}