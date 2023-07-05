using System.Collections.Generic;

using AbyStockManager.Web.Service.Dashboard;

using Microsoft.AspNetCore.Mvc;

namespace AbyStockManager.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
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
    }
}