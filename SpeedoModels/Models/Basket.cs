using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    /// <summary>
    /// Class Basket.
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public string CustomerId { get; set; }
    }
}