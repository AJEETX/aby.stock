﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Expense
{
    public class EditExpenseReportViewModel : BaseViewModel
    {
        [Required]
        public string ItemName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        public string ExpenseDate { get; set; }

        [Display(Name = "Expense Type")]
        public int? CategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}