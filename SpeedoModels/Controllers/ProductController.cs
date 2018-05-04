using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SpeedoModels.Models;
using SpeedoModels.ViewModels;
using System.Data.Entity;
using System.Net.Http;

namespace SpeedoModels.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View("StaffProductList");
        }

        public ActionResult ViewProducts()
        {
            

            return View();
        }

        public ActionResult ViewProduct(int id)
        {
            ViewBag.productId = id;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.productId = id;

            return View();
        }

        /*[HttpPost]
        public ActionResult Create(Product product)
        {
            //if ModelState isn't valid, redirect to create product page so use can try again
            if (!ModelState.IsValid)
            {
                var viewModel = new CreateProductViewModel(product)
                {
                    Suppliers = _context.Suppliers.ToList()
                };

                return View(viewModel);
            }

            if (product.Id == 0)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            return ("Create");
        }*/
    }
}