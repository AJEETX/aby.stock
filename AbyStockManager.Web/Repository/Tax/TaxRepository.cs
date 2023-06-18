using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

using Microsoft.EntityFrameworkCore;

namespace AbyStockManager.Web.Repository.Tax
{
    public class TaxRepository : Repository<Aby.StockManager.Data.Entity.Tax>, ITaxRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public TaxRepository(DbContext context) : base(context)
        {
        }
    }
}