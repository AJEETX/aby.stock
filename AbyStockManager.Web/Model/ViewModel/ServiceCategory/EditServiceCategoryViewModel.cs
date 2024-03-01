using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aby.StockManager.Model.ViewModel.ServiceCategory
{
    public class EditServiceCategoryViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Service Type Name")]
        public string ServiceCategoryName { get; set; }
    }
}