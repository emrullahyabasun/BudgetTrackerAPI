using BudgetTracker.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Entities
{
    public class Transaction : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public int TransactionType { get; set; } // 1: Income, 2: Expense
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        #region Recursive Transaction Fields
        public bool IsRecurring { get; set; }
        public int? RecurringType { get; set; } // 1: Monthly, 2: Weekly, 3: Annually
        public int? RecurringCount { get; set; } // How many times ? (Null = infinite)
        public DateTime? RecurringEndDate { get; set; }
        #endregion

        public Category Category { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public User User { get; set; }
    }
}
