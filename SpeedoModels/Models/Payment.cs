using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    /// <summary>
    /// Class Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the payment total.
        /// </summary>
        /// <value>The payment total.</value>
        public decimal PaymentTotal { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>The payment date.</value>
        public DateTime PaymentDate { get; set; }
    }
}