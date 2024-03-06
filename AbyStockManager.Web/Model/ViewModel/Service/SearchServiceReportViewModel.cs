﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Service
{
    public class SearchServiceReportViewModel : BaseViewModel
    {
        [Display(Name = "Bill To")]
        public string? Description { get; set; }

        [Display(Name = "Phone Number")]
        public string? Contact { get; set; }

        public string? Gstin { get; set; }
        public string InvoiceNumber { get; set; }

        [Display(Name = "Service description")]
        public string ItemName { get; set; }

        [Display(Name = "Start Date")]
        public string SearchStartDate { get; set; }

        [Display(Name = "End Date")]
        public string SearchEndDate { get; set; }

        [Display(Name = "Service Type")]
        public int? ServiceCategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}