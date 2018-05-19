using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

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

    }
}