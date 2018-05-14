using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public int TrackingNumber { get; set; }

        public DateTime DateOfReturn { get; set; }

        public string ReasonForReturn { get; set; }

        public string ConditionOfItem { get; set; }

        public ICollection<Orderline> OrderLines { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }

        public Order()
        {
            DateOfReturn = DateTime.Parse("01/01/2000");
            TrackingNumber = 0;
            ReasonForReturn = "";
            ConditionOfItem = "";
            OrderLines = null;
            OrderTotal = 0;
        }
    }
}