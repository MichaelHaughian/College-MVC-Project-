using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
        public void CreateOrder(Basket basket)
        {
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

                Product loadedProduct = _context.Products.SingleOrDefault(c => c.Id == product.Id);

                loadedProduct.Stock -= product.Quantity;

            }

            _context.Orders.Add(order);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
            }

            foreach (Orderline orderline in orderlines)
            {
                orderline.OrderId = order.Id;
                orderline.ProductId = orderline.Product.Id;
                orderline.Product = null;
                _context.Orderlines.Add(orderline);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
            }
        }
    }
}
