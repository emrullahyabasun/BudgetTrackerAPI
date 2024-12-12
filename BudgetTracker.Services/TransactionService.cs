using BudgetTracker.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Services
{
    public class TransactionService
    {
        private readonly TransactionBusiness _transactionBusiness;

        public TransactionService(TransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }
    }
}
