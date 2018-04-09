using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
//using AutoMapper;
using SpeedoModels.Models;

namespace SpeedoModels.ViewModels
{
    public class CreateProductViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }

        public Product Product { get; set; }

        public CreateProductViewModel(Product product)
        {
            Mapper.Map<Product, Product>(product);
        }

        public CreateProductViewModel()
        {
            
        }
    }
}