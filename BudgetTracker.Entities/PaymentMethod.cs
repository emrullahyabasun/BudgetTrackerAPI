using BudgetTracker.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
