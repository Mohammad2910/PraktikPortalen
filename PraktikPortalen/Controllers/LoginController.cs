using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PraktikPortalen.Models;
using System.Net;

namespace PraktikPortalen.Controllers
{

    public class LoginController : Controller
    {
        // private readonly IHttpContextAccessor context;
        // static int statusCode;
        private readonly ISession session;

        public LoginController(IHttpContextAccessor context)
        {
            // this.context = context;
            this.session = context.HttpContext.Session;
            this.session.SetInt32("statusCode", 0);
        }

        public IActionResult Login(Credentials credentials)
        {
            UserModel? user = null;
            string? token = null;

            session.Clear();

            if (!string.IsNullOrEmpty(credentials.username) && !string.IsNullOrEmpty(credentials.password))
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:5287/api/authenticate");
                    var postTask = client.PostAsJsonAsync<Credentials>("", credentials);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = postTask.Result.Content.ReadAsAsync<LoginTokenModel>();

                        user = readTask.Result.user;
                        token = readTask.Result.Token;
                        
                        session.SetString("Token", token);
                        session.SetString("User", JsonConvert.SerializeObject(user));

                        return RedirectToAction("Index", "Home");
                    }
                    else if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        session.SetInt32("statusCode", 401);
                    }
                }
            } else
            {
                session.SetInt32("statusCode", 0);
            }
            return View();
        }

        public IActionResult _Layout()
        {
            return View();
        }
    }
}
