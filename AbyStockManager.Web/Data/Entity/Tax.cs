using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class Tax : BaseEntity
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}