﻿using BudgetTracker.DataAccessLayer.Helper;
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
        #region Get Methods
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntitiyByFilter(Func<T, bool> predicate);
        #endregion
        #region Save - Update - Delete Service Repository
        Task<AppReturn> AddAllAsync(IEnumerable<T> entities);
        Task<AppReturn> AddAsync(T entity);
        AppReturn Update(T entity);
        AppReturn Delete(T entity);
        #endregion

        #region SaveChanges
        Task SaveChangesAsync();
        #endregion


    }
}
