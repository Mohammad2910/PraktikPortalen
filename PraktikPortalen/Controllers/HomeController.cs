using Microsoft.AspNetCore.Mvc;
using PraktikPortalen.Models;
using System.Diagnostics;

namespace PraktikPortalen.Controllers
{
    public class HomeController : Controller
    {
        public const Boolean notAuthenticated = false;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //IEnumerable<ProductModel> products = null;
            //using (var client = new HttpClient(clientHandler))
            //{
            //    client.BaseAddress = new Uri("https://localhost:5287/api/ShoppingApi/");
            //    var ResponseTask = client.GetAsync("GetProducts");
            //    ResponseTask.Wait();
            //    var result = ResponseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<ProductModel>>();
            //        readTask.Wait();
            //        products = readTask.Result;
            //    }
            //    else //web api sent error response 
            //    {
            //        //log response status here..

            //        products = Enumerable.Empty<ProductModel>();

            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    }
            //}
                return View();
        }

        public static string getWelcomeMessage()
        {
            return "Hej, velkommen til praktikportalen";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}