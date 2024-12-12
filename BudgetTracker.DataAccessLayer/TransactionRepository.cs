using BudgetTracker.DataAccessLayer.Abstract;
using BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.DataAccessLayer
{
    public class TransactionRepository : GenericRepository<Transaction>
    {
        public TransactionRepository(BudgetTrackerContext context) : base(context) { }

    }
}
