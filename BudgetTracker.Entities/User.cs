using BudgetTracker.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
