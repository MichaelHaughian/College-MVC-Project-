using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.UI.WebControls;
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

        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.Include(c => c.Supplier).SingleOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        public IHttpActionResult SaveProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (productDto.Id == 0)
            {
                var product = Mapper.Map<ProductDto, Product>(productDto);

                var supplier = _context.Suppliers.Single(c => c.Id == product.SupplierId);
                product.Supplier = supplier;
                _context.Products.Add(product);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("AN ERROR HAS OCCURED: '{0}'", ex.InnerException.ToString()); }



                productDto.Id = product.Id;

                return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
            }
            else
            {
                var product = _context.Products.SingleOrDefault(c => c.Id == productDto.Id);

                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                Mapper.Map(productDto, product);

                _context.SaveChanges();

                return Ok();
            }
        }

        /*[HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = Mapper.Map<ProductDto, Product>(productDto);

            var supplier = _context.Suppliers.Single(c => c.Id == product.SupplierId);
            product.Supplier = supplier;
            _context.Products.Add(product);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("AN ERROR HAS OCCURED: '{0}'", ex.InnerException.ToString()); }

            

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }*/

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }

        /*[HttpPost]
        public void EditProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var product = _context.Products.SingleOrDefault(c => c.Id == productDto.Id);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(productDto, product);

            _context.SaveChanges();
        }*/
    }
}
