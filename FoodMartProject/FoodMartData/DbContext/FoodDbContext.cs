using FoodMartDomain.Cart;
using FoodMartModel;
using FoodMartModel.Models;
using FoodMartModel.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodMartInfrastructure.DbContext
{
    public class FoodDbContext : IdentityDbContext<User>
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) 
            : base(options)
        {
        }

        public DbSet<History> Histories { get; set; }
        public DbSet<Categories> Categories { get; set; }
       // public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                  new IdentityRole() { Name = "User", ConcurrencyStamp = "0", NormalizedName = "User" },
                  new IdentityRole() { Name = "Vendor", ConcurrencyStamp = "1", NormalizedName = "Vendor" }
                );
        }

    }
}
