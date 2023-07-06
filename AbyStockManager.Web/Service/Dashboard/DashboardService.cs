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

        Dictionary<string, double> CalculateWeeklyPurchase();
    }

    public class DashboardService : IDashboardService
    {
        private readonly EasyStockManagerDbContext db;

        public DashboardService(EasyStockManagerDbContext db)
        {
            this.db = db;
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

        public Dictionary<string, double> CalculatePurchaseChart()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var months = Enumerable.Range(0, 11)
                                   .Select(startDate.AddMonths)
                       .Select(m => m)
                       .ToList();
            foreach (var monthName in months)
            {
                var txn = db.TransactionDetail
                    .Include(d => d.Transaction)
                    .Include(d => d.Product)
                    .ThenInclude(d => d.Category);

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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var months = Enumerable.Range(0, 11)
                                   .Select(startDate.AddMonths)
                       .Select(m => m)
                       .ToList();
            foreach (var monthName in months)
            {
                var txn = db.TransactionDetail
                    .Include(d => d.Transaction)
                    .Include(d => d.Product)
                    .ThenInclude(d => d.Category);

                var filterTxn = txn.Where
                                (t =>
                                    t.Transaction.TransactionTypeId == 2 &&
                                    t.Transaction.TransactionDate > monthName.Date &&
                                    t.Transaction.TransactionDate <= monthName.AddMonths(1)
                                    );

                var catum = filterTxn.Select(t => t.Amount * t.FinalSalePrice.Value).Sum();
                dictMonthlySum.Add(monthName.ToString("MMM"), catum);
            }

            return dictMonthlySum;
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