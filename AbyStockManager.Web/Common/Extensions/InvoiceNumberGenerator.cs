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
            if (typeId == (int)TransactionType.Invoice)
            {
                prefix = string.Concat(TransactionType.Invoice.ToString().AsSpan(0, 3), DateTime.Now.ToString("yyyyMMdd"), counter.ToString("D3"));
            }
            if (typeId == (int)TransactionType.StockIn)
            {
                prefix = string.Concat(TransactionType.StockIn.ToString().AsSpan(0, 3), DateTime.Now.ToString("yyyyMMdd"), counter.ToString("D3"));
            }
            counter++;
            return prefix;
        }
    }
}