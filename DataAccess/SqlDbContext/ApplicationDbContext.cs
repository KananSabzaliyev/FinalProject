using Entities.Concrete.Models;
using Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.SqlDbContext
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Localhost; Initial Catalog = CarDb; Integrated Security = true;Trust Server Certificate = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBody> CarBodies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
