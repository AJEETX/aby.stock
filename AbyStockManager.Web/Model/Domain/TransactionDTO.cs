﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class TransactionDTO : BaseDTO
    {
        public TransactionDTO()
        {
            TransactionDetail = new List<TransactionDetailDTO>();
        }
        public bool Igst { get; set; } = false;

        public string TransactionCode { get; set; }
        public string InvoiceNumber { get; set; }
        public int? StoreId { get; set; }
        public int? ToStoreId { get; set; }
        public int? TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public string? Contact { get; set; }
        public string? Gstin { get; set; }
        public string? Remarks { get; set; }
        public string? StoreName { get; set; }
        public string? ToStoreName { get; set; }
        public string? TransactionTypeName { get; set; }
        public IList<TransactionDetailDTO> TransactionDetail { get; set; }
    }
}
