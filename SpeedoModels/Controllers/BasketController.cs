using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using SpeedoModels.Models;

namespace SpeedoModels.Controllers
{
    public class BasketController : Controller
    {
        [HttpPost]
        public void AddToBasket(Product product)
        {
            Basket basket = new Basket();
            List<Product> products = new List<Product>();

            if (GetBasket().Products == null)
            {
                products.Add(product);
                basket.Products = products;

                string basketJson = new JavaScriptSerializer().Serialize(basket);
                var cookie = new HttpCookie("Basket", basketJson)
                {
                    Expires = DateTime.Now.AddHours(1)
                };

                HttpContext.Response.SetCookie(cookie);
            }
            else
            {
                var cookie = Request.Cookies["Basket"];

                basket = new JavaScriptSerializer().Deserialize<Basket>(cookie.Value);

                basket.Products.Add(product);

                string basketJson = new JavaScriptSerializer().Serialize(basket);
                cookie = new HttpCookie("Basket", basketJson)
                {
                    Expires = DateTime.Now.AddHours(1)
                };

                HttpContext.Response.SetCookie(cookie);
            }

            
            
        }

        public Basket GetBasket()
        {
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

            return (basket);
        }

        public ActionResult ViewBasket()
        { 
            return View();
        }


    }
}