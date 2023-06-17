using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.ViewModel.Base
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public int? iDisplayStart { get; set; }
        public int? iDisplayLength { get; set; }

    }
}
