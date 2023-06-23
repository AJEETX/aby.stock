using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;
using System.Threading.Tasks;

namespace Aby.StockManager.Repository.Store
{
    public class StoreRepository : Repository<Aby.StockManager.Data.Entity.Store>, IStoreRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public StoreRepository(DbContext context) : base(context)
        {
        }

        public async Task DeleteProductImage(int id)
        {
            Aby.StockManager.Data.Entity.Store user = await dbContext.Store.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.Image = null;
                dbContext.Entry(user).Property(f => f.Image).IsModified = true;
            }
        }
    }
}