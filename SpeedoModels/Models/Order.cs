using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    /// <summary>
    /// Class Order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Required]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the tracking number.
        /// </summary>
        /// <value>The tracking number.</value>
        public int TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the date of return.
        /// </summary>
        /// <value>The date of return.</value>
        public DateTime DateOfReturn { get; set; }

        /// <summary>
        /// Gets or sets the reason for return.
        /// </summary>
        /// <value>The reason for return.</value>
        public string ReasonForReturn { get; set; }

        /// <summary>
        /// Gets or sets the condition of item.
        /// </summary>
        /// <value>The condition of item.</value>
        public string ConditionOfItem { get; set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        /// <value>The order lines.</value>
        public ICollection<Orderline> OrderLines { get; set; }

        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        /// <value>The order total.</value>
        [Required]
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is cancelled.
        /// </summary>
        /// <value><c>true</c> if this instance is cancelled; otherwise, <c>false</c>.</value>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            DateOfReturn = DateTime.Parse("01/01/2000");
            OrderDate = DateTime.Parse("01/01/2000");
            TrackingNumber = 0;
            ReasonForReturn = "";
            ConditionOfItem = "";
            OrderLines = null;
            OrderTotal = 0;
        }
    }
}