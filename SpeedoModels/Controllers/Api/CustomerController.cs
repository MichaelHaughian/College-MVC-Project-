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
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetCustomer(string id)
        {
            var customer = _context.Users.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

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
