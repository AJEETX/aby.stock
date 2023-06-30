using Aby.StockManager.Data.Entity;
using Aby.StockManager.Model.ViewModel.Base;

namespace AbyStockManager.Web.Model.ViewModel.Report.StoreStock
{
    public class EditStoreStockReportViewModel : BaseViewModel
    {
        public string ProductFullName { get; set; }
        public string PurchasePrice { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; } = 1;
        public virtual Product Product { get; set; }
    }
}