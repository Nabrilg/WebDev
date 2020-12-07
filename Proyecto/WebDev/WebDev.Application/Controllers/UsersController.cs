﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebDev.Application.Models;
using WebDev.Application.Config;
using Microsoft.Extensions.Options;
using WebDev.Services.Entities;
using WebDev.Services;

namespace WebDev.Application.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> _userList;
        private static int numUsers;
        private readonly ApiConfiguration _apiConfiguration;
        private UsersService usersService;

        public UsersController(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;

            usersService = new UsersService(_apiConfiguration.ApiUsersUrl);
        }

        // GET: UsersController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IList<UserDto> users = await usersService.GetUsers(HttpContext.Session.GetString("Token"));

            _userList = users.Select(userDto => MapperToUser(userDto)).ToList();

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            return View(_userList);
        }

        //GET: UsersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var userFound = await usersService.GetUserById(id, HttpContext.Session.GetString("Token"));

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            return View(user);
        }
        // GET: UsersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userAdded = await usersService.AddUser(MapperToCreateUserDto(user), HttpContext.Session.GetString("Token"));
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
            var userFound = await usersService.GetUserById(id, HttpContext.Session.GetString("Token"));

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            return View(user);
        }

       // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userModified = await usersService.UpdateUser(MapperToUpdatedUserDto(user), HttpContext.Session.GetString("Token"));

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
            var userFound = await usersService.GetUserById(id, HttpContext.Session.GetString("Token"));

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            return View(user);
        }

        //POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
            try
            {
                var userFound = await usersService.GetUserById(user.Id, HttpContext.Session.GetString("Token"));

                if (userFound == null)
                {
                    return View();
                }

                var userDeleted = await usersService.DeleteUser(MapperToUpdatedUserDto(user), HttpContext.Session.GetString("Token"));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private User MapperToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password
            };
        }

        private UserDto MapperToUserDto(User user)
        {
            return UserDto.Build(
              id: user.Id,
              email: user.Email,
              name: user.Name,
              username: user.Username,
              password: user.Password
            );
        }
        private CreateUserDto MapperToCreateUserDto(User user)
        {
            return CreateUserDto.Build(
              email: user.Email,
              name: user.Name,
              username: user.Username,
              password: user.Password
            );
        }
        private UpdatedUserDto MapperToUpdatedUserDto(User user)
        {
            return UpdatedUserDto.Build(
              id: user.Id,
              email: user.Email,
              name: user.Name,
              username: user.Username,
              password: user.Password
            );
        }
    }
}
