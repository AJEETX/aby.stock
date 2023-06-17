using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aby.StockManager.Core.Repository
{
    public interface IProductRepository : IRepository<Aby.StockManager.Data.Entity.Product>
    {
        Task DeleteProductImage(int id);
        Task<IEnumerable<Aby.StockManager.Data.Entity.Product>> GetProductsByBarcodeAndName(string term);
    }
}
