using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Core.Repository;

namespace Aby.StockManager.Core.UnitOfWorks
{
    public interface IUnitOfWorks : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IStoreRepository StoreRepository { get; }
        IStoreStockRepository StoreStockRepository { get; }
        ITransactionDetailRepository TransactionDetailRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ITransactionTypeRepository TransactionTypeRepository { get; }
        IUnitOfMeasureRepository UnitOfMeasureRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
        void Save();
        void Commit();
        void RollBack();
        void CreateTransaction();

    }
}
