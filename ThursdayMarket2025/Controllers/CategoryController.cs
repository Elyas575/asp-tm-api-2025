using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThursdayMarket2025.Data;


namespace ThursdayMarket2025.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
