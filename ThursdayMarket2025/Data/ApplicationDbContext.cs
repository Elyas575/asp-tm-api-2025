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
    }
}
