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
using Aby.StockManager.Model.ViewModel.User;
using Aby.StockManager.Service.Product;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Aby.StockManager.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment,
                              IMapper mapper)
        {
            _userService = userService;
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
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string newFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(model.ImageFile.FileName);
                    newFileName += fileExtension;
                    var upload = Path.Combine(_webHostEnvironment.WebRootPath, "user", newFileName);
                    model.ImageFile.CopyTo(new FileStream(upload, FileMode.Create));
                    model.Image = newFileName;
                }
                UserDTO userDTO = _mapper.Map<UserDTO>(model);
                var serviceResult = await _userService.AddAsync(userDTO);
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
            var serviceResult = await _userService.GetById(id);
            EditUserViewModel model = _mapper.Map<EditUserViewModel>(serviceResult.TransactionResult);
            if (!string.IsNullOrEmpty(model.Image))
                model.ImageDisplayURL = Path.Combine(_webHostEnvironment.WebRootPath, "user", model.Image);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string newFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(model.ImageFile.FileName);
                    newFileName += fileExtension;
                    var upload = Path.Combine(_webHostEnvironment.WebRootPath, "user", newFileName);
                    model.ImageFile.CopyTo(new FileStream(upload, FileMode.Create));
                    model.Image = newFileName;
                }
                UserDTO userDTO = _mapper.Map<UserDTO>(model);
                var serviceResult = await _userService.Update(userDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/User";
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
        public async Task<IActionResult> List(SearchUserViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(model);
                ServiceResult<int> serviceCountResult = await _userService.FindCount(userDTO);
                ServiceResult<IEnumerable<UserDTO>> serviceListResult = await _userService.Find(userDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListUserViewModel> listVM = _mapper.Map<List<ListUserViewModel>>(serviceListResult.TransactionResult);
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
                ServiceResult serviceResult = await _userService.DeleteProductImage(id);
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
                ServiceResult serviceResult = await _userService.RemoveById(id);
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