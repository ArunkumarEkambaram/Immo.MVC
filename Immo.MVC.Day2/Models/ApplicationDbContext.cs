using Microsoft.EntityFrameworkCore;

namespace Immo.MVC.Day2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Electronics" },
                new Category { Id = 2, CategoryName = "Mobiles" },
                new Category { Id = 3, CategoryName = "Computer" },
                new Category { Id = 4, CategoryName = "Home Needs" }
                );

            modelBuilder.Entity<Product>().HasData(
                 new Product { Id = 1, ProductName = "HP Laptop", Price = 50000.5M, Quantity = 100, CategoryId = 3 },
                   new Product() { Id = 2, ProductName = "Water Bottle", Price = 850, Quantity = 252, CategoryId = 4 },
                  new Product() { Id = 3, ProductName = "Apple Watch 7", Price = 37599.99M, Quantity = 15, CategoryId = 2 },
                    new Product() { Id = 4, ProductName = "iPhone 16 Pro", Price = 109999.99M, Quantity = 50, CategoryId = 2 }
                );
        }

        //DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
