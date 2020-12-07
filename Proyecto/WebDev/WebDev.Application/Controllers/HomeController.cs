using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebDev.Application.Config;
using WebDev.Logins;
using WebDev.Logins.Entities;
using WebDev.Application.Models;
using Microsoft.Extensions.Options;
using WebDev.Application.Mappers;

namespace WebDev.Application.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApiConfiguration _apiConfiguration;
        private LoginsService loginsService;

        public HomeController(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            loginsService = new LoginsService(_apiConfiguration.ApiLoginUrl);
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
                    var ValidUser = await loginsService.ValidUser(LoginMappers.MapperToLoginDto(login));
                    if (ValidUser != null)
                        {
                        HttpContext.Session.SetString("IsUserLogged", "true");
                        HttpContext.Session.SetString("User", ValidUser.name);
                        HttpContext.Session.SetString("Token", ValidUser.token);
                        return RedirectToAction(nameof(Index));
                    }
                    HttpContext.Session.SetString("IsUserLogged", "false");
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
    }
}
