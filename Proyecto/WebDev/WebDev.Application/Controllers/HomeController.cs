using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDev.Application.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Text;

namespace WebDev.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                    //var uri = new Uri("http://localhost:8082/login");

                    //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8082/login");
                    //httpWebRequest.ContentType = "application/json";
                    //httpWebRequest.Method = "POST";

                    //HttpWebRequest request = HttpWebRequest.CreateHttp(uri);
                    //request.ContentType = "application/json";
                    //request.Method = "POST";

                    //string json = JsonConvert.SerializeObject(login, Formatting.Indented);

                    // Serialize our concrete class into a JSON String 
                    var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(login));

                    // Wrap our JSON inside a StringContent which then can be used by the HttpClient class 
                    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                    //httpContent.Method = "POST";

                    using (var httpClient = new HttpClient())
                    {

                        // Do the actual request and await the response 
                        var httpResponse = await httpClient.PostAsync("http://localhost:8082/login", httpContent);

                        // If the response contains content we want to read it! 
                        if (httpResponse.Content != null)
                        {
                            var responseContent = await httpResponse.Content.ReadAsStringAsync();
                        
                           

                            // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net 
                        }

                        // Llamar a la API para validar el Login

                        //httpResponse.Content

                        if ((int)httpResponse.StatusCode == 200 )
                        {
                            HttpContext.Session.SetString("IsUserLogged", "true");
                            HttpContext.Session.SetString("User", login.email);
                            return RedirectToAction(nameof(Index));
                        }
                        //HttpContext.Session.SetString("IsUserLogged", "false");
                        ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
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
            return RedirectToAction(nameof(Index));
        }

        //private async Task<bool> IsValidUser(string email, string password)
        //{
        //    if (email.Equals("demouser@gmail.com") && password.Equals("Password*01"))           //cambiar
        //    {
        //        HttpContext.Session.SetString("IsUserLogged", "true");
        //        HttpContext.Session.SetString("User", email);
        //        return true;
        //    }
        //    HttpContext.Session.SetString("IsUserLogged", "false");
        //    return false;
        //}
    }
}
