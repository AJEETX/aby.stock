using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Configurations
{
    internal class StoreStockConfiguration : IEntityTypeConfiguration<StoreStock>
    {
        public void Configure(EntityTypeBuilder<StoreStock> builder)
        {
            builder.HasKey(x => new { x.StoreId, x.ProductId });
            builder.Property(x => x.Stock);
            builder.ToTable("StoreStock");
        }
    }
}