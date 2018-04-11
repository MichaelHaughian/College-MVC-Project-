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
    public class SupplierController : ApiController
    {
        private ApplicationDbContext _context;

        public SupplierController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetSuppliersr()
        {
            var supplierDtos = _context.Suppliers.ToList();

            return Ok(supplierDtos);
        }
    }
}
