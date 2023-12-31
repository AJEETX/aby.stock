﻿using System;
using System.Collections.Generic;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Product
{
    public class ListProductViewModel : BaseViewModel
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string ImageDisplay { get; set; }
        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }
        public string Tax { get; set; }
        public string CategoryName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public bool Stockedin { get; set; }
        public int Qty { get; set; }
    }
}