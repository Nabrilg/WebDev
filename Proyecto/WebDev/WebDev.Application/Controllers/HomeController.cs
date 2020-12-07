using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDev.Application.Models;
using WebDev.Services.Entities;
using WebDev.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebDev.Application.Config;
using Microsoft.Extensions.Options;

namespace WebDev.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LoginService loginService;
        private readonly ApiConfiguration _apiConfiguration;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfiguration> apiConfiguration)
        {
            _logger = logger;
            _apiConfiguration = apiConfiguration.Value;
            loginService = new LoginService(_apiConfiguration.ApiUsersUrl); ;
        }

        public IActionResult Index()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Llamar a la API para validar el Login
                    if (await IsValidUser(login.Email, login.Password))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IsUserLogged", "false");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IsValidUser(string email, string password)
        {
            if (email.Length != 0 && password.Length!=0)
            {
                UserDto User = new UserDto{ Email = email, Password = password };
                try
                {
                    TokenDto token = await loginService.ValidateUser(User);
                    if (token != null)
                    {
                        HttpContext.Session.SetString("IsUserLogged", "true");
                        HttpContext.Session.SetString("User", email);
                        return true;
                    }
                }
                catch {
                }
            }
            HttpContext.Session.SetString("IsUserLogged", "false");
            return false;
        }
    }
}
