using Microsoft.EntityFrameworkCore;

namespace Immo.MVC.Day2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //        .HasOne(p => p.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(p => p.CategoryId);
        //}

        //DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
