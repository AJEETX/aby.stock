using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;
using System.Linq;

namespace Aby.StockManager.Repository.Transaction
{
    public class TransactionRepository : Repository<Aby.StockManager.Data.Entity.Transaction>, ITransactionRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public TransactionRepository(DbContext context) : base(context)
        {
        }

        public async Task<Aby.StockManager.Data.Entity.Transaction> GetWithDetailById(int id)
        {
            return await dbContext.Transaction.Include(x => x.TransactionDetail).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Aby.StockManager.Data.Entity.Transaction> GetWithDetailAndProductById(int id)
        {
            return await dbContext.Transaction
                .Include(x => x.TransactionDetail)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> GetWithDetailByProductId(int id)
        {
            var data = await dbContext.Transaction
                .Include(x => x.TransactionDetail)
                .ThenInclude(x => x.Product).ToListAsync();
            foreach (var item in data)
            {
                if (item.TransactionCode.Contains(Common.Enums.TransactionType.Recpt.ToString()))
                {
                    foreach (var item2 in item.TransactionDetail)
                    {
                        if (item2.ProductId == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}