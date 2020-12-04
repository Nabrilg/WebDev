using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebDev.Application.Config;
using WebDev.Application.Models;
using WebDev.Services;
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
            loginService = new LoginService(_apiConfiguration.ApiLoginUrl);
        }

        public IActionResult Index()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Token "] = HttpContext.Session.GetString("Token");
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
        [ValidateAntiForgeryToken] //The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks.
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginCreds = await loginService.Login(MapperToLoginDto(login));
                    // Llamar a la API para validar el Login
                    if (await IsValidUser(loginCreds))
                    {
                        Console.WriteLine("Soy un usuario valido bitch");
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


        private async Task<bool> IsValidUser(TokenDto loginCreds)
        {
            if (loginCreds != null)
            {
                //Configure the session variables
                HttpContext.Session.SetString("IsUserLogged", "true");
                HttpContext.Session.SetString("Token", loginCreds.token);
                HttpContext.Session.SetString("UserId", loginCreds.userId.ToString());
                return true;
            }
            HttpContext.Session.SetString("IsUserLogged", "false");
            return false;
        }

        private LoginDto MapperToLoginDto(Login login)
        {
            return LoginDto.Build(
                email: login.Email,
                password: login.Password
                );
        }


    }
}