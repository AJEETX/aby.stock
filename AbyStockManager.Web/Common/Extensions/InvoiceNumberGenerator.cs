using System;

using Aby.StockManager.Common.Enums;

namespace AbyStockManager.Web.Common.Extensions
{
    public class InvoiceNumberGenerator
    {
        private static int counter = 1;
        private static string prefix = string.Empty;

        public static string GenerateInvoiceNumber(int typeId)
        {
            if (typeId == (int)TransactionType.Sales)
            {
                prefix = string.Concat(TransactionType.Sales.ToString().AsSpan(0, 3), DateTime.Now.ToString("yyyyMMdd"), counter.ToString("D3"));
            }
            if (typeId == (int)TransactionType.Purchase)
            {
                prefix = string.Concat(TransactionType.Purchase.ToString().AsSpan(0, 3), DateTime.Now.ToString("yyyyMMdd"), counter.ToString("D3"));
            }
            counter++;
            return prefix;
        }
    }
}