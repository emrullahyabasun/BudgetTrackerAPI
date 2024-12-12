using BudgetTracker.DataAccessLayer.Abstract;
using BudgetTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.DataAccessLayer
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(BudgetTrackerContext context) : base(context) { }
    }
}
