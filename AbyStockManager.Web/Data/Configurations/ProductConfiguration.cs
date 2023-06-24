﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Image).HasMaxLength(50);
            builder.Property(x => x.Barcode).HasMaxLength(50);
            builder.Property(x => x.SalePrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PurchasePrice).HasColumnType("decimal(18,2)");
            builder.ToTable("Product");
        }
    }
}