using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
//using AutoMapper;
using SpeedoModels.Models;

namespace SpeedoModels.ViewModels
{
    /// <summary>
    /// Class CreateProductViewModel.
    /// </summary>
    public class CreateProductViewModel
    {
        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public IEnumerable<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

    }
}