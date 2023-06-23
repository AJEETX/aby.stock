using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Product
{
    public class SearchProductViewModel : BaseViewModel
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product code")]
        public string Barcode { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Tax")]
        public int? TaxId { get; set; }

        [Display(Name = "Measurement type")]
        public int? UnitOfMeasureId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> TaxList { get; set; }
        public IEnumerable<SelectListItem> UnitOfMeasureList { get; set; }
    }
}