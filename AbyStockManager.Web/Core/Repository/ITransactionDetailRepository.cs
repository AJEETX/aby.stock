using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Core.Repository
{
    public interface ITransactionDetailRepository : IRepository<Aby.StockManager.Data.Entity.TransactionDetail>
    {
        void DeleteAllRecordByTransaction(ICollection<Aby.StockManager.Data.Entity.TransactionDetail> transactionDetails);
        Task<IEnumerable<Aby.StockManager.Data.Entity.TransactionDetail>> GetByTransactionId(int transactionId);
    }
}
