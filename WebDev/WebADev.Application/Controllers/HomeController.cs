﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebADev.Application.Models;
using WebDev.Application.Models;
using Microsoft.AspNetCore.Http;
using WebDev.Services;
using WebDev.Application.Config;
using Microsoft.Extensions.Options;
using WebDev.Services.Entities;

namespace WebADev.Application.Controllers
{
    public class HomeController : Controller
    {
        #region Servicios
        private LoginService loginService;
        #endregion

        #region Atributos
        private ApiConfiguration _apiConfiguration;
        private readonly ILogger<HomeController> _logger;
        #endregion

        #region Constructores
        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            _logger = logger;
            loginService = new LoginService(_apiConfiguration.ApiLoginUrl);
        }
        #endregion

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
                    var tokenDto = IsValidUser(login.Email, login.Password);
                    if (tokenDto != null)
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

        private async Task<TokenDto> IsValidUser(string email, string password)
        {
            LoginDto loginDto = new LoginDto();
            loginDto.email = email;
            loginDto.password = password;

            var tokenDto = await loginService.ValideUser(loginDto);

            if (tokenDto != null)
            {
                HttpContext.Session.SetString("IsUserLogged", "true");
                HttpContext.Session.SetString("User", email);
                return tokenDto;
            }
            else
            {
                HttpContext.Session.SetString("IsUserLogged", "false");
                return null;
            }
        }
    }
}
