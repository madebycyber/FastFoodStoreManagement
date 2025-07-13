using Microsoft.AspNetCore.Mvc;
using FastFoodWebApp.Models;

namespace FastFoodWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý logic đăng nhập (giả sử đã xác thực)
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý logic đăng ký (lưu thông tin)
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}
