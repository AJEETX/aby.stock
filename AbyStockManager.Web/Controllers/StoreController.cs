using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Model.ViewModel.Store;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Aby.StockManager.Service.User;

namespace Aby.StockManager.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IWebHostEnvironment webHostEnvironment,
                              IMapper mapper)
        {
            _storeService = storeService;
            this._webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(CreateStoreViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string newFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(model.ImageFile.FileName);
                    newFileName += fileExtension;
                    var upload = Path.Combine(_webHostEnvironment.WebRootPath, "store", newFileName);
                    model.ImageFile.CopyTo(new FileStream(upload, FileMode.Create));
                    model.Image = newFileName;
                }
                StoreDTO storeDTO = _mapper.Map<StoreDTO>(model);
                var serviceResult = await _storeService.AddAsync(storeDTO);
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
            var serviceResult = await _storeService.GetById(id);
            EditStoreViewModel model = _mapper.Map<EditStoreViewModel>(serviceResult.TransactionResult);
            if (!string.IsNullOrEmpty(model.Image))
                model.ImageDisplayURL = Path.Combine(_webHostEnvironment.WebRootPath, "store", model.Image);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditStoreViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string newFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(model.ImageFile.FileName);
                    newFileName += fileExtension;
                    var upload = Path.Combine(_webHostEnvironment.WebRootPath, "store", newFileName);
                    model.ImageFile.CopyTo(new FileStream(upload, FileMode.Create));
                    model.Image = newFileName;
                }
                StoreDTO StoreDTO = _mapper.Map<StoreDTO>(model);
                var serviceResult = await _storeService.Update(StoreDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Store";
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
        public async Task<IActionResult> List(SearchStoreViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                StoreDTO storeDTO = _mapper.Map<StoreDTO>(model);
                ServiceResult<int> serviceCountResult = await _storeService.FindCount(storeDTO);
                ServiceResult<IEnumerable<StoreDTO>> serviceListResult = await _storeService.Find(storeDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListStoreViewModel> listVM = _mapper.Map<List<ListStoreViewModel>>(serviceListResult.TransactionResult);
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
        public async Task<IActionResult> DeleteImage(int id)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult serviceResult = await _storeService.DeleteProductImage(id);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
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
                ServiceResult serviceResult = await _storeService.RemoveById(id);
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