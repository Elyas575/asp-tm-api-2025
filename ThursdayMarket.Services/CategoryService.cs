using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.Models;

namespace ThursdayMarket.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            return category;
        }

        public async Task<Category> Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                return category;
            }
            throw new KeyNotFoundException($"Category with ID {id} not found.");
        }

        public async Task<Category> findById(int id)
        {
            Category categoryToFind = await _context.Categories.FindAsync(id);
            if (categoryToFind != null)
            {
                return categoryToFind;
            }
            throw new KeyNotFoundException($"Category with ID {id} not found.");
        }

        public async Task<IEnumerable<Category>> getAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> Update(Category category)
        {
            Category categoryToUpdate = await this.findById(category.Id);

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.DisplayOrder = category.DisplayOrder;
            _context.Categories.Update(categoryToUpdate);

            return categoryToUpdate;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
