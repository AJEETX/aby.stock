using Aby.StockManager.Model.ViewModel.Base;

namespace AbyStockManager.Web.Model.ViewModel.Tax
{
    public class ListTaxViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}