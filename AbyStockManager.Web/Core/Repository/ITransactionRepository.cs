using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aby.StockManager.Core.Repository
{
    public interface ITransactionRepository : IRepository<Aby.StockManager.Data.Entity.Transaction>
    {
        Task<Aby.StockManager.Data.Entity.Transaction> GetWithDetailById(int id);
        Task<Aby.StockManager.Data.Entity.Transaction> GetWithDetailAndProductById(int id);
    }
}
