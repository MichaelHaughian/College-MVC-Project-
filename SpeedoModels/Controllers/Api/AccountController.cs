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
    /// <summary>
    /// Class AccountController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class AccountController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Views the accounts.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        [System.Web.Http.HttpGet]
        public IHttpActionResult ViewAccounts()
        {
            var accounts = _context.Users.Where(c => c.IsRegistered).ToList();

            return Ok(accounts);
        }



        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [System.Web.Http.HttpDelete]
        public void DeleteAccount(string id)
        {
            var account = _context.Users.SingleOrDefault(c => c.Id == id);

            account.IsRegistered = false;

            _context.SaveChanges();
        }

    }
}