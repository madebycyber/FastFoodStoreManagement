using Microsoft.AspNetCore.Mvc;

namespace FastFoodWebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
