using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class ExpenseCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<ExpenseReport> ExpenseReport { get; set; }
    }
}