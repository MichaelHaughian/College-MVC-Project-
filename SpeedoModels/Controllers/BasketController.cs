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

            JsonResult basketJsonResult = GetBasket();
            Basket loadedBasket = (Basket)basketJsonResult.Data;
            if (loadedBasket.Products == null)
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

        public JsonResult GetBasket()
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

            return Json(basket, JsonRequestBehavior.AllowGet);
        }

        public void RemoveItemFromBasket(int id, int quantity)
        {

        }

        public ActionResult ViewBasket()
        { 
            return View();
        }


    }
}