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
    /// <summary>
    /// Class MailController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class MailController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailController"/> class.
        /// </summary>
        public MailController()
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
        /// Sends the order confirmation.
        /// </summary>
        public void SendOrderConfirmation()
        {
            string userId = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Id == userId);

            dynamic email = new Email("SendOrderConfirmation");
            email.To = user.Email;
            email.Send();

        }

        /// <summary>
        /// Sends the order cancellation.
        /// </summary>
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