using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MemberPortal.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MemberMicroservice.Models;
using System.Text;

namespace MemberPortal.Controllers
{


    public class HomeController : Controller
    {


        private static int count = 1;
        private static MockDatabase _data=new MockDatabase();
        private readonly MockDbContext _context;
       
        public HomeController(MockDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if(CheckStatus())
            {
                ViewBag.UserName = HttpContext.Session.GetString("Username");
                return View();
            }
                
            return RedirectToAction("Index", "Login");
        }


        private bool CheckStatus()
        {
            if (HttpContext.Session.GetString("Username") != null)
                return true;
            return false;
        }

        public IActionResult ViewBill()
        {
            if(CheckStatus())
            {
                if (_data.PolicyID != 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = new HttpResponseMessage();
                        response = client.GetAsync("https://localhost:44355/api/Members/viewBills?policyID=" + _data.PolicyID + "&memberID=" + _data.MemberID).Result;
                        var data = JsonConvert.DeserializeObject<MemberPremium>(response.Content.ReadAsStringAsync().Result);

                        return View(data);
                    }
                }
                return View();
            }
            return RedirectToAction("Index", "Login");
           
        }

        public IActionResult SubmitClaim()
        {
            if (CheckStatus())
            {
                return View();
            }
            return RedirectToAction("Index", "Login");

        }


        public IActionResult ClaimStatus()
        {
            if(CheckStatus())
            {
                return View();
            }
            return RedirectToAction("Index", "Login");

        }

        [HttpPost]
        public IActionResult SubmitStatus([FromForm] MockDatabase data)
        {
          
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = client.GetAsync("https://localhost:44355/api/Members/getClaimStatus?claimID=" + data.ClaimID + "&policyID=" + data.PolicyID).Result;
                    var responseData = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    ViewBag.Status = responseData;
                    return View("Status");
                }
        }

        [HttpPost]
        public IActionResult SaveClaim([FromForm]MockDatabase data)
        {
            try
            {
                _data.TransactionID = Guid.NewGuid();
                _data.BenefitID = data.BenefitID;
                _data.PolicyID = data.PolicyID;
                _data.MemberID = data.MemberID;
                _data.BenefitName = data.BenefitName;
                _data.ClaimID = count++;
                _data.ClaimAmount = data.ClaimAmount;
                _data.HospitalId = data.HospitalId;
                _context.MockDatabases.Add(_data);
                _context.SaveChanges();



                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
                    response = client.PostAsync("https://localhost:44355/api/Members/submitClaim?policyID=" + data.PolicyID + "&memberID=" + data.MemberID + "&benefitID=" + data.BenefitID + "&hospitalID=" + data.HospitalId + "&claimAmt=" + data.ClaimAmount + "&benefit=\"" + data.BenefitName + "\"", content).Result;
                    var responseData = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    ViewBag.Status = responseData;
                    return View("Status");
                }
            }
            catch(Exception e)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Some internal error occured : "+e.Message);
                return View("SubmitClaim");
            }
           
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        

       
    }
}
