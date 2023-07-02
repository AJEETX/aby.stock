using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aby.StockManager.Model.ViewModel.ExpenseCategory
{
    public class EditExpenseCategoryViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Expense Type Name")]
        public string CategoryName { get; set; }
    }
}