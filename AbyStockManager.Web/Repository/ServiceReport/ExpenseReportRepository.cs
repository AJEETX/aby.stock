using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.Product
{
    public class ServiceReportRepository : Repository<Aby.StockManager.Data.Entity.ServiceReport>, IServiceReportRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public ServiceReportRepository(DbContext context) : base(context)
        {
        }
    }
}