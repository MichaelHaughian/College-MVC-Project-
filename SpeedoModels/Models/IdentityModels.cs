using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpeedoModels.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// Class ApplicationUser.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {
        //PUT NEW ATTRIBUTES HERE
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the first line of address.
        /// </summary>
        /// <value>The first line of address.</value>
        public string FirstLineOfAddress { get; set; }
        /// <summary>
        /// Gets or sets the second line of address.
        /// </summary>
        /// <value>The second line of address.</value>
        public string SecondLineOfAddress { get; set; }
        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        public string Postcode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is registered.
        /// </summary>
        /// <value><c>true</c> if this instance is registered; otherwise, <c>false</c>.</value>
        public bool IsRegistered { get; set; } = true;

        /// <summary>
        /// generate user identity as an asynchronous operation.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Task&lt;ClaimsIdentity&gt;.</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// Class ApplicationDbContext.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{SpeedoModels.Models.ApplicationUser}" />
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public DbSet<Supplier> Suppliers { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public DbSet<Order> Orders { get; set; }
        /// <summary>
        /// Gets or sets the orderlines.
        /// </summary>
        /// <value>The orderlines.</value>
        public DbSet<Orderline> Orderlines { get; set; }
        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        public DbSet<Payment> Payments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationDbContext.</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}