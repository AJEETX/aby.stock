﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Configurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.StoreName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.StoreCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Contact).HasMaxLength(15);
            builder.Property(x => x.Gstin).HasMaxLength(15);
            builder.Property(x => x.Image).HasMaxLength(50);
            builder.ToTable("Store");
        }
    }
}