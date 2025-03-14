using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThursdayMarket2025.Data;
using ThursdayMarket2025.Models;


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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                await _context.Categories.AddAsync(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
 
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }

            Category categoryToUpdate =  await _context.Categories.FindAsync(id);
            if (categoryToUpdate == null) {
                return NotFound();
            }

            return View(categoryToUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category obj)
        {
            Category categoryToUpdate = await _context.Categories.FindAsync(obj.Id);

            if(categoryToUpdate == null)
            {
                return NotFound("");
            }

            categoryToUpdate.Name = obj.Name;
            categoryToUpdate.DisplayOrder = obj.DisplayOrder;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }

    }
}
