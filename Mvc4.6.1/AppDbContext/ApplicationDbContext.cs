using Microsoft.AspNet.Identity.EntityFramework;
using MvcDemo.Identity.Models;
using MvcDemo.Models;

namespace MvcDemo.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}