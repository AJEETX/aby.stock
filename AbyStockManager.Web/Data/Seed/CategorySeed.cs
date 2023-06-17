using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Seed
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = 1, CategoryName = "TYRES", CreateDate = DateTime.Now });
        }
    }
}