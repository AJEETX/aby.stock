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
                prefix = TransactionType.Invoice.ToString() + DateTime.Now.ToString("yyyyMMdd") + counter.ToString("D4");
            }
            if (typeId == (int)TransactionType.StockIn)
            {
                prefix = TransactionType.StockIn.ToString() + DateTime.Now.ToString("yyyyMMdd") + counter.ToString("D4");
            }
            counter++;
            return prefix;
        }
    }
}