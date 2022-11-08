using Microsoft.AspNetCore.Mvc;
using PraktikPortalen.Models;


namespace PraktikPortalen.Controllers
{
    public class StudentTestController : Controller
    {
        public IActionResult Index()
        {
            //IEnumerable<Student> students = null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:7270/api/");
               
            //    // GET
            //    var responseTask = client.GetAsync("student");
            //    responseTask.Wait();

            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<Student>>();
            //        readTask.Wait();

            //        students = readTask.Result;
            //    }
            //    else //web api sent error response 
            //    {
            //        //log response status here..

            //        students = Enumerable.Empty<Student>();

            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    }
            //}
            
            return View();
        }
    }
}
