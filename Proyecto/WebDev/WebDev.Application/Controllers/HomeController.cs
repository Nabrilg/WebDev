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
        private LoginService loginService;
        private readonly ApiConfiguration _apiConfiguration;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfiguration> apiConfiguration)
        {
            _logger = logger;
            _apiConfiguration = apiConfiguration.Value;
            loginService = new LoginService(_apiConfiguration.ApiLoginUrl);
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
                    var SuccessLogin = await loginService.ValidUser(MapperToLoginDto(login));
                    if (IsValidUser(SuccessLogin))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(string.Empty, "Login Failed.");
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

        private bool IsValidUser(TokenDto tokenDto)
        {
            if (tokenDto != null)
            {
                HttpContext.Session.SetString("IsUserLogged", "true");
                HttpContext.Session.SetString("User", tokenDto.Name);
                HttpContext.Session.SetString("TokenData", tokenDto.Token);
                return true;
            }
            HttpContext.Session.SetString("IsUserLogged", "false");
            return false;
        }

        private Login MapperToLogin(LoginDto loginDto)
        {
            return new Login
            {
                Email = loginDto.Email,
                Password = loginDto.Password,
                RememberMe = false
            };
        }

        private LoginDto MapperToLoginDto(Login login)
        {
            return LoginDto.Build(
              email : login.Email,       
              password: login.Password
            );
        }
    }
}