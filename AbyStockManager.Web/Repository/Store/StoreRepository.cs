using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.Store
{
    public class StoreRepository : Repository<Aby.StockManager.Data.Entity.Store>, IStoreRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
