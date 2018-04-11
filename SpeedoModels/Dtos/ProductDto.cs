using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpeedoModels.Models;

namespace SpeedoModels.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Colour { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int? ReorderQuantity { get; set; }

        public SupplierDto Supplier { get; set; }

        public DateTime? DeliveryLeadTimes { get; set; }
    }
}