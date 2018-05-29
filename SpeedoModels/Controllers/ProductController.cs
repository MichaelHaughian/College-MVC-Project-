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
    /// <summary>
    /// Class ProductController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ProductController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Index()
        {
            return View("StaffProductList");
        }

        /// <summary>
        /// Views the products.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewProducts()
        {
            

            return View();
        }

        /// <summary>
        /// Views the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewProduct(int id)
        {
            ViewBag.productId = id;

            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
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