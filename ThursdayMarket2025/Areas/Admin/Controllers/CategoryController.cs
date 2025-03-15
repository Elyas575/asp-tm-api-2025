using Microsoft.AspNetCore.Mvc;
using ThursdayMarket.Models;
using ThursdayMarket.Services;


namespace ThursdayMarket2025.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.getAllCategories();
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
                await _categoryService.Create(obj);
               await _categoryService.Save();

                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryToUpdate = await _categoryService.findById(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }
            return View(categoryToUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category obj)
        {
            Category categoryToUpdate = await _categoryService.Update(obj);
            if (categoryToUpdate.Id == null || categoryToUpdate.Id == 0)
            {
                TempData["error"] = "Error Category not found";
                return NotFound("");
            }
            await _categoryService.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category categoryToDelete = await _categoryService.findById(id);
            return View(categoryToDelete);

        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeletePOST(int id)
        {
            Category CategoryToDelete = await _categoryService.Delete(id);

            if (CategoryToDelete == null)
            {
                return NotFound();
            }
            await _categoryService.Save();
            return RedirectToAction("Index", "Category");
        }
    }
}
