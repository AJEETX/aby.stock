using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.Category;
using Aby.StockManager.Model.ViewModel.JsonResult;
using AbyStockManager.Web.Model.ViewModel.Tax;
using Aby.StockManager.Service.Product;
using AbyStockManager.Web.Common.Message;

namespace Aby.StockManager.Web.Controllers
{
    public class TaxController : Controller
    {
        private readonly ITaxService _categoryService;
        private readonly IMapper _mapper;

        public TaxController(ITaxService categoryService,
                                  IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(CreateTaxViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult<IEnumerable<TaxDTO>> serviceListResult = await _categoryService.Find(new TaxDTO { Name = model.Name });
                if (serviceListResult != null || serviceListResult.TransactionResult != null || serviceListResult.TransactionResult.Any())
                {
                    jsonResultModel.IsSucceeded = false;
                    jsonResultModel.UserMessage = string.Format(CommonMessages.MSG0002, $"{model.Name} exists");
                    return Json(jsonResultModel);
                }

                TaxDTO taxDTO = _mapper.Map<TaxDTO>(model);
                var serviceResult = await _categoryService.AddAsync(taxDTO);
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
            var serviceResult = await _categoryService.GetById(id);
            EditTaxViewModel model = _mapper.Map<EditTaxViewModel>(serviceResult.TransactionResult);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditTaxViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                TaxDTO categoryDTO = _mapper.Map<TaxDTO>(model);
                var serviceResult = await _categoryService.Update(categoryDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Tax";
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
        public async Task<IActionResult> List(SearchTaxViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                TaxDTO categoryDTO = _mapper.Map<TaxDTO>(model);
                ServiceResult<int> serviceCountResult = await _categoryService.FindCount(categoryDTO);
                ServiceResult<IEnumerable<TaxDTO>> serviceListResult = await _categoryService.Find(categoryDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListTaxViewModel> listVM = _mapper.Map<List<ListTaxViewModel>>(serviceListResult.TransactionResult);
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult serviceResult = await _categoryService.RemoveById(id);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }
    }
}