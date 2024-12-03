using BudgetTracker.Business;
using BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Services
{
    public class UserService
    {
        private readonly UserManager _userManager;

        public UserService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            // Kullanıcıları iş mantığını kullanarak getiren bir servis metodu
            return await _userManager.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userManager.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _userManager.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userManager.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userManager.DeleteUserAsync(id);
        }
    }
}
