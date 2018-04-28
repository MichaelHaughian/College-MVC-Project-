using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SpeedoModels.Models;

namespace SpeedoModels.ViewModels
{
    public class EditProductViewModel
    {
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }

        public EditProductViewModel()
        {
            
        }

        public EditProductViewModel(Product product)
        {
            Mapper.Map<Product, Product>(product);
        }
    }
}