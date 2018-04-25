using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SpeedoModels.Models;

namespace SpeedoModels.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public Product Product { get; set; }

        public ProductViewModel()
        {
            
        }

        public ProductViewModel(Product product)
        {
            Mapper.Map<Product, Product>(product);
        }
    }
}