using BudgetTracker.DataAccessLayer.Helper;
using BudgetTracker.DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.DataAccessLayer.Abstract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //temel crud işlemleri için hazırlanan mantık.generic türde.
        private readonly BudgetTrackerContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(BudgetTrackerContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        #region Get Methods
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<T> GetEntitiyByFilter(Func<T, bool> predicate)
        {
            //ToHashSet debug edilecek
            T query = _dbSet.ToHashSet<T>().Where(predicate).FirstOrDefault();
            return Task.FromResult<T>(query);
        }
        #endregion


        public async Task<AppReturn> AddAsync(T entity)
        {
            //string kelimeler bir yerde toplanacak
            try
            {
                //debug da bakılacak e den dönen id değeri constructor ın ıd değerine set edilecek
                var e = await _dbSet.AddAsync(entity);
                return await Task.FromResult<AppReturn>(new AppReturn(true, "Kayit Başarili"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<AppReturn>(new AppReturn(false, $"Kayit Sırasında Hata oluştu: Hata mesajı: {ex.InnerException?.Message ?? ex.Message}"));
            }
        }

        public async Task<AppReturn> AddAllAsync(IEnumerable<T> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);

                return await Task.FromResult<AppReturn>(new AppReturn(true, "Kayit Başarili"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<AppReturn>(new AppReturn(false, $"Kayit Sırasında Hata oluştu: Hata mesajı: {ex.InnerException?.Message ?? ex.Message}"));
            }
        }
        public AppReturn Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return new AppReturn(true, "Kayit Başarili");
            }
            catch (Exception ex)
            {
                return new AppReturn(false, $"Kayit Sırasında Hata oluştu: Hata mesajı: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public AppReturn Delete(T entity)
        {
            //string kelimeler bir yerde toplanacak
            try
            {
                _dbSet.Remove(entity);
                return new AppReturn(true, "Kayit Başarili");
            }
            catch (Exception ex)
            {
                return new AppReturn(false, $"Kayit Sırasında Hata oluştu: Hata mesajı: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
