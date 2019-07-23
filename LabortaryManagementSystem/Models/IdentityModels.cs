using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LabortaryManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

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

        public DbSet<TestMaster> TestMasters { get; set; }
        public DbSet<SubTestMaster> SubTestMasters { get; set; }
        public DbSet<MainTest> MainTests { get; set; }
        public DbSet<TechnologiesMaster> TechnologiesMasters { get; set; }
        public DbSet<TestsValueMaster> TestsValueMasters { get; set; }
        public DbSet<PatientMaster> PatientMasters { get; set; }
        public DbSet<TestOrderMaster> TestOrderMasters { get; set; }
        public DbSet<TestOrderDetail> TestOrderDetails { get; set; }
    }
}