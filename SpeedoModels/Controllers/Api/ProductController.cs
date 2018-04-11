using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AutoMapper;
using SpeedoModels.Dtos;
using SpeedoModels.Models;
using SpeedoModels.ViewModels;

namespace SpeedoModels.Controllers.Api
{
    public class ProductController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetProducts()
        {
            var productDtos = _context.Products.Include(c => c.Supplier).ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = Mapper.Map<ProductDto, Product>(productDto);

            var supplier = _context.Suppliers.Single(c => c.Id == product.SupplierId);
            product.Supplier = supplier;
            _context.Products.AddOrUpdate(product);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("AN ERROR HAS OCCURED: '{0}'", ex.InnerException.ToString()); }

            

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }
    }
}
