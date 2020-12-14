using Microsoft.AspNetCore.Http;
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
        #region Properties
        private List<User> userList;
        private readonly UsersService usersService;
        private readonly UserMapper userMapper;
        #endregion

        #region Intialize
        public UsersController(IOptions<ApiConfiguration> apiConfig)
        {
            ApiConfiguration apiConfiguration = apiConfig.Value;
            usersService = new UsersService(apiConfiguration.ApiUsersUrl);
            userMapper = new UserMapper();
        }
        #endregion

        #region Http Methods
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            // Set Object Model
            IList<UserDto> users = await usersService.GetUsers(token);
            if (users != null)
            {
                userList = users.Select(userDto => userMapper.MapUserDtoToUser(userDto)).ToList();
            }

            return View(userList);
        }

        // GET: UsersController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id, token);

            if (userFound == null)
            {
                return NotFound();
            }

            var user = userMapper.MapUserDtoToUser(userFound);

            return View(user);
        }

        // GET: UsersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            LoadSessionProperties();

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                if (ModelState.IsValid)
                {
                    await usersService.AddUser(userMapper.MapUserToCreateUserDto(user), token);
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
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            var userFound = await usersService.GetUserById(id, token);

            if (userFound == null)
            {
                return NotFound();
            }

            var userToEdit = userMapper.MapUserDtoToUser(userFound);

            return View(userToEdit);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var userFound = await usersService.GetUserById(user.Id, token);

                if (userFound == null)
                {
                    return NotFound();
                }

                await usersService.UpdateUser(userMapper.MapUserToUpdateUserDto(user), user.Id, HttpContext.Session.GetString("Token"));

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
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token"); 

            var userFound = await usersService.GetUserById(id, token);

            if (userFound == null)
            {
                return NotFound();
            }

            var userToDelete = userMapper.MapUserDtoToUser(userFound);

            return View(userToDelete);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var userFound = await usersService.GetUserById(user.Id, token);

                if (userFound == null)
                {
                    return View();
                }

                await usersService.DeleteUser(user.Id, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
        
        // Loads to view data properties the session attributes that have been passed from previews controllers
        private void LoadSessionProperties()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Name"] = HttpContext.Session.GetString("Name");
        }
    }
}