using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Application.Config;
using WebDev.Application.Models;
using WebDev.Services;
using WebDev.Services.Entities;

namespace WebDev.Application.Controllers
{
    public class UsersController : Controller
    {
        #region Properties
        private List<User> userList;
        private readonly ApiConfiguration apiConfiguration;
        private UsersService usersService;
        #endregion

        public UsersController(IOptions<ApiConfiguration> apiConfig)
        {
            apiConfiguration = apiConfig.Value;
            usersService = new UsersService(apiConfiguration.ApiUsersUrl);
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            // Set Object Model
            IList<UserDto> users = await usersService.GetUsers(HttpContext.Session.GetString("Token"));
            if (users != null)
            {
                userList = users.Select(userDto => MapperToUser(userDto)).ToList();
            }
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            return View(userList);
        }

        // GET: UsersController/Details/5
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
                    var userIdAdded = await usersService.AddUser(MapperToCreateUserDto(user), HttpContext.Session.GetString("Token"));
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
                var userFound = await usersService.GetUserById(user.Id, HttpContext.Session.GetString("Token"));

                if (userFound == null)
                {
                    return NotFound();
                }

                var isSuccessUserModified = await usersService.UpdateUser(MapperToUpdateUserDto(user), user.Id, HttpContext.Session.GetString("Token"));

                return RedirectToAction(nameof(Index));
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

        // POST: UsersController/Delete/5
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

                var isSuccessUserDeleted = await usersService.DeleteUser(user.Id, HttpContext.Session.GetString("Token"));

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

        private UpdateUserDto MapperToUpdateUserDto(User user)
        {
            return UpdateUserDto.Build(
                email:user.Email,
                name: user.Name,
                username: user.Username,
                password: user.Password
            );
        }

        private CreateUserDto MapperToCreateUserDto(User user)
        {
            return CreateUserDto.Build(
                id: user.Id,
                email: user.Email,
                name: user.Name,
                username: user.Username,
                password: user.Password
            );
        }

        private void MockUserList()
        {
            if (userList is null)
            {
                userList = new List<User>()
                {
                    new User{Id=1, Email="Julio.Robles@email.com", Name="Julio Robles", Username="jrobles", Password="Password"},
                    new User{Id=2, Email="Pilar.Lopez@email.com", Name="Pilar Lopez", Username="plopez", Password="Password"},
                    new User{Id=3, Email="Felipe.Daza@email.com", Name="Felipe Daza", Username="fdaza", Password="Password"},
                };
            }
        }
    }
}