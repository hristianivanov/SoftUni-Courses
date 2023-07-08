using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        [ActionName("UserLogin")]
        [HttpPost]
        [RequireHttps]
        public IActionResult Login(string username,string password)
        {
	        return Content("Logged in!");
        }

        public IActionResult ByUsername(string username)
        {
	        return Content(username);
        }
    }
}
