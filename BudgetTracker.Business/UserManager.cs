using BudgetTracker.DataAccessLayer;
using BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Business
{
    public class UserManager
    {
        private readonly UserRepository _userRepository;

        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            // İş mantığı burada uygulanabilir. Örneğin verileri filtrelemek veya dönüştürmek.
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            // Eklemek istediğimiz kullanıcıya belirli iş kuralları uygulayabiliriz.
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("Kullanıcı adı boş olamaz");
            }

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
