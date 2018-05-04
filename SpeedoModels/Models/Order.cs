using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TrackingNumber { get; set; }

        public DateTime DateOfReturn { get; set; }

        public string ReasonForReturn { get; set; }

        public string ConditionOfItem { get; set; }

        [Required]
        public ICollection<Orderline> OrderLines { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }
    }
}