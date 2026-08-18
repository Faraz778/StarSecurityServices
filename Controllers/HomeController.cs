using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Data;

namespace StarSecurityServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly StarSecurityDbContext _db;

        public HomeController(StarSecurityDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Network()
        {
            return View();
        }

        public IActionResult Careers()
        {
            // Sirf Open vacancies lao (IsFilled = false)
            var vacancies = _db.Vacancies
                .Where(v => v.IsFilled == false)
                .ToList();
            return View(vacancies);
        }

        public IActionResult Testimonials()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult SiteMap()
        {
            return View();
        }
    }
}