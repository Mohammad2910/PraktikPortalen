using Microsoft.AspNetCore.Mvc;
using PraktikPortalen.Models;
using System.Collections.Generic;

namespace PraktikPortalen.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            StudentModel student = null;
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:5287/api/students/");
                var ResponseTask = client.GetAsync("1");
                ResponseTask.Wait();
                var result = ResponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StudentModel>();
                    readTask.Wait();
                    student = readTask.Result;
                    return View(student);
                }
                //else //web api sent error response 
                //{
                //    //log response status here..

                //    // student = (StudentModel?)Enumerable.Empty<StudentModel>();

                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }
            return View();
        }
    }
}
