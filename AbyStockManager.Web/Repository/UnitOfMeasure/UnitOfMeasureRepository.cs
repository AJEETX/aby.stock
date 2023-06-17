using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.UnitOfMeasure
{
    public class UnitOfMeasureRepository : Repository<Aby.StockManager.Data.Entity.UnitOfMeasure>, IUnitOfMeasureRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }
        public UnitOfMeasureRepository(DbContext context) : base(context)
        {
        }
    }
}
