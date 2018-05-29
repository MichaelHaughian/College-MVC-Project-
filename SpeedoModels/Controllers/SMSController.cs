using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Nexmo.Api;
using SpeedoModels.Models;
using SpeedoModels.ViewModels;

namespace SpeedoModels.Controllers
{
    /// <summary>
    /// Class SMSController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class SMSController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SMSController"/> class.
        /// </summary>
        public SMSController()
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
        /// Sends the order message.
        /// </summary>
        public void SendOrderMessage()
        {
            string userId = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Id == userId);
            string telNo = user.PhoneNumber.Substring(1);
            string formattedTelNo = "+44" + telNo;

            var results = SMS.Send(new SMS.SMSRequest
            {
                from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                to = formattedTelNo,
                text = "thanks for your order"
            });
        }

        /// <summary>
        /// Sends the cancel message.
        /// </summary>
        public void SendCancelMessage()
        {
            string userId = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Id == userId);
            string telNo = user.PhoneNumber.Substring(1);
            string formattedTelNo = "+44" + telNo;

            var results = SMS.Send(new SMS.SMSRequest
            {
                from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                to = formattedTelNo,
                text = "Your order has been cancelled"
            });
        }
    }
}