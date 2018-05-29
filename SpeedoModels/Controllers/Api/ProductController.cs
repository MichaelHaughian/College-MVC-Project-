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
using System.Web.Mvc;

namespace SpeedoModels.Controllers.Api
{
    /// <summary>
    /// Class ProductController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ProductController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetProducts()
        {
            var productDtos = _context.Products.Include(c => c.Supplier).ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.Include(c => c.Supplier).SingleOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns>IHttpActionResult.</returns>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
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

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        [System.Web.Http.HttpDelete]
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
    }
}
