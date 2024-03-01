using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Aby.StockManager.Core.Repository;
using Aby.StockManager.Repository.Product;

namespace Aby.StockManager.Core.UnitOfWorks
{
    public interface IUnitOfWorks : IDisposable
    {
        ITaxRepository TaxRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IServiceCategoryRepository ServiceCategoryRepository { get; }
        IServiceReportRepository ServiceReportRepository { get; }
        IExpenseCategoryRepository ExpenseCategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IExpenseReportRepository ExpenseReportRepository { get; }
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