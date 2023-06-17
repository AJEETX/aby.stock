using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.Category
{
    public class CategoryRepository : Repository<Aby.StockManager.Data.Entity.Category>, ICategoryRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
