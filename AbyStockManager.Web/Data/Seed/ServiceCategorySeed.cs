using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Seed
{
    internal class ServiceCategorySeed : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasData(
                new ServiceCategory { Id = 1, ServiceCategoryName = "WHEEL-ALIGNMENT", CreateDate = DateTime.Now },
                    new ServiceCategory { Id = 2, ServiceCategoryName = "OTHERS", CreateDate = DateTime.Now }
                );
        }
    }
}