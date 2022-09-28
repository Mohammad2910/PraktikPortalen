using Microsoft.AspNetCore.Mvc;

namespace PraktikPortalen.Controllers
{
    public class InternshipsController : Controller
    {
        public IActionResult Internships()
        {
            return View();
        }
    }
}
