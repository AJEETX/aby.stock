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
        public string Barcode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureShortName { get; set; }
    }
}