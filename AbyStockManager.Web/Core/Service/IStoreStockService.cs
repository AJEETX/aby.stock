using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;

namespace Aby.StockManager.Core.Service
{
    public interface IStoreStockService : IService<StoreStockDTO>
    {
        Task<ServiceResult<IEnumerable<StoreStockDTO>>> StoreStockReport(StoreStockDTO criteria);
    }
}
