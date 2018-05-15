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
    public class OrderlineController : ApiController
    {
        private ApplicationDbContext _context;

        public OrderlineController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ViewOrder(int id)
        {
            var orderlines = _context.Orderlines.Where(c => c.OrderId == id).Include(c => c.Product).ToList();

            return Ok(orderlines);
        }
    }
}
