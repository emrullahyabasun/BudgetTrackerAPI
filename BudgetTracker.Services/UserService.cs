using BudgetTracker.Business;
using BudgetTracker.Common;
using BudgetTracker.Common.DTOs;
using BudgetTracker.DataAccessLayer.Helper;
using BudgetTracker.Entities;

namespace BudgetTracker.Services
{
    public class UserService
    {
        private readonly UserBusiness _userBusiness;

        public UserService(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        #region Get Methods
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userBusiness.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userBusiness.GetUserByIdAsync(id);
        }
        #endregion

        #region Add-Update-Delete
        public async Task AddUserAsync(UserCreateDTO userDto)
        {
            //DTO'dan business entity'e dönüşüm
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

        public async Task<AppReturn> UpdateUserAsync(UserUpdateDTO userDto)
        {
            // DTO'dan Entity'e dönüşüm
            var user = new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                Email = userDto.Email,
                Name = userDto.Name,
                Lastname = userDto.Lastname
            };

            // Business katmanına gönder
            return await _userBusiness.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userBusiness.DeleteUserAsync(id);
        }
        #endregion
    }
}
