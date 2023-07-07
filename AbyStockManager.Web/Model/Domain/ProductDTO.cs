using System;
using System.Collections.Generic;
using System.Text;

namespace Aby.StockManager.Model.Domain
{
    public class ProductDTO : BaseDTO
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double? SalePrice { get; set; }
        public double? PurchasePrice { get; set; }
        public int? CategoryId { get; set; }
        public double? TaxRate { get; set; }
        public string? Tax { get; set; }
        public int? TaxId { get; set; }
        public string CategoryName { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; }
        public bool Stockedin { get; set; }
        public int Qty { get; set; }
    }
}