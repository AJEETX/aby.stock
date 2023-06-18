﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.ViewModel.Transaction
{
    public class TransactionDetailViewModel
    {
        public int? ProductId { get; set; }
        public int? TransactionId { get; set; }
        public double? Amount { get; set; }
        public double? Tax { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureShortName { get; set; }
    }
}
