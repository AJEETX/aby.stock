﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Transaction
{
    public class CreateTransactionViewModel : BaseViewModel
    {
        public string PageName { get; set; }

        public bool Igst { get; set; } = false;
        [Required]
        [MaxLength(30)]
        [Display(Name = "Transaction Type")]
        public string TransactionCode { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Required]
        [Display(Name = "Store")]
        public int StoreId { get; set; }

        [Required]
        [Display(Name = "To Store")]
        public int? ToStoreId { get; set; }

        public int TransactionTypeId { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string TransactionDate { get; set; }

        [Display(Name = "Biller")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Contact/address")]
        public string Contact { get; set; } = string.Empty;

        [Display(Name = "GSTIN")]
        public string Gstin { get; set; } = string.Empty;

        [Display(Name = "Stockist")]
        public string? Remarks { get; set; } = string.Empty;

        public IList<TransactionDetailViewModel> TransactionDetail { get; set; }
        public IEnumerable<SelectListItem> StoreList { get; set; }
        public IEnumerable<SelectListItem> ToStoreList { get; set; }
    }
}