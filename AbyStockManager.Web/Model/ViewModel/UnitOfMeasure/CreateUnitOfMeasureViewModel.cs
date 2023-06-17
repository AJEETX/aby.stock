using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.UnitOfMeasure
{
    public class CreateUnitOfMeasureViewModel: BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Unit of Measure Name")]
        public string UnitOfMeasureName { get; set; }


        [Required]
        [MaxLength(3)]
        [Display(Name = "Unit of Measure Short Code")]
        public string Isocode { get; set; }

    }
}
