using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class StoreStock
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}