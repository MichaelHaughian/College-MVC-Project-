using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SpeedoModels.Models;

namespace SpeedoModels.ViewModels
{
    /// <summary>
    /// Class EditProductViewModel.
    /// </summary>
    public class EditProductViewModel
    {
        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>The supplier.</value>
        public Supplier Supplier { get; set; }
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditProductViewModel"/> class.
        /// </summary>
        public EditProductViewModel()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditProductViewModel"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public EditProductViewModel(Product product)
        {
            Mapper.Map<Product, Product>(product);
        }
    }
}