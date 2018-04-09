using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public IHttpActionResult GetProducts(string query = null)
        {
            var productsQuery = _context.Products.Include(c => c.);

            if (!String.IsNullOrWhiteSpace(query))
                productsQuery = productsQuery.Where(c => c.Name.Contains(query));

            var customerDtos = productsQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = Mapper.Map<ProductDto, Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }
    }
}
