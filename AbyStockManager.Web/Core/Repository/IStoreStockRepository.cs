using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aby.StockManager.Core.Repository
{
    public interface IStoreStockRepository : IRepository<Aby.StockManager.Data.Entity.StoreStock>
    {
        Task RemoveByStoreAndProductId(int productId, int storeId);
        Task<Aby.StockManager.Data.Entity.StoreStock> GetByStoreAndProductId(int productId, int storeId);
    }
}
