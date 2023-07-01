using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.ExpenseCategory
{
    public class ListExpenseCategoryViewModel : BaseViewModel
    {
        [Display(Name = "Expense Category Name")]
        public string CategoryName { get; set; }
    }
}