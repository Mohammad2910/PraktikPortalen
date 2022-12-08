using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PraktikPortalen.Models;
using System.Diagnostics;

namespace PraktikPortalen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;
        UserModel? user = null;

        public HomeController(IHttpContextAccessor context)
        {
            this.session = context.HttpContext.Session;
        }

        public IActionResult Index()
        {

            user = JsonConvert.DeserializeObject<UserModel>(session.GetString("User"));
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}