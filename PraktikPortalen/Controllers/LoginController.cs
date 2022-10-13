using Microsoft.AspNetCore.Mvc;
using PraktikPortalen.Models;

namespace PraktikPortalen.Controllers
{
    public class LoginController : Controller
    {
        public const bool authenticated = false;
        Student student = new Student("Hej");
        public IActionResult Login()
        {
            return View(student);
        }
    }
}
