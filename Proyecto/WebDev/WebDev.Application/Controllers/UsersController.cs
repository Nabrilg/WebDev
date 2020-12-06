using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev.Application.Models;
using WebDev.Application.Config;
using WebDev.Services;
using Microsoft.Extensions.Options;
using WebDev.Services.Entities;

namespace WebDev.Application.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> _userList;


        private readonly ApiConfiguration _apiConfiguration;
        private UsersService usersService;

        public TokenDto tokenDto;

        public UsersController(IOptions<ApiConfiguration> apiConfiguration)
        {

            _apiConfiguration = apiConfiguration.Value;
            usersService = new UsersService(_apiConfiguration.ApiUsersUrl);
            
        }

        // GET: UsersController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            usersService.TokenDto = HttpContext.Session.GetString("Token");

            IList<UserDto> users = await usersService.GetUsers();
            _userList = users.Select(userDto => MapperToUser(userDto)).ToList(); 
            
            //Session variables
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Token "] = HttpContext.Session.GetString("Token");
            return View(_userList);
        }

        // GET: UsersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {

            usersService.TokenDto = HttpContext.Session.GetString("Token");
            var userFound = await usersService.GetUserById(id);
            //Check if the user is not found.
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
            //Session variables
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Token "] = HttpContext.Session.GetString("Token");
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
                    usersService.TokenDto = HttpContext.Session.GetString("Token");

                    var userAdded = await usersService.AddUser(MapperToUserDtoCreate(user));
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
            usersService.TokenDto = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            //Session variables
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Token "] = HttpContext.Session.GetString("Token");
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
                    usersService.TokenDto = HttpContext.Session.GetString("Token");

                    await usersService.UpdateUser(MapperToUserDto(user));

                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            usersService.TokenDto = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = MapperToUser(userFound);

            //Session variables
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Token "] = HttpContext.Session.GetString("Token");
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
            try
            {
                usersService.TokenDto = HttpContext.Session.GetString("Token");

                var userFound = await usersService.GetUserById(user.Id);

                if (userFound == null)
                {
                    return View();
                }

                await usersService.DeleteUser(user.Id);

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

        private CreateUserDto MapperToUserDtoCreate(User user)
        {
            return CreateUserDto.Build(
              email: user.Email,
              name: user.Name,
              username: user.Username,
              password: user.Password
            );
        }

    }
}
