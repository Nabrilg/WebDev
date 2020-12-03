using System;
using System.Diagnostics;
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
        #region Properties
        private readonly ILogger<HomeController> _logger;
        private readonly ApiConfiguration apiConfiguration;
        private LoginService loginService;
        #endregion

        #region Initialize
        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfiguration> apiConfig)
        {
            apiConfiguration = apiConfig.Value;
            loginService = new LoginService(apiConfiguration.ApiLoginUrl);
            _logger = logger;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Email"] = HttpContext.Session.GetString("Email");
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            ViewData["Token"] = HttpContext.Session.GetString("Token");
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
        // [Route("[action]")]
        public IActionResult Login()
        {
            // La relación del método con la vista para cargarla.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Validación por tokens
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var token = await loginService.Login(MapperToLoginDto(login));
                    if (token != null)
                    {
                        HttpContext.Session.SetString("IsUserLogged", "true");
                        HttpContext.Session.SetString("Email", login.Email);
                        HttpContext.Session.SetString("Token", token.token);
                        HttpContext.Session.SetString("Name", token.name);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Login attempt failed.");
                    }
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
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("Token");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IsValidUser(string email, string password)
        {
            if (email.Equals("demouser@email.com") && password.Equals("Password*01"))
            {
                HttpContext.Session.SetString("IsUserLogged", "true");
                HttpContext.Session.SetString("User", email);
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
        #endregion
    }
}
