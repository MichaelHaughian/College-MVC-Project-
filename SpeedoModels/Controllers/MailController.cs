using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Postal;
using SpeedoModels.Models;

namespace SpeedoModels.Controllers
{
    public class MailController : Controller
    {
        private ApplicationDbContext _context;

        public MailController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Mail
        public void SendOrderConfirmation()
        {
            string userId = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Id == userId);

            dynamic email = new Email("SendOrderConfirmation");
            email.To = user.Email;
            email.Send();

        }

        public void SendOrderCancellation()
        {
            string userId = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Id == userId);

            dynamic email = new Email("SendOrderCancellation");
            email.To = user.Email;
            email.Send();
        }
    }
}