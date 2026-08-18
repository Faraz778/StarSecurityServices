using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Data;
using StarSecurityServices.Models;

namespace StarSecurityServices.Controllers
{
    public class AdminController : Controller
    {
        private readonly StarSecurityDbContext _db;

        public AdminController(StarSecurityDbContext db)
        {
            _db = db;
        }

        // ===== AUTH CHECK =====
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("UserRole") == "Admin";
        }

        // ===== DASHBOARD =====
        public IActionResult Dashboard()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            ViewBag.TotalEmployees = _db.Employees.Count();
            ViewBag.TotalClients = _db.Clients.Count();
            ViewBag.TotalVacancies = _db.Vacancies.Count(v => v.IsFilled == false);
            ViewBag.TotalServices = _db.Services.Count();

            return View();
        }

        // ===== EMPLOYEES =====
        public IActionResult Employees()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var list = _db.Employees.ToList();
            return View(list);
        }

        public IActionResult AddEmployee()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            ViewBag.Clients = _db.Clients.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Employees.Add(emp);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        public IActionResult EditEmployee(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var emp = _db.Employees.Find(id);
            if (emp == null) return NotFound();
            ViewBag.Clients = _db.Clients.ToList();
            return View(emp);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Employees.Update(emp);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        public IActionResult DeleteEmployee(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var emp = _db.Employees.Find(id);
            if (emp != null)
            {
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
            return RedirectToAction("Employees");
        }

        // ===== CLIENTS =====
        public IActionResult Clients()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var list = _db.Clients.ToList();
            return View(list);
        }

        public IActionResult AddClient()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Clients");
        }

        public IActionResult EditClient(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var client = _db.Clients.Find(id);
            if (client == null) return NotFound();
            return View(client);
        }

        [HttpPost]
        public IActionResult EditClient(Client client)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Clients.Update(client);
            _db.SaveChanges();
            return RedirectToAction("Clients");
        }

        public IActionResult DeleteClient(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var client = _db.Clients.Find(id);
            if (client != null)
            {
                _db.Clients.Remove(client);
                _db.SaveChanges();
            }
            return RedirectToAction("Clients");
        }

        // ===== VACANCIES =====
        public IActionResult Vacancies()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var list = _db.Vacancies.ToList();
            return View(list);
        }

        public IActionResult AddVacancy()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult AddVacancy(Vacancy vacancy)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Vacancies.Add(vacancy);
            _db.SaveChanges();
            return RedirectToAction("Vacancies");
        }

        public IActionResult EditVacancy(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var vacancy = _db.Vacancies.Find(id);
            if (vacancy == null) return NotFound();
            return View(vacancy);
        }

        [HttpPost]
        public IActionResult EditVacancy(Vacancy vacancy)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Vacancies.Update(vacancy);
            _db.SaveChanges();
            return RedirectToAction("Vacancies");
        }

        public IActionResult DeleteVacancy(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var vacancy = _db.Vacancies.Find(id);
            if (vacancy != null)
            {
                _db.Vacancies.Remove(vacancy);
                _db.SaveChanges();
            }
            return RedirectToAction("Vacancies");
        }

        // ===== SERVICES =====
        public IActionResult Services()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var list = _db.Services.ToList();
            return View(list);
        }

        public IActionResult AddService()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Services.Add(service);
            _db.SaveChanges();
            return RedirectToAction("Services");
        }

        public IActionResult EditService(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var service = _db.Services.Find(id);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            _db.Services.Update(service);
            _db.SaveChanges();
            return RedirectToAction("Services");
        }

        public IActionResult DeleteService(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var service = _db.Services.Find(id);
            if (service != null)
            {
                _db.Services.Remove(service);
                _db.SaveChanges();
            }
            return RedirectToAction("Services");
        }
    }
}