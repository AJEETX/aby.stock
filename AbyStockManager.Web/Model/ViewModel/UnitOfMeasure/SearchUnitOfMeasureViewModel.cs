using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.UnitOfMeasure
{
    public class SearchUnitOfMeasureViewModel : BaseViewModel
    {
        public string UnitOfMeasureName { get; set; }
        public string Isocode { get; set; }
    }
}
