using System.ComponentModel.DataAnnotations;

using Aby.StockManager.Model.ViewModel.Base;

namespace AbyStockManager.Web.Model.ViewModel.Tax
{
    public class CreateTaxViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Rate { get; set; }
    }
}