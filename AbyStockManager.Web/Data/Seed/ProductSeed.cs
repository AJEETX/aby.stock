using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductName = "test", Barcode = "test", CategoryId = 1, TaxId = 1, CreateDate = DateTime.Now, UnitOfMeasureId = 1, SalePrice = 110.00, PurchasePrice = 100.00 }
                );
        }
    }
}