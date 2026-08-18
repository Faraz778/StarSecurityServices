using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Data;

namespace StarSecurityServices.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly StarSecurityDbContext _db;

        public EmployeeController(StarSecurityDbContext db)
        {
            _db = db;
        }

        private bool IsEmployee()
        {
            var role = HttpContext.Session.GetString("UserRole");
            return role == "Employee" || role == "Admin";
        }

        // Profile Page
        public IActionResult Profile()
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Account");

            var userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr))
                return RedirectToAction("Login", "Account");

            int userId = int.Parse(userIdStr);
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null || user.EmployeeId == null)
            {
                ViewBag.Message = "No employee profile linked to this account.";
                return View();
            }

            var employee = _db.Employees
                .FirstOrDefault(e => e.Id == user.EmployeeId);

            if (employee == null)
            {
                ViewBag.Message = "Employee record not found.";
                return View();
            }

            return View(employee);
        }

        // All Employees List (Read Only)
        public IActionResult EmployeeList()
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Account");

            var employees = _db.Employees.ToList();
            return View(employees);
        }

        // Employee Detail (Read Only)
        public IActionResult EmployeeDetail(int id)
        {
            if (!IsEmployee())
                return RedirectToAction("Login", "Account");

            var employee = _db.Employees
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}