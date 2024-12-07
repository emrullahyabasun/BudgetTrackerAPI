using BudgetTracker.DataAccessLayer.Helper;
using BudgetTracker.DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;

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
            //predicate fonksiyonu ile where koşulu sağlanan ilk elemanı döndürüyoruz.
            //predicate nedir = https://stackoverflow.com/questions/1710301/what-is-a-predicate-in-c
            return Task.FromResult<T>(query);
        }
        #endregion

        #region Save-Update-Delete-Add Methods

        //SORUNLU.
        public async Task<AppReturn> AddAsync(T entity)
        {
            try
            {
                //debug da bakılacak e den dönen id değeri constructor ın ıd değerine set edilecek
                //e den id henüz dönmüyor çünkü dbye kayıt etmedik henüz.
                var e = await _dbSet.AddAsync(entity); //belleğe ekleme yapar yalnızca. dbye değil.
                return await Task.FromResult<AppReturn>(new AppReturn(true, "Kayit Başarili"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.InnerException?.Message ?? ex.Message}");
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
        #endregion


    }
}
