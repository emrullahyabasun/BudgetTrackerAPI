using BudgetTracker.Business;
using BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Services
{
    public class CategoryService
    {
        private readonly CategoryBusiness _categoryBusiness;

        public CategoryService(CategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryBusiness.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryBusiness.GetCategoryByIdAsync(id);
        }
        public async Task AddCategoryAsync(Category category)
        {
            await _categoryBusiness.AddCategoryAsync(category);
        }
        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryBusiness.UpdateCategoryAsync(category);
        }
        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _categoryBusiness.DeleteCategoryByIdAsync(id);
        }
    }
}
