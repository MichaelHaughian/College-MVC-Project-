using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Postal;

namespace SpeedoModels.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public void SendOrderConfirmation()
        {
            dynamic email = new Email("SendOrderConfirmation");
            email.To = "michaelh1996@msn.com";
            email.Send();

        }

        public void SendOrderCancellation()
        {
            dynamic email = new Email("SendOrderCancellation");
            email.To = "michaelh1996@msn.com";
            email.Send();
        }
    }
}