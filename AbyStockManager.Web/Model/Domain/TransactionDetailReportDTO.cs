﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class TransactionDetailReportDTO : BaseDTO
    {
        public int? ProductId { get; set; }
        public int? TransactionId { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? StoreId { get; set; }
        public int? ToStoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
        public string ToStoreCode { get; set; }
        public string ToStoreName { get; set; }
        public double? Amount { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
        public double? SalePrice { get; set; }
        public double? PurchasePrice { get; set; }
        public double? TotalPrice { get; set; }
        public string Barcode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureShortName { get; set; }
        public string TransactionCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string TransactionTypeName { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}