using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Model.ViewModel.Report.StoreStock;
using Aby.StockManager.Model.ViewModel.Report.TransactionDetail;
using System.Collections;
using System.Globalization;
using Aby.StockManager.Model.ViewModel.Category;
using Aby.StockManager.Service.Category;
using AbyStockManager.Web.Model.ViewModel.Report.StoreStock;

namespace Aby.StockManager.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IStoreStockService _storeStockService;
        private readonly ITransactionService _transactionService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public ReportController(IStoreStockService storeStockService,
                                IProductService productService,
                                IStoreService storeService,
                                IMapper mapper,
                                ITransactionService transactionService)
        {
            _storeStockService = storeStockService;
            _productService = productService;
            _storeService = storeService;
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            SearchStoreStockReportViewModel model = new SearchStoreStockReportViewModel();
            model.StoreList = await GetStoreList();
            model.ProductList = new List<SelectListItem>();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceResult = await _productService.GetById(id);
            var storeData = await _storeService.GetById(1);

            var storeStockDTO = new StoreStockDTO
            {
                ProductId = id,
                StoreId = storeData.TransactionResult.Id,
            };

            var storeStock = await _storeStockService.Find(storeStockDTO);

            EditStoreStockReportViewModel model = _mapper.Map<EditStoreStockReportViewModel>(storeStock.TransactionResult.FirstOrDefault());
            model.ProductFullName = serviceResult.TransactionResult.ProductName;
            model.PurchasePrice = string.Format(new CultureInfo("hi-IN"), "{0:c}", (serviceResult.TransactionResult.PurchasePrice));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditStoreStockReportViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                var productResult = await _productService.GetById(model.ProductId);
                model.PurchasePrice = productResult.TransactionResult.PurchasePrice?.ToString();
                StoreStockDTO stockDTO = _mapper.Map<StoreStockDTO>(model);

                var serviceResult = await _storeStockService.Update(stockDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Report";
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
        public async Task<IActionResult> StoreStockList(SearchStoreStockReportViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                StoreStockDTO storeStockDTO = _mapper.Map<StoreStockDTO>(model);
                ServiceResult<int> serviceCountResult = await _storeStockService.FindCount(storeStockDTO);
                ServiceResult<IEnumerable<StoreStockDTO>> serviceListResult = await _storeStockService.StoreStockReport(storeStockDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListStoreStockReportViewModel> listVM = _mapper.Map<List<ListStoreStockReportViewModel>>(serviceListResult.TransactionResult);
                    double total = listVM.Sum(item => double.Parse(item.ProductTotalPrice));
                    jsonDataTableModel.aaData = listVM;
                    jsonDataTableModel.iTotalDisplayRecords = serviceCountResult.TransactionResult;
                    jsonDataTableModel.iTotalRecords = serviceCountResult.TransactionResult;
                    jsonDataTableModel.iAllProductTotalPrice = string.Format(new CultureInfo("hi-IN"), "{0:c}", total);
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

        public async Task<IActionResult> TransactionDetailReport()
        {
            SearchTransactionDetailReportViewModel model = new SearchTransactionDetailReportViewModel();
            model.StoreList = await GetStoreList();
            model.ToStoreList = model.StoreList;
            model.ProductList = new List<SelectListItem>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> TransactionDetailList(SearchTransactionDetailReportViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                TransactionDetailReportDTO transactionDetailReportDTO = _mapper.Map<TransactionDetailReportDTO>(model);
                ServiceResult<int> serviceCountResult = await _transactionService.TransactionDetailReportCount(transactionDetailReportDTO);
                ServiceResult<IEnumerable<TransactionDetailReportDTO>> serviceListResult = await _transactionService.TransactionDetailReport(transactionDetailReportDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListTransactionDetailReportViewModel> listVM = _mapper.Map<List<ListTransactionDetailReportViewModel>>(serviceListResult.TransactionResult);
                    jsonDataTableModel.aaData = listVM;
                    jsonDataTableModel.iTotalDisplayRecords = serviceCountResult.TransactionResult;
                    jsonDataTableModel.iTotalRecords = serviceCountResult.TransactionResult;
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

        private async Task<IEnumerable<SelectListItem>> GetStoreList()
        {
            ServiceResult<IEnumerable<StoreDTO>> serviceResult = await _storeService.GetAll();
            IEnumerable<SelectListItem> drpStoreList = _mapper.Map<IEnumerable<SelectListItem>>(serviceResult.TransactionResult);
            return drpStoreList;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(string search)
        {
            ServiceResult<IEnumerable<ProductDTO>> serviceResult = await _productService.GetProductsByBarcodeAndName(search);
            IEnumerable<SelectListItem> drpProductList = _mapper.Map<IEnumerable<SelectListItem>>(serviceResult.TransactionResult);
            return Json(drpProductList);
        }
    }
}