using Microsoft.EntityFrameworkCore;
using ThursdayMarket.Models;


namespace ThursdayMarket.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(
            //        new Category { Id=1, Name= "Fruits", DisplayOrder = 1, },
            //        new Category { Id=2, Name=" Vegetables", DisplayOrder=1 }
            //    );
        }
    }
}
