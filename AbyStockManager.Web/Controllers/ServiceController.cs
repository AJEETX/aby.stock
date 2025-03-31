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
using Aby.StockManager.Service.Store;
using AbyStockManager.Web.Common.Extensions;
using Aby.StockManager.Web.Service;

namespace AbyStockManager.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceReportService expenseService;
        private readonly IServiceCategoryService categoryService;
        private readonly IStoreService _storeService;
        private readonly INumberSequenceService sequenceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceReportService _expenseService,
                                     INumberSequenceService sequenceService,
            IServiceCategoryService categoryService, IStoreService _storeService, IMapper mapper)
        {
            expenseService = _expenseService;
            this.categoryService = categoryService;
            this._storeService = _storeService;
            this.sequenceService = sequenceService;
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
                model.InvoiceNumber = sequenceService.GetInvoiceNumberSequence(Aby.StockManager.Common.Enums.TransactionType.Svx.ToString());
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

        [HttpGet]
        public async Task<IActionResult> GetServiceDetail(int id)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                var serviceResult = await expenseService.GetById(id);
                var storeData = _storeService.GetById(1);
                jsonResultModel.Data = new List<ServiceReportDTO> { serviceResult.TransactionResult };

                jsonResultModel.StoreImage = "/store/" + storeData.Result.TransactionResult.Image;
                jsonResultModel.StoreName = storeData.Result.TransactionResult.StoreName;
                jsonResultModel.StoreAddress = storeData.Result.TransactionResult.StoreCode;
                jsonResultModel.StoreContact = storeData.Result.TransactionResult.Contact;
                jsonResultModel.StoreGstin = storeData.Result.TransactionResult.Gstin;
                var GrandTotal = serviceResult.TransactionResult.Amount;
                var tax = (double)100 / 118;
                var subTotal = Math.Round(serviceResult.TransactionResult.Amount * tax, 2);
                var totalTax = GrandTotal - subTotal;
                jsonResultModel.CgstTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", totalTax / 2);
                jsonResultModel.SgstTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", totalTax / 2);
                jsonResultModel.TaxTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", totalTax);

                jsonResultModel.GrandPlainTotal = "Rs. " + NumberToWords.ConvertAmount(GrandTotal);
                jsonResultModel.GrandTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", GrandTotal);
                jsonResultModel.SubTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", subTotal);
                jsonResultModel.PrintHeader = "Tax Invoice";
                jsonResultModel.PrintBillType = "Invoice";
                jsonResultModel.PrintBilled = "Balance Amount!";
                jsonResultModel.PrintBillNotice = "";
                jsonResultModel.PrintBillTo = "Bill to:";
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