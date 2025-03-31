using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aby.StockManager.Common.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Recpt")]
        Recpt = 1,

        [Display(Name = "Invoice")]
        Invoice = 2,
        [Display(Name = "Svx")]
        Svx = 3
    }
}