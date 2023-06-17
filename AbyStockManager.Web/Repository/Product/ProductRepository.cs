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
    public class ProductRepository : Repository<Aby.StockManager.Data.Entity.Product>, IProductRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task DeleteProductImage(int id)
        {
            Aby.StockManager.Data.Entity.Product product = await dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.Image = null;
                dbContext.Entry(product).Property(f => f.Image).IsModified = true;
            }
        }

        public async Task<IEnumerable<Data.Entity.Product>> GetProductsByBarcodeAndName(string term)
        {
            return await dbContext.Product.Where(x => x.ProductName.Contains(term) || x.Barcode.Contains(term)).AsNoTracking().ToListAsync();
        }
    }
}
