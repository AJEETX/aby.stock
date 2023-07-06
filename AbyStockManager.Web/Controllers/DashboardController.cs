using System.Collections.Generic;

using Aby.StockManager.Service;

using AbyStockManager.Web.Service.Dashboard;

using Microsoft.AspNetCore.Mvc;

namespace AbyStockManager.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;
        private readonly IExpenseReportService expenseReportService;

        public DashboardController(IDashboardService dashboardService, IExpenseReportService expenseReportService)
        {
            this.dashboardService = dashboardService;
            this.expenseReportService = expenseReportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ExpenseSummary()
        {
            return PartialView("_saleReport");
        }

        public JsonResult GetMonthlySale()
        {
            Dictionary<string, double> monthlyExpense = dashboardService.CalculateMonthlySale();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetSaleChart()
        {
            Dictionary<string, double> monthlyExpense = dashboardService.CalculateSaleChart();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetPurchaseChart()
        {
            Dictionary<string, double> monthlyExpense = dashboardService.CalculatePurchaseChart();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklySale()
        {
            Dictionary<string, double> weeklyExpense = dashboardService.CalculateWeeklySale();
            return new JsonResult(weeklyExpense);
        }

        public JsonResult GetMonthlyPurchase()
        {
            Dictionary<string, double> monthlyExpense = dashboardService.CalculateMonthlyPurchase();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyPurchase()
        {
            Dictionary<string, double> weeklyExpense = dashboardService.CalculateWeeklyPurchase();
            return new JsonResult(weeklyExpense);
        }

        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, double> monthlyExpense = expenseReportService.CalculateMonthlyExpense();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, double> weeklyExpense = expenseReportService.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }

        public JsonResult GetExpenseChart()
        {
            Dictionary<string, double> monthlyExpense = dashboardService.CalculateExpenseChart();
            return new JsonResult(monthlyExpense);
        }
    }
}