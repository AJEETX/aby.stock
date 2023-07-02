using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Aby.StockManager.Core.Service;
using Aby.StockManager.Data.Entity;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.Category;
using Aby.StockManager.Model.ViewModel.Expense;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Model.ViewModel.Transaction;
using Aby.StockManager.Service;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbyStockManager.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseReportService expenseService;
        private readonly IExpenseCategoryService categoryService;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseReportService _expenseService, IExpenseCategoryService categoryService, IMapper mapper)
        {
            expenseService = _expenseService;
            this.categoryService = categoryService;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            SearchExpenseReportViewModel model = new SearchExpenseReportViewModel();
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchExpenseReportViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                ExpenseReportDTO transactionDTO = _mapper.Map<ExpenseReportDTO>(model);
                ServiceResult<int> serviceCountResult = await expenseService.FindCount(transactionDTO);
                ServiceResult<IEnumerable<ExpenseReportDTO>> serviceListResult = await expenseService.Find(transactionDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListExpenseReportViewModel> listVM = _mapper.Map<List<ListExpenseReportViewModel>>(serviceListResult.TransactionResult);
                    var totalExpense = serviceListResult.TransactionResult.Sum(s => s.Amount);

                    jsonDataTableModel.aaData = listVM;
                    jsonDataTableModel.iTotalDisplayRecords = serviceCountResult.TransactionResult;
                    jsonDataTableModel.iTotalRecords = serviceCountResult.TransactionResult;
                    jsonDataTableModel.iAllProductTotalPrice = string.Format(new CultureInfo("hi-IN"), "{0:c}", totalExpense);
                }
                else
                {
                    jsonDataTableModel.IsSucceeded = false;
                    jsonDataTableModel.UserMessage = serviceCountResult.UserMessage + "-" + serviceListResult.UserMessage;
                }
            }
            catch (Exception ex)
            {
                jsonDataTableModel.IsSucceeded = false;
                jsonDataTableModel.UserMessage = ex.Message;
            }

            return Json(jsonDataTableModel);
        }

        public ActionResult AddEditExpenses(int itemId)
        {
            ExpenseReport model = new ExpenseReport();
            if (itemId > 0)
            {
                model = expenseService.GetExpenseData(itemId);
            }
            return PartialView("_expenseForm", model);
        }

        public async Task<IActionResult> Create()
        {
            CreateExpenseReportViewModel model = new CreateExpenseReportViewModel();
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseReportViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ExpenseReportDTO categoryDTO = _mapper.Map<ExpenseReportDTO>(model);
                var serviceResult = await expenseService.AddAsync(categoryDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceResult = await expenseService.GetById(id);
            EditExpenseReportViewModel model = _mapper.Map<EditExpenseReportViewModel>(serviceResult.TransactionResult);
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditExpenseReportViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ExpenseReportDTO categoryDTO = _mapper.Map<ExpenseReportDTO>(model);
                var serviceResult = await expenseService.Update(categoryDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Expense";
                }
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult serviceResult = await expenseService.RemoveById(id);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        public ActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }

        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, double> monthlyExpense = expenseService.CalculateMonthlyExpense();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, double> weeklyExpense = expenseService.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoryList()
        {
            ServiceResult<IEnumerable<ExpenseCategoryDTO>> serviceResult = await categoryService.GetAll();
            IEnumerable<SelectListItem> drpCategoryList = _mapper.Map<IEnumerable<SelectListItem>>(serviceResult.TransactionResult);
            return drpCategoryList;
        }
    }
}