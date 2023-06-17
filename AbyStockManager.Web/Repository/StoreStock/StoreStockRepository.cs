using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.StoreStock
{
    public class StoreStockRepository : Repository<Aby.StockManager.Data.Entity.StoreStock>, IStoreStockRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }
        public StoreStockRepository(DbContext context) : base(context)
        {
        }

        public async Task RemoveByStoreAndProductId(int productId, int storeId)
        {
            var entity = await dbContext.StoreStock.FirstOrDefaultAsync(x => x.StoreId == storeId && x.ProductId == productId);
            if (entity != null)
                dbContext.StoreStock.Remove(entity);
        }

        public async Task<Aby.StockManager.Data.Entity.StoreStock> GetByStoreAndProductId(int productId, int storeId)
        {
            var entity = await dbContext.StoreStock.FirstOrDefaultAsync(x => x.StoreId == storeId && x.ProductId == productId);
            return entity;
        }

        
    }
}
