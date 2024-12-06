using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.DataAccessLayer.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        //Temel crud işlemlerini implemente etmek için imzalar.Generic türde.
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
