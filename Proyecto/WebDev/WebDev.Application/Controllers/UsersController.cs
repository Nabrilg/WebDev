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
using Microsoft.Extensions.Caching.Memory;
using WebDev.Application.Utils;

namespace WebDev.Application.Controllers
{
    [GlobalDataInjector]
    public class UsersController : Controller
    { 
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private readonly ApiConfiguration _apiConfiguration;

        private UsersService usersService;

        private CacheManagement memManage;

        // Inject the context in order to access the JWToken got in HomeController
        public UsersController(IOptions<ApiConfiguration> apiConfiguration, IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache)
        {

            _apiConfiguration = apiConfiguration.Value;
            _httpContextAccessor = httpContextAccessor;
            memManage = new CacheManagement(memoryCache);
            usersService = new UsersService(_apiConfiguration.ApiUsersUrl, _session.GetString("Token"));
        }

        // GET: UsersController
        // After first call get data from Cache Memory instead API
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (!memManage._cache.TryGetValue(CacheKeys.Users, out List<User> _userList))
            {
                IList<UserDto> users = await usersService.GetUsers();
                _userList = users.Select(userDto => MapperToUser(userDto)).ToList();
                memManage.FillUsers(CacheKeys.Users, _userList);
            }
            return View(_userList);
        }


        // GET: UsersController/Details/5
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
                    var userAdded = await usersService.AddUser(MapperToUserDto(user));
                    memManage.CreateCacheUser(CacheKeys.Users, user);

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
            var userFound = await usersService.GetUserById(id);

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
                    var userModified = await usersService.UpdateUser(MapperToUserDto(user));
                    memManage.UpdateCacheUser(CacheKeys.Users, user);

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
            var userFound = await usersService.GetUserById(id);

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
                var userFound = await usersService.GetUserById(user.Id);

                if (userFound == null)
                {
                    return View();
                }

                var userDeleted = await usersService.DeleteUser(user.Id);
                memManage.DeleteCacheUser(CacheKeys.Users, user);

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
    }
}