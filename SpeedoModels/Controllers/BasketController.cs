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
    /// <summary>
    /// Class BasketController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BasketController : Controller
    {
        /// <summary>
        /// Adds to basket.
        /// </summary>
        /// <param name="product">The product.</param>
        [HttpPost]
        public void AddToBasket(Product product)
        {
            Basket basket = new Basket();
            List<Product> products = new List<Product>();

            //gets url of previous page
            string previousPage = (string)Session["Referrer"];

            //assigns basket id from user identity
            basket.CustomerId = User.Identity.GetUserId();

            //gets basketjson from GetBasket method
            JsonResult basketJsonResult = GetBasket();
            Basket loadedBasket = (Basket)basketJsonResult.Data;

            //if there are no product in the basket create new basket cookie and add product, else add new product or update product quantity in existing product
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

                //for every product in the basket 
                foreach (Product productLoop in basket.Products.ToList())
                {
                    //if the previous page session isn't null and the previous page was ViewBasket and a product, the current productLoop quantity becomes the product quantity
                    if (previousPage != null && previousPage.Equals("ViewBasket") && product.Id == productLoop.Id)
                    {
                        productLoop.Quantity = product.Quantity;
                    }
                    //if product exists update productLoop quantity
                    else if (product.Id == productLoop.Id)
                    {
                        productLoop.Quantity += product.Quantity;
                    }
                    //if previous page is just the product id, add new product to basket
                    else if(previousPage.Equals(Convert.ToString(product.Id)))
                    {
                        basket.Products.Add(product);
                        break;
                    }
                }
                
                string basketJson = new JavaScriptSerializer().Serialize(basket);
                cookie = new HttpCookie("Basket", basketJson)
                {
                    Expires = DateTime.Now.AddHours(1)
                };

                Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// Gets the basket.
        /// </summary>
        /// <returns>JsonResult.</returns>
        public JsonResult GetBasket()
        {
            Basket basket;
            var cookie = Request.Cookies["Basket"];

            //gets basket from cookie, if empty creates new basket
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

        /// <summary>
        /// Removes the item from basket.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpPost]
        public void RemoveItemFromBasket(int id)
        {
            Basket basket = new Basket();

            var cookie = Request.Cookies["Basket"];

            basket = new JavaScriptSerializer().Deserialize<Basket>(cookie.Value);

            //loops through each product in basket, and if passed in id matches remove it from the basket.
            foreach (Product product in basket.Products.ToList())
            {
                if (product.Id == id)
                {
                    basket.Products.Remove(product);
                    

                    //if there are still products in the basket, update cookie
                    if (basket.Products.Count > 0)
                    {
                        string basketJson = new JavaScriptSerializer().Serialize(basket);
                        cookie = new HttpCookie("Basket", basketJson)
                        {
                            Expires = DateTime.Now.AddHours(1)
                        };

                        HttpContext.Response.SetCookie(cookie);
                    }
                    //if there are no products in the basket force the cookie to expire
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

        /// <summary>
        /// Clears the basket.
        /// </summary>
        public void ClearBasket()
        {
            var cookie = new HttpCookie("Basket")
            {
                Expires = DateTime.Now.AddHours(-1)
            };

            HttpContext.Response.SetCookie(cookie);
            
        }

        /// <summary>
        /// Views the basket.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewBasket()
        { 
            return View();
        }


    }
}