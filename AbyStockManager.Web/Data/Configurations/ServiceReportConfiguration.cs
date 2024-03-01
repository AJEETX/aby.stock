using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Configurations
{
    internal class ServiceReportConfiguration : IEntityTypeConfiguration<ServiceReport>
    {
        public void Configure(EntityTypeBuilder<ServiceReport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ItemName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ServiceCategoryId).HasMaxLength(50);
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            builder.ToTable("ServiceReport");
        }
    }
}