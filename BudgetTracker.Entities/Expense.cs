using BudgetTracker.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Entities
{
    public class Expense : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
