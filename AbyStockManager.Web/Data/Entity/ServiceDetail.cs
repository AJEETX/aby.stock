using Aby.StockManager.Data.Entity;

namespace AbyStockManager.Web.Data.Entity
{
    public class ServiceDetail
    {
        public int ServiceReportId { get; set; }
        public int ServiceCategoryId { get; set; }
        public int Quantity { get; set; } = 1;
        public double? FinalSalePrice { get; set; }
        public virtual ServiceReport ServiceReport { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}