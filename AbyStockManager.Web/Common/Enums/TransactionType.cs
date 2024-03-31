using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aby.StockManager.Common.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Receipt")]
        Receipt = 1,

        [Display(Name = "Inv")]
        Inv = 2,
        [Display(Name = "Svc")]
        Svc = 3
    }
}