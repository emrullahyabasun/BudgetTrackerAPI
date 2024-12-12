using BudgetTracker.DataAccessLayer.Helper;
using BudgetTracker.DataAccessLayer.Interface;
using BudgetTracker.Entities;

namespace BudgetTracker.Business
{
    public class UserBusiness
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserBusiness(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #region Get Methods

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        #endregion
        #region Add-Update-Delete
        public async Task<AppReturn> AddUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                return new AppReturn(false, "Kullanıcı adı boş olamaz.");
            }

            var result = await _userRepository.AddAsync(user); //belleğe eklenir.
            if (!result.IsSuccess)
                return result;

            return await _userRepository.SaveChangesAsync();
        }

        public async Task<AppReturn> UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                return new AppReturn(false, "Kullanıcı bulunamadı.");
            }
            var result = _userRepository.Update(user);
            if (!result.IsSuccess) 
                return result;
            return await _userRepository.SaveChangesAsync();
          
        }

        public async Task<AppReturn> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return new AppReturn(false, "Kullanıcı bulunamadı.");
            }
            var result = _userRepository.Delete(user);
            if (!result.IsSuccess)
                return result;
            return await _userRepository.SaveChangesAsync();
        }
        #endregion
    }
}
