using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PraktikPortalen.Models;
using System.Net;

namespace PraktikPortalen.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly ISession session;
        private UserModel user;

        public InternshipsController(IHttpContextAccessor context)
        {
            this.session = context.HttpContext.Session;
            this.user = JsonConvert.DeserializeObject<UserModel>(session.GetString("User"));
        }
        public IActionResult Internships()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            List<InternshipsModel> internships = null;
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:5287/api/internships/");
                var ResponseTask = client.GetAsync(user.id.ToString());
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

        public IActionResult New(InternshipsModel internship)
        {
            System.Diagnostics.Debug.WriteLine(internship.InternshipName);
            System.Diagnostics.Debug.WriteLine(internship.InternshipCompany);
            internship.Status = "submitted";
            internship.user_id = user.id;
            System.Diagnostics.Debug.WriteLine(internship.Status);
            System.Diagnostics.Debug.WriteLine(internship.user_id);
            System.Diagnostics.Debug.WriteLine(internship.DTUSupervisor_id.ToString());
            System.Diagnostics.Debug.WriteLine(internship.CompanySupervisor_id.ToString());
            System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!");
            if (!string.IsNullOrEmpty(internship.InternshipName) && !string.IsNullOrEmpty(internship.DTUSupervisor_id.ToString()))
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:5287/api/internships");
                    var postTask = client.PostAsJsonAsync<InternshipsModel>("", internship);
                    postTask.Wait();
                    var result = postTask.Result;
                    System.Diagnostics.Debug.WriteLine(result.StatusCode);
                    if (result.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine("SUCCEEEEESSS!!!!!!!!!!!!!!!!!!");
                        // var readTask = result.Content.ReadAsAsync<Intern>();
                        // session.SetString("User", JsonConvert.SerializeObject(readTask.Result));
                        return RedirectToAction("Internships");
                    }
                }
            }

            return View();
        }
    }
}
