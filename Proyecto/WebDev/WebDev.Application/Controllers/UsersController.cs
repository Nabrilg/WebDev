﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Application.Config;
using WebDev.Application.Mappers;
using WebDev.Application.Models;
using WebDev.Services;
using WebDev.Services.Entities;

namespace WebDev.Application.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(IOptions<ApiConfiguration> apiConfiguration)
        {
            var _apiConfiguration = apiConfiguration.Value;
            usersService = new UsersService(_apiConfiguration.ApiUsersUrl);
            //Segunda Opcion:
            //usersService.TokenDto = LoginMappers.MapperToTokenDto(JsonConvert.DeserializeObject<Login>(HttpContext.Session.GetString("Token")));
        }

        // GET: UsersController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string vartoken = HttpContext.Session.GetString("Token");

            IList<UserDto> users = await usersService.GetUsers(vartoken);

            var _userList = users.Select(userDto => UserMappers.MapperToUser(userDto)).ToList();

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(_userList);
        }

        // GET: UsersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            string vartoken = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id, vartoken);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = UserMappers.MapperToUser(userFound);

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(user);
        }

        // GET: UsersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            try
            {
                if (ModelState.IsValid)
                {
                    string vartoken = HttpContext.Session.GetString("Token");

                    await usersService.AddUser(UserMappers.MapperToUserDto(user), vartoken);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            string vartoken = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id, vartoken);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = UserMappers.MapperToUser(userFound);

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            try
            {
                if (ModelState.IsValid)
                {
                    string vartoken = HttpContext.Session.GetString("Token");

                    await usersService.UpdateUser(UserMappers.MapperToUserDto(user), vartoken);

                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            string vartoken = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id, vartoken);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = UserMappers.MapperToUser(userFound);

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            try
            {
                string vartoken = HttpContext.Session.GetString("Token");

                var userFound = await usersService.GetUserById(user.Id, vartoken);

                if (userFound == null)
                {
                    return View();
                }

                await usersService.DeleteUser(user.Id, vartoken);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}