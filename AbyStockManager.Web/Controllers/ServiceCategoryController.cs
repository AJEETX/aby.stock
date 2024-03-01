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
using Aby.StockManager.Model.ViewModel.ServiceCategory;
using Aby.StockManager.Service.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using AbyStockManager.Web.Common.Message;

namespace Aby.StockManager.Web.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private readonly IServiceCategoryService _categoryService;
        private readonly IMapper _mapper;

        public ServiceCategoryController(IServiceCategoryService categoryService,
                                  IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            SearchServiceCategoryViewModel model = new SearchServiceCategoryViewModel();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(CreateServiceCategoryViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult<IEnumerable<ServiceCategoryDTO>> serviceListResult = await _categoryService.Find(new ServiceCategoryDTO { ServiceCategoryName = model.ServiceCategoryName });
                if (serviceListResult != null && serviceListResult.TransactionResult.Count() > 0)
                {
                    jsonResultModel.IsSucceeded = false;
                    jsonResultModel.UserMessage = string.Format(CommonMessages.MSG0002, $"{model.ServiceCategoryName} exists");
                    return Json(jsonResultModel);
                }
                ServiceCategoryDTO categoryDTO = _mapper.Map<ServiceCategoryDTO>(model);
                var serviceResult = await _categoryService.AddAsync(categoryDTO);
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
            EditServiceCategoryViewModel model = _mapper.Map<EditServiceCategoryViewModel>(serviceResult.TransactionResult);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditServiceCategoryViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceCategoryDTO categoryDTO = _mapper.Map<ServiceCategoryDTO>(model);
                var serviceResult = await _categoryService.Update(categoryDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/ServiceCategory";
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
        public async Task<IActionResult> List(SearchServiceCategoryViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                ServiceCategoryDTO categoryDTO = _mapper.Map<ServiceCategoryDTO>(model);
                ServiceResult<int> serviceCountResult = await _categoryService.FindCount(categoryDTO);
                ServiceResult<IEnumerable<ServiceCategoryDTO>> serviceListResult = await _categoryService.Find(categoryDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListServiceCategoryViewModel> listVM = _mapper.Map<List<ListServiceCategoryViewModel>>(serviceListResult.TransactionResult);
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