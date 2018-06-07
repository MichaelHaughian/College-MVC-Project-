// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 05-15-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 05-29-2018
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeedoModels.Models;

namespace SpeedoModels.Controllers.Api
{
    /// <summary>
    /// Class OrderlineController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class OrderlineController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderlineController" /> class.
        /// </summary>
        public OrderlineController()
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
        /// Views the order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet]
        public IHttpActionResult ViewOrder(int id)
        {

            var order = _context.Orderlines.Where(c => c.OrderId == id).Include(c => c.Product).ToList();

            return Ok(order);
        }
    }
}
