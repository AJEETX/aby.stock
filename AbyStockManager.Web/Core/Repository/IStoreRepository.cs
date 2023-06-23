using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aby.StockManager.Core.Repository
{
    public interface IStoreRepository : IRepository<Aby.StockManager.Data.Entity.Store>
    {
        Task DeleteProductImage(int id);
    }
}