using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Store
{
    public class ListStoreViewModel : BaseViewModel
    {
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
        public string Contact { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? IFSC { get; set; }
        public string Gstin { get; set; }
        public string ImageDisplay { get; set; }
    }
}