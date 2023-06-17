using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;

namespace Aby.StockManager.Core.Service
{
    public interface ITransactionService : IService<TransactionDTO>
    {
        Task<ServiceResult<TransactionDTO>> GetWithDetailAndProductById(int id);
        Task<ServiceResult<IEnumerable<TransactionDetailDTO>>> GetTransactionDetailByTransactionId(int transactionId);
        Task<ServiceResult<IEnumerable<TransactionDetailReportDTO>>> TransactionDetailReport(TransactionDetailReportDTO criteria);
        Task<ServiceResult<int>> TransactionDetailReportCount(TransactionDetailReportDTO criteria);
    }
}
