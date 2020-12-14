using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDev.Application.Models;
using Microsoft.AspNetCore.Http;
using WebDev.Application.Config;
using WebDev.Services;
using Microsoft.Extensions.Options;
using WebDev.Services.Entities;


namespace WebDev.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiConfiguration _apiConfiguration;
        private LoginService loginService;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfiguration> apiConfiguration)
        {
            _logger = logger;
            _apiConfiguration = apiConfiguration.Value;
            loginService = new LoginService(_apiConfiguration.ApiUsersUrl);
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
                    if (await IsValidUser(login))
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

        private async Task<bool> IsValidUser(Login login)
        {
            try
            {
                TokenDto loggedUser = await loginService.ValidateUser(LoginDto.Build(email: login.Email, password: login.Password));
                if (loggedUser == null)
                {
                    HttpContext.Session.SetString("IsUserLogged", "false");
                    return false;
                }
                else
                {
                    HttpContext.Session.SetString("IsUserLogged", "true");
                    HttpContext.Session.SetString("User", login.Email);
                    HttpContext.Session.SetString("Token", loggedUser.token);
                    HttpContext.Session.SetInt32("Id", loggedUser.userId);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
