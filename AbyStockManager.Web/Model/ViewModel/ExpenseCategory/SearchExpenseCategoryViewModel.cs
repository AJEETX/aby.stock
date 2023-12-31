﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aby.StockManager.Model.ViewModel.ExpenseCategory
{
    public class SearchExpenseCategoryViewModel : BaseViewModel
    {
        [Display(Name = "Expense Category Name")]
        public string CategoryName { get; set; }
    }
}