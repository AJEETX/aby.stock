using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Configurations
{
    internal class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ServiceCategoryName).IsRequired().HasMaxLength(30);
            builder.ToTable("ServiceCategory");
        }
    }
}