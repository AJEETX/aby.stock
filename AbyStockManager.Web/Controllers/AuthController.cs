using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.Auth;
using Aby.StockManager.Model.ViewModel.JsonResult;

namespace Aby.StockManager.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult result = await _userService.Login(model.Email, model.Password);
                if (result.IsSucceeded)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Email) };
                    var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    jsonResultModel.IsSucceeded = true;
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/Report";
                }
                else
                {
                    jsonResultModel.IsSucceeded = false;
                    jsonResultModel.UserMessage = result.UserMessage;
                }
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/auth/login");
        }
    }
}