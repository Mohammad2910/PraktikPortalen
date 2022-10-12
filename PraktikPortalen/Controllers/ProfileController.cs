using Microsoft.AspNetCore.Mvc;

namespace PraktikPortalen.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
