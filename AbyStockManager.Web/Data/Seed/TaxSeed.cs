using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Seed
{
    internal class TaxSeed : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.HasData(
                new Tax { Id = 1, Name = "FIRST", Rate = 18.00D, CreateDate = DateTime.Now },
                new Tax { Id = 2, Name = "SECOND", Rate = 28.00D, CreateDate = DateTime.Now }
            );
        }
    }
}