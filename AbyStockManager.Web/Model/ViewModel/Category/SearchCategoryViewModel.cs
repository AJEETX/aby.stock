using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Category
{
    public class SearchCategoryViewModel: BaseViewModel
    {

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

    }
}
