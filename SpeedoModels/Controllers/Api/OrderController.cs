using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SpeedoModels.Models;

namespace SpeedoModels.Controllers.Api
{
    public class OrderController : ApiController
    {
        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Http.HttpPost]
        public void CreateOrder(JsonResult basketJsonResult)
        {
            string basketString = basketJsonResult.ToString();
            Basket basket = new JavaScriptSerializer().Deserialize<Basket>(basketString);
            Order order = new Order();
            List<Orderline> orderlines = new List<Orderline>();

            foreach (Product product in basket.Products)
            {
                Orderline orderline = new Orderline();

                orderline.Product = product;
                orderline.Quantity = product.Quantity;
                orderline.LineTotal = product.Price * product.Quantity;
                order.OrderTotal += orderline.LineTotal;

                orderlines.Add(orderline);
            }

            order.OrderLines = orderlines;

            _context.Orders.Add(order);

            _context.SaveChanges();
        }
    }
}
