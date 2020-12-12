using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace WebDev.Application.Controllers
{
    public class GlobalDataInjectorAttribute : ActionFilterAttribute
    {
        // Class for setting global header ViewData on action calls

        private static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            controller.ViewData["IsUserLogged"] = _session.GetString("IsUserLogged");
            controller.ViewData["User"] = _session.GetString("User");
            controller.ViewData["Token"] = _session.GetString("Token");
            base.OnActionExecuting(filterContext);
        }
    }
}