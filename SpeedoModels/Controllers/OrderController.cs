using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SpeedoModels.Models;
using Stripe;

namespace SpeedoModels.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        
        public ActionResult OrderPage()
        {
            Session["Referrer"] = "";

            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;

            return View();
        }

        public ActionResult SubmitOrder()
        {
            return View();
        }

        public ActionResult ViewOrders(string id)
        {
            if (id.Equals("0"))
            {
                id = User.Identity.GetUserId();
            }

            ViewBag.userId = JsonConvert.SerializeObject(id);

            return View();
        }

        public ActionResult ViewOrder(int id)
        {
            ViewBag.orderId = JsonConvert.SerializeObject(id);

            return View();
        }

        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            Basket basket;
            var cookie = Request.Cookies["Basket"];

            try
            {
                basket = new JavaScriptSerializer().Deserialize<Basket>(cookie.Value);
            }
            catch
            {
                basket = new Basket();
            }

            decimal basketTotal = 0;
            
            foreach (Product product in basket.Products.ToList())
            {
                basketTotal += product.Price;
            }

            int amount = (int)(basketTotal * 100);

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = amount,//charge in cents
                Description = "Speedo Models Checkout",
                Currency = "gbp",
                CustomerId = customer.Id
            });

            

            return View("SubmitOrder");
        }

    }
}