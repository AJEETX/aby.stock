﻿using System;
using System.Collections.Generic;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Report.StoreStock
{
    public class ListStoreStockReportViewModel : BaseViewModel
    {
        public int ProductId { get; set; }
        public string QTY { get; set; }
        public int Quantity { get; set; }
        public string StoreFullName { get; set; }
        public string ProductFullName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductTotalPrice { get; set; }
        public string ProductTotalDisplayPrice { get; set; }
    }
}