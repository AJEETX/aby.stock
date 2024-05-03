using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Transaction
{
    public class ListTransactionViewModel : BaseViewModel
    {
        public string TransactionCode { get; set; }
        public string InvoiceNumber { get; set; }
        public int? TransactionTypeId { get; set; }
        public string TransactionDate { get; set; }

        [Display(Name = "Biller")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Contact/address")]
        public string Contact { get; set; } = string.Empty;

        [Display(Name = "GSTIN")]
        public string Gstin { get; set; }

        public string StoreName { get; set; }
        public string ToStoreName { get; set; }
        public string TransactionTypeName { get; set; }
        public string? Amount { get; set; }
        public string? AmountWithoutGst { get; set; }
        public string? AmountWithGst { get; set; }
        public string? CGst { get; set; }
        public string? SGst { get; set; }
        public string? IGst { get; set; }
    }
}