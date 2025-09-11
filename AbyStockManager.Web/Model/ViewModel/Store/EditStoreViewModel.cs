using System.ComponentModel.DataAnnotations;

using Aby.StockManager.Model.ViewModel.Base;

using Microsoft.AspNetCore.Http;

namespace Aby.StockManager.Model.ViewModel.Store
{
    public class EditStoreViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Address")]
        public string StoreCode { get; set; }

        [MaxLength(15)]
        [Display(Name = "Contact Number")]
        public string Contact { get; set; }

        [MaxLength(20)]
        [Display(Name = "Bank Account Number")]
        public string? BankAccountNumber { get; set; }
        [MaxLength(15)]
        [Display(Name = "IFSC Code")]
        public string? IFSC { get; set; }

        [MaxLength(15)]
        [Display(Name = "Gstin")]
        public string Gstin { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Image")]
        [RegularExpression(@"^.*\.(jpg|JPG|png|PNG|jpeg|JPEG)$")]
        public IFormFile ImageFile { get; set; }

        public string ImageDisplayURL { get; set; }
    }
}