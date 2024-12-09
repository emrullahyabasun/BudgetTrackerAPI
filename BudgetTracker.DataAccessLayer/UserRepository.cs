﻿using BudgetTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.DataAccessLayer
{
    public class UserRepository
    {
        //User tablosu için olan basic crud işlemleri generic repositoryden alınacak. Farklı işlevler eklendiğinde buraya esktra metotlar yazılacak.
        private readonly BudgetTrackerContext _context;

        public UserRepository(BudgetTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
