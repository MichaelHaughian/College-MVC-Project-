using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SpeedoModels.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderPage()
        {
            
            return View();
        }

        public ActionResult SubmitOrder()
        {
            return View();
        }
    }
}