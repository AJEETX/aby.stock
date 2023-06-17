using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.TransactionType
{
    public class TransactionTypeRepository : Repository<Aby.StockManager.Data.Entity.TransactionType>, ITransactionTypeRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }
        public TransactionTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
