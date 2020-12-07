using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebDev.Application.Models;
using WebDev.Application.Config;
using Microsoft.Extensions.Options;
using WebDev.Services;
using WebDev.Services.Entities;

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
            var token = HttpContext.Session.GetString("Token");
            IList<UserDto> users = await usersService.GetUsers(token);

            _userList = users.Select(userDto => MapperToUser(userDto)).ToList();

            return View(_userList);
        }

        // GET: UsersController/Details/5
        public ActionResult Details()
        {
            return View();
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
        public async Task<ActionResult> CreateAsync(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Id = ++numUsers;
                    _userList.Add(user);
                    var token = HttpContext.Session.GetString("Token");
                    var ans = await usersService.AddUser(MapperToUserDto(user),token);
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

        public ActionResult Edit(int id)
        {
            var userFound = _userList.FirstOrDefault(u => u.Id == id);


            if (userFound == null)
            {
                return NotFound();
            }

            return View(userFound);
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
                    var token = HttpContext.Session.GetString("Token");
                    var ans =  await usersService.UpdateUserById(MapperToUserDto(user),token);

                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var token = HttpContext.Session.GetString("Token");

            var ans = await usersService.GetUserById(id,token);
            var userFound = _userList.FirstOrDefault(u => u.Id == id);


            if (userFound == null)
            {
                return NotFound();
            }

            return View(userFound);
        }

        // GET: UsersController/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userFound = _userList.FirstOrDefault(u => u.Id == id);

            if (userFound == null)
            {
                return NotFound();
            }

            return View(userFound);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
            try
            {
                var userFound = _userList.FirstOrDefault(u => u.Id == user.Id);

                if (userFound == null)
                {
                    return View();
                }
                var token = HttpContext.Session.GetString("Token");
                var ans = await usersService.DeleteUserById(user.Id,token);
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
                Id = userDto.id,
                Email = userDto.email,
                Name = userDto.name,
                Username = userDto.username,
                Password = userDto.password
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
    }
}
