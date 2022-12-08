using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using PraktikPortalen.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace PraktikPortalen.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ISession session;
        UserModel? user = null;

        public ProfileController(IHttpContextAccessor context)
        {
            this.session = context.HttpContext.Session;
            user = JsonConvert.DeserializeObject<UserModel>(this.session.GetString("User"));
        }

        public IActionResult Profile()
        {
            // JsonConvert.DeserializeObject<StudentModel>(context.HttpContext.Session.GetString("Student")).username
            /*HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:5287/api/users/");
                var ResponseTask = client.GetAsync("1");
                ResponseTask.Wait();
                var result = ResponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserModel>();
                    readTask.Wait();
                    user = readTask.Result;
                    return View(user);
                }
                //else //web api sent error response 
                //{
                //    //log response status here..

                //    // student = (StudentModel?)Enumerable.Empty<StudentModel>();

                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }*/
            return View(user);
        }

        
        public IActionResult SaveUser(UserModel sm)
        {
            sm.id = user.id;
            sm.type = user.type;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:5287/api/users");
                var postTask = client.PostAsJsonAsync<UserModel>("", sm);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserModel>();
                    session.SetString("User", JsonConvert.SerializeObject(readTask.Result));
                    return RedirectToAction("Profile");
                }
            }

            return View(user);
        }
    }
}
