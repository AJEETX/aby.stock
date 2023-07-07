using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

using Aby.StockManager.Data.Context;
using Aby.StockManager.Data.Entity;

using Microsoft.EntityFrameworkCore;

namespace AbyStockManager.Web.Service.Dashboard
{
    public interface IDashboardService
    {
        Dictionary<string, double> CalculateMonthlySale();

        Dictionary<string, double> CalculateSaleChart();

        Dictionary<string, double> CalculateWeeklySale();

        Dictionary<string, double> CalculateMonthlyPurchase();

        Dictionary<string, double> CalculatePurchaseChart();

        Dictionary<string, double> CalculateExpenseChart();

        Dictionary<string, double> CalculateProductChart();

        Dictionary<string, double> CalculateWeeklyPurchase();

        Dictionary<string, double> CalculateWeeklyProductSale();

        Dictionary<string, double> CalculateMonthlyProductSale();
    }

    public class DashboardService : IDashboardService
    {
        private readonly EasyStockManagerDbContext db;

        public DashboardService(EasyStockManagerDbContext db)
        {
            this.db = db;
        }

        public Dictionary<string, double> CalculateExpenseChart()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var months = Enumerable.Range(0, 11)
                                   .Select(startDate.AddMonths)
                       .Select(m => m)
                       .ToList();
            var txn = db.ExpenseReport.Include(i => i.Category);
            foreach (var monthName in months)
            {
                var filterTxn = txn.Where(t =>
                                    t.ExpenseDate > monthName.Date &&
                                    t.ExpenseDate <= monthName.AddMonths(1));

                var catum = filterTxn.Select(t => t.Amount).Sum();
                dictMonthlySum.Add(monthName.ToString("MMM"), catum);
            }

            return dictMonthlySum;
        }

        public Dictionary<string, double> CalculateMonthlyProductSale()
        {
            Dictionary<string, double> dictWeeklySum = new Dictionary<string, double>();
            var tdetail = db.TransactionDetail
                .Include(t => t.Transaction)
                .Include(t => t.Product)
                .OrderByDescending(o => o.Amount * o.FinalSalePrice.Value)
                .GroupBy(g => g.ProductId);

            foreach (var td in tdetail)
            {
                double totalSale = 0;
                string productName = string.Empty;
                foreach (var m in td)
                {
                    if (string.IsNullOrWhiteSpace(productName))
                    {
                        productName = m.Product.ProductName;
                    }
                    if (m.Transaction.TransactionTypeId == 2 && m.Transaction.TransactionDate > DateTime.Now.AddMonths(-7))
                    {
                        totalSale += m.Amount * m.FinalSalePrice.Value;
                    }
                }
                if (totalSale > 0)
                {
                    dictWeeklySum.Add(productName, totalSale);
                }
            }
            return dictWeeklySum;
        }

        public Dictionary<string, double> CalculateMonthlyPurchase()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var categories = db.Category;

            foreach (var category in categories)
            {
                double catum = db.TransactionDetail
                    .Include(d => d.Transaction)
                    .Include(d => d.Product)
                    .ThenInclude(d => d.Category)
                    .Where
                                (t => t.Product.Category.Id == category.Id &&
                                    t.Transaction.TransactionTypeId == 1 &&
                                (t.Transaction.TransactionDate > DateTime.Now.AddMonths(-7)))
                                .Select(t => t.Amount * t.Product.PurchasePrice.Value)
                                .Sum();
                dictMonthlySum.Add(category.CategoryName, catum);
            }

            return dictMonthlySum;
        }

        public Dictionary<string, double> CalculateMonthlySale()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var categories = db.Category;

            foreach (var category in categories)
            {
                double catum = db.TransactionDetail
                    .Include(d => d.Transaction)
                    .Include(d => d.Product)
                    .ThenInclude(d => d.Category)
                    .Where
                                (t => t.Product.Category.Id == category.Id &&
                                    t.Transaction.TransactionTypeId == 2 &&
                                (t.Transaction.TransactionDate > DateTime.Now.AddMonths(-7)))
                                .Select(t => t.Amount * t.FinalSalePrice.Value)
                                .Sum();
                dictMonthlySum.Add(category.CategoryName, catum);
            }

            return dictMonthlySum;
        }

        public Dictionary<string, double> CalculateProductChart()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var months = Enumerable.Range(0, 11).Select(startDate.AddMonths).Select(m => m).ToList();
            var tdetail = db.TransactionDetail
                .Include(t => t.Transaction)
                .Include(t => t.Product)
                .OrderByDescending(o => o.Amount * o.FinalSalePrice.Value)
                .GroupBy(g => g.ProductId);
            foreach (var monthName in months)
            {
                double totalSale = 0;
                foreach (var txn in tdetail)
                {
                    var filterP = txn.Where
                                (t =>
                                    t.Transaction.TransactionTypeId == 2 &&
                                    t.Transaction.TransactionDate > monthName.Date &&
                                    t.Transaction.TransactionDate <= monthName.AddMonths(1)
                                    );
                    totalSale += filterP.Select(t => t.Amount * t.FinalSalePrice.Value).Sum();
                }
                if (totalSale > 0)
                {
                    dictMonthlySum.Add(monthName.ToString("MMM"), totalSale);
                }
            }
            return dictMonthlySum;
        }

        public Dictionary<string, double> CalculatePurchaseChart()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var months = Enumerable.Range(0, 11)
                                   .Select(startDate.AddMonths)
                       .Select(m => m)
                       .ToList();
            var txn = db.TransactionDetail
            .Include(d => d.Transaction)
            .Include(d => d.Product)
            .ThenInclude(d => d.Category);
            foreach (var monthName in months)
            {
                var filterTxn = txn.Where
                                (t =>
                                    t.Transaction.TransactionTypeId == 1 &&
                                    t.Transaction.TransactionDate > monthName.Date &&
                                    t.Transaction.TransactionDate <= monthName.AddMonths(1)
                                    );

                var catum = filterTxn.Select(t => t.Amount * t.Product.PurchasePrice.Value).Sum();
                dictMonthlySum.Add(monthName.ToString("MMM"), catum);
            }

            return dictMonthlySum;
        }

        public Dictionary<string, double> CalculateSaleChart()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var months = Enumerable.Range(0, 11)
                                   .Select(startDate.AddMonths)
                       .Select(m => m)
                       .ToList();
            var txn = db.TransactionDetail
             .Include(d => d.Transaction)
             .Include(d => d.Product)
             .ThenInclude(d => d.Category);
            foreach (var monthName in months)
            {
                var filterTxn = txn.Where(t => t.Transaction.TransactionTypeId == 2 &&
                                   t.Transaction.TransactionDate > monthName.Date &&
                                   t.Transaction.TransactionDate <= monthName.AddMonths(1));

                var catum = filterTxn.Select(t => t.Amount * t.FinalSalePrice.Value).Sum();
                dictMonthlySum.Add(monthName.ToString("MMM"), catum);
            }

            return dictMonthlySum;
        }

        public Dictionary<string, double> CalculateWeeklyProductSale()
        {
            Dictionary<string, double> dictWeeklySum = new Dictionary<string, double>();
            var tdetail = db.TransactionDetail
                .Include(t => t.Transaction)
                .Include(t => t.Product)
                .OrderByDescending(o => o.Amount * o.FinalSalePrice.Value)
                .GroupBy(g => g.ProductId);

            foreach (var td in tdetail)
            {
                double totalSale = 0;
                string productName = string.Empty;
                foreach (var m in td)
                {
                    if (string.IsNullOrWhiteSpace(productName))
                    {
                        productName = m.Product.ProductName;
                    }
                    if (m.Transaction.TransactionTypeId == 2 && m.Transaction.TransactionDate > DateTime.Now.AddDays(-28))
                    {
                        totalSale += m.Amount * m.FinalSalePrice.Value;
                    }
                }
                if (totalSale > 0)
                {
                    dictWeeklySum.Add(productName, totalSale);
                }
            }
            return dictWeeklySum;
        }

        public Dictionary<string, double> CalculateWeeklyPurchase()
        {
            Dictionary<string, double> dictWeeklySum = new Dictionary<string, double>();

            var categories = db.Category;

            foreach (var category in categories)
            {
                double catum = db.TransactionDetail
                    .Include(d => d.Transaction)
                    .Include(d => d.Product)
                    .ThenInclude(d => d.Category)
                    .Where
                                (t => t.Product.Category.Id == category.Id &&
                                    t.Transaction.TransactionTypeId == 1 &&
                                (t.Transaction.TransactionDate > DateTime.Now.AddDays(-28)))
                                .Select(t => t.Amount * t.Product.PurchasePrice.Value)
                                .Sum();
                dictWeeklySum.Add(category.CategoryName, catum);
            }

            return dictWeeklySum;
        }

        public Dictionary<string, double> CalculateWeeklySale()
        {
            Dictionary<string, double> dictWeeklySum = new Dictionary<string, double>();

            var categories = db.Category;

            foreach (var category in categories)
            {
                double catum = db.TransactionDetail
                    .Include(d => d.Transaction)
                    .Include(d => d.Product)
                    .ThenInclude(d => d.Category)
                    .Where
                                (t => t.Product.Category.Id == category.Id &&
                                t.Transaction.TransactionTypeId == 2 &&
                                t.Transaction.TransactionDate > DateTime.Now.AddDays(-28))
                                .Select(t => t.Amount * t.FinalSalePrice.Value)
                                .Sum();
                dictWeeklySum.Add(category.CategoryName, catum);
            }

            return dictWeeklySum;
        }
    }
}