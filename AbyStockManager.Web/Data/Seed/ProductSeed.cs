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
              new Product { Id = 1, ProductName = "145R12 MILAZE LT TL 8PR", Barcode = "145R12 MILAZE LT TL 8PR", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 2661 },
                new Product { Id = 2, ProductName = "145/80R12 X3 TT", Barcode = "145/80R12 X3 TT", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 2568 },
                new Product { Id = 3, ProductName = "145/80R12 X3 TL", Barcode = "145/80R12 X3 TL", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 2510 },
                new Product { Id = 4, ProductName = "145/80R13 MILAZE X3 TL", Barcode = "145/80R13 MILAZE X3 TL", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 2782 }
                );
        }
    }
}