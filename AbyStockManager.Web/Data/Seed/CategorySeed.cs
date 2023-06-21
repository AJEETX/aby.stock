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
            builder.HasData(
                new Category { Id = 1, CategoryName = "2 wheeler", CreateDate = DateTime.Now },
                new Category { Id = 2, CategoryName = "4 wheeler", CreateDate = DateTime.Now },
                new Category { Id = 3, CategoryName = "Heavy Vehicle", CreateDate = DateTime.Now },
                new Category { Id = 4, CategoryName = "Tractor", CreateDate = DateTime.Now },
                new Category { Id = 5, CategoryName = "Other", CreateDate = DateTime.Now }
                );
        }
    }
}