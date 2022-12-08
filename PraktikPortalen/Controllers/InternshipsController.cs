using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PraktikPortalen.Models;

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
    }
}
