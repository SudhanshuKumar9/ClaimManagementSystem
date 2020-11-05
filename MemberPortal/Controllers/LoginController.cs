using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MemberPortal.ViewModel;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.Net.Http.Headers;

namespace MemberPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]MemberLogin memberDetail)
        {
            string token = GetToken("https://localhost:44392/api/Auth/Login", memberDetail);

            if (token != null)
            {
                using (var client = new HttpClient())
                {
                    //var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    //client.DefaultRequestHeaders.Accept.Add(contentType);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.Clear();
            ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");
            return View("Index");
        }

      

        public string GetToken(string url, MemberLogin user)
        {
            var jsonData = JsonConvert.SerializeObject(user);
            var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = client.PostAsync(url, encodedData).Result;
            if(response.StatusCode==HttpStatusCode.OK)
            {
                string tokenString = response.Content.ReadAsStringAsync().Result;
                return tokenString;
            }
            return null;
            
        }

    }
}
