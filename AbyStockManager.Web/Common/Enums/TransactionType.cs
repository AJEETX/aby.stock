using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aby.StockManager.Common.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Purchase")]
        Purchase = 1,

        [Display(Name = "Sales")]
        Sales = 2,
        [Display(Name = "Service")]
        Service = 3
    }
}