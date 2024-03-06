using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Service
{
    public class EditServiceReportViewModel : BaseViewModel
    {
        [Display(Name = "Bill To")]
        public string? Description { get; set; }

        [Display(Name = "Phone Number")]
        public string? Contact { get; set; }

        public string? Gstin { get; set; }
        public string InvoiceNumber { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        public string ServiceDate { get; set; }

        [Display(Name = "Service Type")]
        public int? ServiceCategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}