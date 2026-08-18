using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Data;
using System.Linq;

namespace StarSecurityServices.Controllers
{
    public class AccountController : Controller
    {
        private readonly StarSecurityDbContext _db;

        public AccountController(StarSecurityDbContext db)
        {
            _db = db;
        }

        // GET: Login Page
        public IActionResult Login()
        {
            // Agar pehle se login hai toh redirect karo
            if (HttpContext.Session.GetString("UserRole") != null)
            {
                var role = HttpContext.Session.GetString("UserRole");
                if (role == "Admin")
                    return RedirectToAction("Dashboard", "Admin");
                else
                    return RedirectToAction("Profile", "Employee");
            }
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _db.Users
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user != null)
            {
                // Session mein save karo
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("UserRole", user.Role);

                if (user.Role == "Admin")
                    return RedirectToAction("Dashboard", "Admin");
                else
                    return RedirectToAction("Profile", "Employee");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}