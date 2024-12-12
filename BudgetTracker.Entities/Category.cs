using BudgetTracker.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; } // 1: Gelir, 2: Gider

        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
