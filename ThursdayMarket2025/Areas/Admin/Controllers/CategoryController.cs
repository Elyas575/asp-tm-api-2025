using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.Repository.category;
using ThursdayMarket.Models;


namespace ThursdayMarket2025.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.getAllCategories();
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
                await _categoryRepository.Create(obj);
                _categoryRepository.Save();

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

            Category categoryToUpdate = await _categoryRepository.findById(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            return View(categoryToUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category obj)
        {
            Category categoryToUpdate = await _categoryRepository.Update(obj);

            if (categoryToUpdate.Id == null || categoryToUpdate.Id == 0)
            {
                TempData["error"] = "Error Category not found";
                return NotFound("");
            }

            _categoryRepository.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category categoryToDelete = await _categoryRepository.findById(id);

            return View(categoryToDelete);

        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeletePOST(int id)
        {
            Category CategoryToDelete = await _categoryRepository.Delete(id);

            if (CategoryToDelete == null)
            {
                return NotFound();
            }
            _categoryRepository.Save();

            return RedirectToAction("Index", "Category");
        }
    }
}
