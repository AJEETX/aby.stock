﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aby.StockManager.Common.Enums;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Model.ViewModel.Transaction;
using System.Diagnostics;
using System.IO;
using Receipt;

namespace Aby.StockManager.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(IStoreService storeService,
                                     IProductService productService,
                                     ITransactionService transactionService,
                                     IMapper mapper)
        {
            _storeService = storeService;
            _productService = productService;
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public IActionResult Print()
        {
            string[] args = null;
            Parameters parameters = new Parameters(null, "Content//Receipt" + DateTime.Now.ToString("yyyymmdd") + ".pdf");
            if (!PrepareParameters(parameters, args))
            {
                return BadRequest();
            }
            try
            {
                ReceiptRunner.Run().Build(parameters.file);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return BadRequest();
            }
            Console.WriteLine("\"" + Path.GetFullPath(parameters.file) +
                              "\" document has been successfully built");
            if (parameters.appToView != null)
            {
                Start(parameters.file, parameters.appToView);
            }
            return Ok();
        }

        public async Task<IActionResult> Index()
        {
            SearchTransactionViewModel model = new SearchTransactionViewModel();
            model.StoreList = await GetStoreList();
            model.ToStoreList = model.StoreList;
            return View(model);
        }

        public async Task<IActionResult> Create(int typeId)
        {
            CreateTransactionViewModel model = new CreateTransactionViewModel();
            model.TransactionTypeId = typeId;
            model.PageName = GetPageName(typeId);
            model.StoreList = await GetStoreList();

            if (typeId == (int)TransactionType.Invoice)
            {
                model.TransactionCode = TransactionType.Invoice.ToString();
                model.InvoiceNumber = DateTime.Now.ToString("yyyyMMMddhhmmss").ToUpper() + "SALES-INV";
            }
            if (typeId == (int)TransactionType.StockIn)
            {
                model.TransactionCode = TransactionType.StockIn.ToString();
                model.InvoiceNumber = DateTime.Now.ToString("yyyyMMMddhhmmss").ToUpper() + "STOCK-INV";
            }
            var serviceResult = await _storeService.GetAll();
            model.StoreId = serviceResult.TransactionResult.FirstOrDefault().Id.Value;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(CreateTransactionViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                if (model.TransactionTypeId == (int)TransactionType.Invoice)
                {
                    model.TransactionCode = TransactionType.Invoice.ToString();
                }
                if (model.TransactionTypeId == (int)TransactionType.StockIn)
                {
                    model.TransactionCode = TransactionType.StockIn.ToString();
                }
                TransactionDTO transactionDTO = _mapper.Map<TransactionDTO>(model);
                var serviceResult = await _transactionService.AddAsync(transactionDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        public async Task<IActionResult> Edit(int id, int typeId)
        {
            EditTransactionViewModel model = new EditTransactionViewModel();
            var serviceResult = await _transactionService.GetWithDetailAndProductById(id);
            model = _mapper.Map<EditTransactionViewModel>(serviceResult.TransactionResult);
            model.StoreList = await GetStoreList();
            model.PageName = GetPageName(typeId);

            model.TransactionDetailCount = model.TransactionDetail.Count();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditTransactionViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                TransactionDTO transactionDTO = _mapper.Map<TransactionDTO>(model);
                var serviceResult = await _transactionService.Update(transactionDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Transaction";
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
                ServiceResult serviceResult = await _transactionService.RemoveById(id);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchTransactionViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                TransactionDTO transactionDTO = _mapper.Map<TransactionDTO>(model);
                ServiceResult<int> serviceCountResult = await _transactionService.FindCount(transactionDTO);
                ServiceResult<IEnumerable<TransactionDTO>> serviceListResult = await _transactionService.Find(transactionDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListTransactionViewModel> listVM = _mapper.Map<List<ListTransactionViewModel>>(serviceListResult.TransactionResult);
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

        [HttpGet]
        public async Task<IActionResult> GetTransactionDetail(int id)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                var serviceResult = await _transactionService.GetTransactionDetailByTransactionId(id);
                if (serviceResult.IsSucceeded)
                {
                    IEnumerable<TransactionDetailViewModel> transactionDetailViewModel = _mapper.Map<IEnumerable<TransactionDetailViewModel>>(serviceResult.TransactionResult);
                    jsonResultModel.Data = transactionDetailViewModel;
                }
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }

            return Json(jsonResultModel);
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

        private string GetPageName(int transactionTypeId)
        {
            if ((int)TransactionType.StockIn == transactionTypeId)
                return "Stock In";
            else if ((int)TransactionType.Invoice == transactionTypeId)
                return "Create Invoice";
            return string.Empty;
        }

        private static bool PrepareParameters(Parameters parameters, string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0].Equals("?")
                    || args[0].Equals("-h")
                    || args[0].Equals("-help")
                    || args[0].Equals("--h")
                    || args[0].Equals("--help")
                    )
                {
                    Usage();
                    return false;
                }
                parameters.file = args[0];
                if (args.Length > 1)
                {
                    parameters.appToView = args[1];
                }
            }

            if (System.IO.File.Exists(parameters.file))
            {
                try
                {
                    System.IO.File.Delete(parameters.file);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can't delete file: " +
                        Path.GetFullPath(parameters.file));
                    Console.Error.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }

        private static void Usage()
        {
            Console.WriteLine("Usage: dotnet run [fullPathToOutFile] [appToView]");
            Console.WriteLine("Where: fullPathToOutFile - a path to the result file, 'Receipt.pdf' by default");
            Console.WriteLine("appToView - the name of an application to view the file immediately after preparing, by default none app starts");
        }

        private static void Start(string file, string appToView)
        {
            var psi = new ProcessStartInfo("cmd", @"/c start " + appToView + " " + file);
            Process.Start(psi);
        }

        internal class Parameters
        {
            public string appToView;
            public string file;

            public Parameters(string appToView, string file)
            {
                this.appToView = appToView;
                this.file = file;
            }
        }
    }
}