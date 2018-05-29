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
using Microsoft.AspNet.Identity;

namespace SpeedoModels.Controllers.Api
{
    /// <summary>
    /// Class OrderController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class OrderController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        public OrderController()
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
        /// Views the orders.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [System.Web.Http.HttpGet]
        public IHttpActionResult ViewOrders(string id)
        {

            var orders = _context.Orders.Where(c => c.CustomerId == id).ToList();

            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                orders = _context.Orders.ToList();

                return Ok(orders);
            }
            else 
            {
                foreach (Order order in orders.ToList())
                {
                    if (order.IsCancelled)
                    {
                        orders.Remove(order);
                    }
                }
            }
            

            return Ok(orders);
        }

        /// <summary>
        /// Views the order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/order/vieworder/{id}")]
        public IHttpActionResult ViewOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id== id);

            return Ok(order);
        }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="basket">The basket.</param>
        [System.Web.Http.HttpPost]
        public void CreateOrder(Basket basket)
        {
            Order order = new Order();
            Payment payment = new Payment();
            List<Orderline> orderlines = new List<Orderline>();

            order.CustomerId = basket.CustomerId;
            order.OrderDate = DateTime.Now.Date;
            Random rnd = new Random();
            order.TrackingNumber = rnd.Next(100000000, 999999999);
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

                _context.SaveChanges();

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

            payment.CustomerId = order.CustomerId;
            payment.OrderId = order.Id;
            payment.PaymentTotal = order.OrderTotal;
            payment.PaymentDate = DateTime.Now.Date;

            _context.Payments.Add(payment);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
            }
        }

        /// <summary>
        /// Cancels the order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [System.Web.Http.HttpDelete]
        public void CancelOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == id);
            order.OrderLines = _context.Orderlines.Where(c => c.OrderId == id).ToList();
            var product = new Product();

            order.IsCancelled = true;

            foreach (Orderline orderline in order.OrderLines)
            {
                product = _context.Products.SingleOrDefault(c => c.Id == orderline.ProductId);
                product.Stock += orderline.Quantity;
            }

            _context.SaveChanges();
        }
    }
}
