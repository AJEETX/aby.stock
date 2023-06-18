using System.ComponentModel.DataAnnotations;

using Aby.StockManager.Model.ViewModel.Base;

namespace AbyStockManager.Web.Model.ViewModel.Tax
{
    public class SearchTaxViewModel : BaseViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        public double Rate { get; set; }
    }
}