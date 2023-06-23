using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;

namespace Aby.StockManager.Core.Service
{
    public interface IStoreService : IService<StoreDTO>
    {
        Task<ServiceResult> DeleteProductImage(int id);
    }
}