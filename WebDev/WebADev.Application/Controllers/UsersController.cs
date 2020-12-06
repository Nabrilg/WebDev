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
using WebDev.Services.Entities;
using WebDev.Services;

namespace WebADev.Application.Controllers
{
    public class UsersController : Controller
    {
        #region Atributos
        private static List<User> _userList;
        private static int numUsers;
        private readonly ApiConfiguration _apiConfiguration;
        private UsersService usersService;
        #endregion

        #region Constructores
        public UsersController(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            usersService = new UsersService(_apiConfiguration.ApiUsersUrl);
        }
        #endregion

        #region GET: UsersController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IList<UserDto> users = await usersService.GetUsers();

            _userList = users.Select(userDto => MapperToUser(userDto)).ToList();
            numUsers = _userList.Count();

            return View(_userList);
        }
        #endregion

        #region GET: UsersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var userFound = await usersService.GetUserById(id);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            return View(user);
        }
        #endregion

        #region GET: UsersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userAdded = await usersService.AddUser(MapperToUserDto(user));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region GET: UsersController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var userFound = await usersService.GetUserById(id);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            return View(user);
        }
        #endregion

        #region POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userModified = await usersService.UpdateUser(MapperToUserDto(user));

                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region GET: UsersController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var userFound = await usersService.GetUserById(id);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            return View(user);
        }
        #endregion

        #region POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
            try
            {
                var userFound = await usersService.GetUserById(user.id);

                if (userFound == null)
                {
                    return View();
                }

                var userDeleted = await usersService.DeleteUser(user.id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Mappers
        private User MapperToUser(UserDto userDto)
        {
            return new User
            {
                id = userDto.id,
                email = userDto.email,
                name = userDto.name,
                username = userDto.username,
                password = userDto.password
            };
        }

        private UserDto MapperToUserDto(User user)
        {
            return UserDto.Build(
              id: user.id,
              email: user.email,
              name: user.name,
              username: user.username,
              password: user.password
            );
        }
        #endregion

    }
}
