using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    /// <summary>
    /// Class Supplier.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Display(Name = "Supplier Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
    }
}