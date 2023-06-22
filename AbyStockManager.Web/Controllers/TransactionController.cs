using System;
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
using Microsoft.AspNetCore.Hosting;
using AbyStockManager.Web.Model.ViewModel.Invoice;
using Microsoft.CodeAnalysis;
using AbyStockManager.Web.Common.Extensions;
using System.Globalization;

namespace Aby.StockManager.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper _mapper;

        public TransactionController(IStoreService storeService,
                                     IProductService productService,
                                     ITransactionService transactionService,
                                     IWebHostEnvironment webHostEnvironment,
                                     IMapper mapper)
        {
            _storeService = storeService;
            _productService = productService;
            _transactionService = transactionService;
            this.webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
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
            model.InvoiceNumber = InvoiceNumberGenerator.GenerateInvoiceNumber();

            if (typeId == (int)TransactionType.Invoice)
            {
                model.TransactionCode = TransactionType.Invoice.ToString();
            }
            if (typeId == (int)TransactionType.StockIn)
            {
                model.TransactionCode = TransactionType.StockIn.ToString();
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
                    //IEnumerable<TransactionDetailViewModel> transactionDetailViewModel = _mapper.Map<IEnumerable<TransactionDetailViewModel>>(serviceResult.TransactionResult);
                    jsonResultModel.Data = serviceResult.TransactionResult;

                    var subTotal = Math.Round(serviceResult.TransactionResult.Sum(r => r.Price * (100 / (100 + r.TaxRate)) * r.Amount).Value, 2);
                    var GrandTotal = serviceResult.TransactionResult.Sum(r => r.Price * r.Amount).Value;
                    var totalTax = GrandTotal - subTotal;
                    jsonResultModel.CgstTotal = "CGST:" + string.Format(new CultureInfo("hi-IN"), "{0:c}", totalTax / 2);
                    jsonResultModel.SgstTotal = "SGST:" + string.Format(new CultureInfo("hi-IN"), "{0:c}", totalTax / 2);
                    jsonResultModel.TaxTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", totalTax);

                    jsonResultModel.GrandPlainTotal = "Rs. " + NumberToWords.ConvertAmount(GrandTotal);
                    jsonResultModel.GrandTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", GrandTotal);
                    jsonResultModel.SubTotal = string.Format(new CultureInfo("hi-IN"), "{0:c}", serviceResult.TransactionResult.Sum(r => r.Price * (100 / (100 + r.TaxRate)) * r.Amount).Value);
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
            return "Create Invoice";
        }

        public async Task<IActionResult> Print(int id = 0)
        {
            CreateTransactionViewModel model = new CreateTransactionViewModel();
            model.StoreList = await GetStoreList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DoPrint(int id = 0)
        {
            string fName = Path.Combine(webHostEnvironment.WebRootPath, "invoice", "Receipt" + DateTime.Now.ToString("yyyymmddhhmmss") + ".pdf");

            var data = await _transactionService.GetTransactionDetailByTransactionId(id);

            var receiptDataList = new List<ReceiptData>();

            foreach (var item in data.TransactionResult)
            {
                var invnData = new ReceiptData
                {
                    Field = "Invoice Number",
                    Value = item.InvoiceNumber
                };

                var invDateData = new ReceiptData
                {
                    Field = "Date",
                    Value = DateTime.Now.ToString("dd-MMM-yyyy HH:mm")
                };
                var descriptionData = new ReceiptData
                {
                    Field = "Bill Detailed",
                    Value = item.Description
                };

                var productData = new ReceiptData
                {
                    Field = "Product name",
                    Value = item.ProductName
                };
                //var price = (item.Price) * (100 / (100 + item.Tax));
                var priceData = new ReceiptData
                {
                    Field = "Price",
                    //Value = "Rs. " + price.ToString("#,###.00")
                };

                var qtyData = new ReceiptData
                {
                    Field = "Qty",
                    Value = item.Amount.ToString()
                };
                var taxData = new ReceiptData
                {
                    Field = "GST [ %]",
                    //Value = (item.Price - price).ToString("#,###.00") + " [" + item.Tax.ToString("##.00") + " % ]"
                };

                var totalData = new ReceiptData
                {
                    Field = "Total Price",
                    //Value = "Rs. " + item.Price.ToString("#,###.00")
                };

                var payData = new ReceiptData
                {
                    Field = "Payment mode",
                    Value = "Cash / online"
                };

                receiptDataList.Add(invnData);
                receiptDataList.Add(invDateData);
                receiptDataList.Add(descriptionData);
                receiptDataList.Add(productData);
                receiptDataList.Add(priceData);
                receiptDataList.Add(qtyData);
                receiptDataList.Add(taxData);
                receiptDataList.Add(totalData);
                receiptDataList.Add(payData);
            }

            try
            {
                var invoiceFilePath = Path.Combine(webHostEnvironment.WebRootPath, "invoice");

                ReceiptRunner.Run(invoiceFilePath, receiptDataList).Build(fName);

                Console.WriteLine("\"" + Path.GetFullPath(fName) +
                              "\" document has been successfully built");

                var fileInfo = new System.IO.FileInfo(fName);
                Response.ContentType = "application/pdf";
                Response.Headers.Add("Content-Disposition", "attachment;filename=\"" + fileInfo.Name + "\"");
                Response.Headers.Add("Content-Length", fileInfo.Length.ToString());

                // Send the file to the client
                return File(System.IO.File.ReadAllBytes(fName), "application/pdf", fileInfo.Name);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return BadRequest(e.Message);
            }
        }
    }
}