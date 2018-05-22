using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedoModels.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Stock()
        {
            return View();
        }
    }
}