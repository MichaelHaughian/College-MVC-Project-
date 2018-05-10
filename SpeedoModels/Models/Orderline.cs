using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    public class Orderline
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal LineTotal { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
    }
}