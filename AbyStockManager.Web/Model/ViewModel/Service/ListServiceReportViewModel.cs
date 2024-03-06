using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Service
{
    public class ListServiceReportViewModel : BaseViewModel
    {
        [Display(Name = "Bill To")]
        public string? Description { get; set; }

        [Display(Name = "Phone Number")]
        public string? Contact { get; set; }

        public string? Gstin { get; set; }
        public string InvoiceNumber { get; set; }

        public string ItemName { get; set; }

        [Display(Name = "Service Type Name")]
        public string ServiceCategory { get; set; }

        public string Amount { get; set; }
        public string ServiceDate { get; set; }
    }
}