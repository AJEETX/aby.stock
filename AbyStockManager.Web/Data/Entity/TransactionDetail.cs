using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class TransactionDetail
    {
        public int ProductId { get; set; }
        public int TransactionId { get; set; }
        public int Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}