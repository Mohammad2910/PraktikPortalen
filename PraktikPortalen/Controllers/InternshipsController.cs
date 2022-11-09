using Microsoft.AspNetCore.Mvc;
using PraktikPortalen.Models;

namespace PraktikPortalen.Controllers
{
    public class InternshipsController : Controller
    {
        public IActionResult Internships()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            List<InternshipsModel> internships = null;
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:5287/api/internships/");
                var ResponseTask = client.GetAsync("");
                ResponseTask.Wait();
                var result = ResponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<InternshipsModel>>();
                    readTask.Wait();
                    internships = readTask.Result;
                }
                //else //web api sent error response 
                //{
                //    //log response status here..

                //    // student = (StudentModel?)Enumerable.Empty<StudentModel>();

                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }
            return View(internships);
        }
    }
}
