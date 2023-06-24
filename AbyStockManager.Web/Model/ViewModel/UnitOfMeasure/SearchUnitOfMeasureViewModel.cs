using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.UnitOfMeasure
{
    public class SearchUnitOfMeasureViewModel : BaseViewModel
    {
        [Display(Name = "Measurement type Name")]
        public string UnitOfMeasureName { get; set; }

        [Display(Name = "Measurement type Code")]
        public string Isocode { get; set; }
    }
}