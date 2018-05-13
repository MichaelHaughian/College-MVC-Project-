using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
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

            basket.CustomerId = User.Identity.GetUserId();
            JsonResult basketJsonResult = GetBasket();
            Basket loadedBasket = (Basket)basketJsonResult.Data;
            if (loadedBasket.Products == null)
            {
                products.Add(product);
                basket.Products = products;
                basket.CustomerId = User.Identity.GetUserId();

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

                foreach (Product productLoop in basket.Products.ToList())
                {
                    if (product.Id == productLoop.Id)
                    {
                        productLoop.Quantity += product.Quantity;
                    }
                    else
                    {
                        basket.Products.Add(product);
                    }
                }
                
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

        [HttpPost]
        public void RemoveItemFromBasket(int id)
        {
            Basket basket = new Basket();

            var cookie = Request.Cookies["Basket"];

            basket = new JavaScriptSerializer().Deserialize<Basket>(cookie.Value);

            foreach (Product product in basket.Products.ToList())
            {
                if (product.Id == id)
                {
                    basket.Products.Remove(product);
                    

                    if (basket.Products.Count > 0)
                    {
                        string basketJson = new JavaScriptSerializer().Serialize(basket);
                        cookie = new HttpCookie("Basket", basketJson)
                        {
                            Expires = DateTime.Now.AddHours(1)
                        };

                        HttpContext.Response.SetCookie(cookie);
                    }
                    else if(basket.Products.Count == 0)
                    {
                        string basketJson = new JavaScriptSerializer().Serialize(basket);
                        cookie = new HttpCookie("Basket", basketJson)
                        {
                            Expires = DateTime.Now.AddHours(-1)
                        };

                        HttpContext.Response.SetCookie(cookie);
                    }
                    
                }
            }
        }

        public void ClearBasket()
        {
            var cookie = new HttpCookie("Basket")
            {
                Expires = DateTime.Now.AddHours(-1)
            };

            HttpContext.Response.SetCookie(cookie);
            
        }

        public ActionResult ViewBasket()
        { 
            return View();
        }


    }
}