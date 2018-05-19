using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal PaymentTotal { get; set; }

        public Customer Customer { get; set; }

        public string CustomerId { get; set; }

        public Order Order { get; set; }

        public int OrderId { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}