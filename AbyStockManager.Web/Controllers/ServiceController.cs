using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Aby.StockManager.Core.Service;
using Aby.StockManager.Data.Entity;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.Service;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Service;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbyStockManager.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceReportService expenseService;
        private readonly IServiceCategoryService categoryService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceReportService _expenseService, IServiceCategoryService categoryService, IMapper mapper)
        {
            expenseService = _expenseService;
            this.categoryService = categoryService;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            SearchServiceReportViewModel model = new SearchServiceReportViewModel();
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchServiceReportViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                ServiceReportDTO transactionDTO = _mapper.Map<ServiceReportDTO>(model);
                ServiceResult<int> serviceCountResult = await expenseService.FindCount(transactionDTO);
                ServiceResult<IEnumerable<ServiceReportDTO>> serviceListResult = await expenseService.Find(transactionDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListServiceReportViewModel> listVM = _mapper.Map<List<ListServiceReportViewModel>>(serviceListResult.TransactionResult);
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
            ServiceReport model = new ServiceReport();
            if (itemId > 0)
            {
                model = expenseService.GetServiceData(itemId);
            }
            return PartialView("_expenseForm", model);
        }

        public async Task<IActionResult> Create()
        {
            CreateServiceReportViewModel model = new CreateServiceReportViewModel();
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceReportViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceReportDTO categoryDTO = _mapper.Map<ServiceReportDTO>(model);
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
            EditServiceReportViewModel model = _mapper.Map<EditServiceReportViewModel>(serviceResult.TransactionResult);
            model.CategoryList = await GetCategoryList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditServiceReportViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceReportDTO categoryDTO = _mapper.Map<ServiceReportDTO>(model);
                var serviceResult = await expenseService.Update(categoryDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Service";
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
            Dictionary<string, double> monthlyExpense = expenseService.CalculateMonthlyService();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, double> weeklyExpense = expenseService.CalculateWeeklyService();
            return new JsonResult(weeklyExpense);
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoryList()
        {
            ServiceResult<IEnumerable<ServiceCategoryDTO>> serviceResult = await categoryService.GetAll();
            IEnumerable<SelectListItem> drpCategoryList = _mapper.Map<IEnumerable<SelectListItem>>(serviceResult.TransactionResult);
            return drpCategoryList;
        }
    }
}