using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Common.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Lastname { get; set; }
    }
}
