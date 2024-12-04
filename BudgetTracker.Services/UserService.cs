using BudgetTracker.Business;
using BudgetTracker.Common;
using BudgetTracker.Common.DTOs;
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
        private readonly UserBusiness _userBusiness;

        public UserService(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            // Kullanıcıları iş mantığını kullanarak getiren bir servis metodu
            return await _userBusiness.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userBusiness.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(UserCreateDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = PasswordHasher.HashPassword(userDto.Password),
                Email = userDto.Email,
                Name = userDto.Name,
                Lastname = userDto.Lastname,
                InsertTime = DateTime.Now,

            };
            await _userBusiness.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userBusiness.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userBusiness.DeleteUserAsync(id);
        }
    }
}
