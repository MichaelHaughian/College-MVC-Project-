using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedoModels.Controllers
{
    /// <summary>
    /// Class ReportController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ReportController : Controller
    {
        // GET: Report
        /// <summary>
        /// Stocks this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Stock()
        {
            return View();
        }
    }
}