using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.UnitOfMeasure
{
    public class EditUnitOfMeasureViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Measurement type Name")]
        public string UnitOfMeasureName { get; set; }

        [Required]
        [MaxLength(3)]
        [Display(Name = "Measurement type Code [ 3 character code]")]
        public string Isocode { get; set; }
    }
}