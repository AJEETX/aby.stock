using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aby.StockManager.Model.ViewModel.ServiceCategory
{
    public class SearchServiceCategoryViewModel : BaseViewModel
    {
        [Display(Name = "Service Category Name")]
        public string ServiceCategoryName { get; set; }
    }
}