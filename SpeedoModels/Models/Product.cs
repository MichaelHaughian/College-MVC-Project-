using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    /// <summary>
    /// Class Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the colour.
        /// </summary>
        /// <value>The colour.</value>
        [Required]
        public string Colour { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        /// <value>The stock.</value>
        [Required]
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the reorder quantity.
        /// </summary>
        /// <value>The reorder quantity.</value>
        public int? ReorderQuantity { get; set; }

        /// <summary>
        /// Gets or sets the delivery lead times.
        /// </summary>
        /// <value>The delivery lead times.</value>
        public string DeliveryLeadTimes { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>The supplier.</value>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        public int SupplierId { get; set; }
    }
}