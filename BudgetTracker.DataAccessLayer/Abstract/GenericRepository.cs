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
            //ToHashSet debug edilecek belki yerine T query = _dbSet.AsEnumerable().FirstOrDefault(predicate); yazılabilir.
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
                await _dbSet.AddAsync(entity); // Belleğe ekleme
                return new AppReturn(true, "Kayıt belleğe başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.InnerException?.Message ?? ex.Message}");
                //fromresult ne işe yarıyor tekrardan task olarak döndürmemizin anlamı ne burada?

                return new AppReturn(false, $"Belleğe ekleme hatası: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public async Task<AppReturn> AddAllAsync(IEnumerable<T> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);

                return new AppReturn(true, "Kayıtlar belleğe başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return new AppReturn(false, $"Belleğe toplu ekleme hatası: {ex.InnerException?.Message ?? ex.Message}");
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
                return new AppReturn(false, $"Güncelleme hatası: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public AppReturn Delete(T entity)
        {
            //string kelimeler bir yerde toplanacak
            try
            {
                _dbSet.Remove(entity);
                return new AppReturn(true, "Kayıt bellekte başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return new AppReturn(false, $"Silme hatası: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        public async Task<AppReturn> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new AppReturn(true, "Değişiklikler başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                return new AppReturn(false, $"Veritabanı kaydı sırasında hata oluştu: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        #endregion


    }
}
