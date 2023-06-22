using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class TransactionDetailDTO
    {
        public int? ProductId { get; set; }
        public int? TransactionId { get; set; }
        public int? Amount { get; set; }
        public string ProductName { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionDueDate { get; set; }
        public string Barcode { get; set; }
        public string InvoiceNumber { get; set; }
        public string Tax { get; set; }
        public string UnitPrice { get; set; }
        public double Price { get; set; }
        public double TaxRate { get; set; }

        public string SubTotalPrice { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureShortName { get; set; }
    }
}