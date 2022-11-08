using Microsoft.AspNetCore.Mvc;
using PraktikPortalen.Models;

namespace PraktikPortalen.Controllers
{
    public class LoginController : Controller
    {
        public const bool authenticated = false;
        

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult _Layout()
        {
            return View();
        }
    }
}
