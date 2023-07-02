using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Expense
{
    public class ListExpenseReportViewModel : BaseViewModel
    {
        public string ItemName { get; set; }

        [Display(Name = "Expense Type Name")]
        public string Category { get; set; }

        public string Amount { get; set; }
        public string ExpenseDate { get; set; }
    }
}