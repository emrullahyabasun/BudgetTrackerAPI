using BudgetTracker.DataAccessLayer.Abstract;
using BudgetTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.DataAccessLayer
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(BudgetTrackerContext context) : base(context) { }
    }
}
