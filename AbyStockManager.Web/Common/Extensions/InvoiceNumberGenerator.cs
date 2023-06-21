using System;

namespace AbyStockManager.Web.Common.Extensions
{
    public class InvoiceNumberGenerator
    {
        private static int counter = 1;

        public static string GenerateInvoiceNumber()
        {
            string invoiceNumber = "Inv-" + DateTime.Now.ToString("yyyyMMdd") + counter.ToString("D4");
            counter++;
            return invoiceNumber;
        }
    }
}