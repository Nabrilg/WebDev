﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDev.Application.Models;
using Microsoft.AspNetCore.Http;
using WebDev.Application.Config;
using WebDev.Services.Entities;
using WebDev.Services;
using Microsoft.Extensions.Options;

namespace WebDev.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApiConfiguration _apiConfiguration;
        private LoginService loginService;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            loginService = new LoginService(_apiConfiguration.ApiLoginUrl);
            _logger = logger;
        }


        public IActionResult Index()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
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
                    var loginChecked = await loginService.ValidUser(MapperToLoginDto(login));                 
                    if (IsValidUser(loginChecked))
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

        private bool IsValidUser(TokenDto loginChecked)
        {
            if (loginChecked != null)
            {
                HttpContext.Session.SetString("IsUserLogged", "true");
                HttpContext.Session.SetString("User", loginChecked.Name);
                HttpContext.Session.SetString("Token", loginChecked.Token);
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
                Password = loginDto.Password
            };
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