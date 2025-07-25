﻿using System.ComponentModel.DataAnnotations;

namespace Aby.StockManager.Common.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Receipt")]
        Receipt = 1,

        [Display(Name = "Invoice")]
        Invoice = 2,
        [Display(Name = "Svc")]
        Svc = 3
    }
}