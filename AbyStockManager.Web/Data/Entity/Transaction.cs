﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Data.Entity
{
    public class Transaction : BaseEntity
    {
        public string TransactionCode { get; set; }
        public string InvoiceNumber { get; set; }
        public int StoreId { get; set; }
        public int? ToStoreId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Gstin { get; set; }
        public string? Remarks { get; set; }
        public bool Igst { get; set; } = false;

        public virtual TransactionType TransactionType { get; set; }
        public virtual Store ToStore { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}