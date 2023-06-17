using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.TransactionDetail
{
    public class TransactionDetailRepository : Repository<Aby.StockManager.Data.Entity.TransactionDetail>, ITransactionDetailRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }
        public TransactionDetailRepository(DbContext context) : base(context)
        {
        }

        public void DeleteAllRecordByTransaction(ICollection<Aby.StockManager.Data.Entity.TransactionDetail> transactionDetails)
        {
            dbContext.RemoveRange(transactionDetails);
        }

        public async Task<IEnumerable<Aby.StockManager.Data.Entity.TransactionDetail>> GetByTransactionId(int transactionId)
        {
            return await dbContext.TransactionDetail.Include(x => x.Product).ThenInclude(x=> x.UnitOfMeasure).Where(x => x.TransactionId == transactionId).ToListAsync();
        }
    }
}
