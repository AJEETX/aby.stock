using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Product
{
    public class EditProductViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Image")]
        [RegularExpression(@"^.*\.(jpg|JPG|png|PNG|jpeg|JPEG)$")]
        public IFormFile ImageFile { get; set; }

        public string ImageDisplayURL { get; set; }

        [Display(Name = "Sales Price")]
        public decimal? Price { get; set; }

        [Display(Name = "Purchase Price")]
        public decimal? PurchasePrice { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Tax")]
        public int? TaxId { get; set; }

        [Required]
        [Display(Name = "Unit Of Measure")]
        public int UnitOfMeasureId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> TaxList { get; set; }
        public IEnumerable<SelectListItem> UnitOfMeasureList { get; set; }
    }
}