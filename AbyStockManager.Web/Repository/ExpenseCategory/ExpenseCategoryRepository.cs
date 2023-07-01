using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.Category
{
    public class ExpenseCategoryRepository : Repository<Aby.StockManager.Data.Entity.ExpenseCategory>, IExpenseCategoryRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public ExpenseCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}