// ***********************************************************************
// Assembly         : SpeedoModels
// Author           : Michael Haughian
// Created          : 04-11-2018
//
// Last Modified By : Michael Haughian
// Last Modified On : 05-29-2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeedoModels.Models;
using System.Web.Mvc;

namespace SpeedoModels.Controllers.Api
{
    /// <summary>
    /// Class SupplierController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class SupplierController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierController" /> class.
        /// </summary>
        public SupplierController()
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
        /// Gets the suppliersr.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetSuppliersr()
        {
            var supplierDtos = _context.Suppliers.ToList();

            return Ok(supplierDtos);
        }
    }
}
