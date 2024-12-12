using BudgetTracker.DataAccessLayer.Helper;
using BudgetTracker.DataAccessLayer.Interface;
using BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Business
{
    public class TransactionBusiness
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;
        public TransactionBusiness(IGenericRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        #region Get Methods
        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            return (await _transactionRepository.GetAllAsync()).ToList();
        }
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _transactionRepository.GetByIdAsync(id);
        }
        #endregion
        #region Add-Update-Delete Methods
        public async Task<AppReturn> AddTransactionAsync(Transaction transaction)
        {
            if (transaction.Amount <= 0)
                return new AppReturn(false, "Tutar sıfırdan büyük olmalıdır");
            var result = await _transactionRepository.AddAsync(transaction);
            if (result.IsSuccess)
            {
                await _transactionRepository.SaveChangesAsync();
                result.Message = "İşlem başarıyla eklendi.";
            }
            return result;
        }

        public async Task<AppReturn> UpdateTransaction(Transaction transaction)
        {
            var existingTransaction = await _transactionRepository.GetByIdAsync(transaction.Id);
            if (existingTransaction == null)
                return new AppReturn(false, "İşlem bulunamadı.");
            var result = _transactionRepository.Update(transaction);
            if (result.IsSuccess)
            {
                await _transactionRepository.SaveChangesAsync();
                result.Message = "İşlem başarıyla güncellendi.";
            }
            return result;
        }
        public async Task<AppReturn> DeleteTransactionAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return new AppReturn(false, "İşlem bulunamadı.");
            }

            var result = _transactionRepository.Delete(transaction);
            if (result.IsSuccess)
            {
                await _transactionRepository.SaveChangesAsync();
                result.Message = "İşlem başarıyla silindi.";
            }

            return result;
        }

        #endregion

    }
}
