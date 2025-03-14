using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.Models;


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

                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index", "Category");
            }
 
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            if(id == null || id == 0)
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

            if (categoryToUpdate.Id == null || categoryToUpdate.Id == 0)
            {
                TempData["error"] = "Error Category not found";
                return NotFound("");
            }

            // TempData["error"] = "Testing Error";
            categoryToUpdate.Name = obj.Name;
            categoryToUpdate.DisplayOrder = obj.DisplayOrder;

            _context.Update(categoryToUpdate);
            await _context.SaveChangesAsync();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Category categoryToDelete = await _context.Categories.FindAsync(id);
            return View(categoryToDelete);

        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeletePOST(int? id)
        {
            Category CategoryToDelete = await _context.Categories.FindAsync(id);

            if (CategoryToDelete == null) {
                return NotFound();
            }
             _context.Categories.Remove(CategoryToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Category");
        }
    }
}
