using CanteenprojectH.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanteenprojectH.Controllers
{
    public class AccountController : Controller
    {
        private readonly CanteenDbContext _context;
        public AccountController(CanteenDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.PasswordHash == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                if (user.Role == "Admin")
                {
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                return RedirectToAction("ProductList", "Home");
            }
            ViewBag.Error = "Invalid login attempt";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}