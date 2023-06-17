using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Store
{
    public class ListStoreViewModel : BaseViewModel
    {
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
    }
}
