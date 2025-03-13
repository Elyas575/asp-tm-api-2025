using Microsoft.EntityFrameworkCore;
using ThursdayMarket2025.Models;

namespace ThursdayMarket2025.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(
            //        new Category { Id=1, Name= "Fruits", DisplayOrder = 1, },
            //        new Category { Id=2, Name=" Vegetables", DisplayOrder=1 }
            //    );
        }
    }
}
