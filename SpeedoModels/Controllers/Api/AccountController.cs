using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using SpeedoModels.Models;

namespace SpeedoModels.Controllers.Api
{
    public class AccountController : ApiController
    {
        private ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult ViewAccounts()
        {
            var accounts = _context.Users.Where(c => c.IsRegistered).ToList();

            return Ok(accounts);
        }



        [System.Web.Http.HttpDelete]
        public void DeleteAccount(string id)
        {
            var account = _context.Users.SingleOrDefault(c => c.Id == id);

            account.IsRegistered = false;

            _context.SaveChanges();
        }

    }
}