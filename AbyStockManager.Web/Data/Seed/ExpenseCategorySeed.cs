using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Seed
{
    internal class ExpenseCategorySeed : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.HasData(
                new ExpenseCategory { Id = 1, CategoryName = "Snacks", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 2, CategoryName = "Rent", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 3, CategoryName = "Travel", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 4, CategoryName = "Utilities", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 5, CategoryName = "Utilities", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 6, CategoryName = "Water", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 7, CategoryName = "Wage", CreateDate = DateTime.Now },
                new ExpenseCategory { Id = 8, CategoryName = "Other", CreateDate = DateTime.Now }
                );
        }
    }
}