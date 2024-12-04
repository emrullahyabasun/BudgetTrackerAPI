using BudgetTracker.DataAccessLayer;
using BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Business
{
    public class CategoryBusiness
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryBusiness(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new ArgumentException("Kategori adı boş olamaz");
            }
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _categoryRepository.DeleteCategoryByIdAsync(id);
        }
    }
}
