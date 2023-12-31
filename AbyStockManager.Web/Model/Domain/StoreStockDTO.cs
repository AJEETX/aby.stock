﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class StoreStockDTO : BaseDTO
    {
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public double? Stock { get; set; }
        public double? Price { get; set; }
        public double? PurchasePrice { get; set; }
        public double? TotalPrice { get; set; }
        public string StoreName { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string Isocode { get; set; }
        public string StoreCode { get; set; }
    }
}