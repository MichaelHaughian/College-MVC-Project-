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
    public class SMSController : Controller
    {
        private ApplicationDbContext _context;

        public SMSController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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