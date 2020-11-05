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
       
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            
            return View();
        }



        public IActionResult ViewBill()
        {
            if (_data.PolicyID != 0)
            {
                using(var client=new HttpClient())
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

        public IActionResult SubmitClaim()
        {
            return View();
        }


        public IActionResult ClaimStatus()
        {
            return View();
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
            
            _data.BenefitID = data.BenefitID;
            _data.PolicyID = data.PolicyID;
            _data.MemberID = data.MemberID;
            _data.BenefitName = data.BenefitName;
            _data.ClaimID = count++;
            _data.ClaimAmount = data.ClaimAmount;
            _data.HospitalId = data.HospitalId;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
                response = client.PostAsync("https://localhost:44355/api/Members/submitClaim?policyID=" + data.PolicyID + "&memberID=" + data.MemberID + "&benefitID=" + data.BenefitID + "&hospitalID=" + data.HospitalId + "&claimAmt=" +data.ClaimAmount+"&benefit=\""+data.BenefitName+"\"",content).Result;
                var responseData = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                ViewBag.Status = responseData;
                return View("Status");
            }
        }

        

       
    }
}
