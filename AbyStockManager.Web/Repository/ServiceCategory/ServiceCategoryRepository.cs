using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.Category
{
    public class ServiceCategoryRepository : Repository<Aby.StockManager.Data.Entity.ServiceCategory>, IServiceCategoryRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public ServiceCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}