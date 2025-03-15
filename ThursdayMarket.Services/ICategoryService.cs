using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> getAllCategories();
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
        Task<Category> findById(int id);
        Task Save();
    }
}
