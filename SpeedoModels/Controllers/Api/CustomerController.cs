// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 05-02-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 05-29-2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeedoModels.Dtos;
using SpeedoModels.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Web;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Diagnostics;

namespace SpeedoModels.Controllers.Api
{
    /// <summary>
    /// Class CustomerController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class CustomerController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        public CustomerController()
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
        /// Gets the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetCustomer(string id)
        {
            var customer = _context.Users.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Edits the customer.
        /// </summary>
        /// <param name="customerDto">The customer dto.</param>
        /// <returns>IHttpActionResult.</returns>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        public IHttpActionResult EditCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = _context.Users.SingleOrDefault(c => c.Id == customerDto.Id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Mapper.Map(customerDto, customer);

            if (customer.UserName.Equals(customerDto.UserName))
            {
                //do nothing
            }
            else
            {
                customer.UserName = customerDto.UserName;
            }

            customer.Email = customerDto.Email;
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.FirstLineOfAddress = customerDto.FirstLineOfAddress;
            customer.SecondLineOfAddress = customerDto.SecondLineOfAddress;
            customer.Postcode = customerDto.Postcode;
            customer.PhoneNumber = customerDto.PhoneNumber;

            

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return Ok();
        }
    }
}
