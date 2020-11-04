using ClaimsMicroservice.Models;
using log4net.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClaimsMicroservice.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        public static List<Claim> claims = new List<Claim>()
        {
            new Claim()
            {
                ClaimID = 1,
                ClaimStatus = "Pending",
                PolicyID = 12345,
                AmountClaimed = 12300,
                BenefitsAvailed = "Medicine & Checkup",
                HospitalID = "Amravati Hospital",
                Remarks = "Verified",
                Settled = "False"
            },
            new Claim()
            {
                ClaimID = 2,
                ClaimStatus = "Rejected",
                PolicyID = 54321,
                AmountClaimed = 12300,
                BenefitsAvailed = "Medicine & Checkup",
                HospitalID = "Amravati Hospital",
                Remarks = "Verified",
                Settled = "False"
            },
            new Claim()
            {
                ClaimID = 3,
                ClaimStatus = "Invalid Details",
                PolicyID = 23456,
                AmountClaimed = 12300,
                BenefitsAvailed = "Medicine & Checkup",
                HospitalID = "Amravati Hospital",
                Remarks = "Verified",
                Settled = "False"
            }

        };
        public string GetClaimStatus(int claimID, int policyID)
        {
            string filterClaim = (from p in claims
                                  where (p.ClaimID == claimID && p.PolicyID == policyID)
                                  select p.ClaimStatus).FirstOrDefault();
            return filterClaim;
        }

        public async Task<string> submitClaim(int policyID, int memberID, int benefitID, int hospitalID, double claimAmt, string benefit)
        {
            string status="";
            ProviderPolicy providerPolicy = new ProviderPolicy();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44373/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = new HttpResponseMessage();
                response1 = client.GetAsync("Policy/GetEligibleClaimAmount?PolicyID=" + policyID + "&MemberID=" + memberID + "&BenefitID=" + benefitID).Result;
                double claimAmount = Convert.ToDouble(response1.Content.ReadAsStringAsync().Result);
                HttpResponseMessage response2 = new HttpResponseMessage();
                response2 = client.GetAsync("Policy/GetEligibleBenefits?PolicyID=" + policyID + "&MemberID=" + memberID).Result;
                string Benefit = response2.Content.ReadAsStringAsync().Result;
                HttpResponseMessage response3 = new HttpResponseMessage();
                response3 = client.GetAsync("Policy/GetChainOfProviders/" + policyID).Result;
                List<ProviderPolicy> providers = new List<ProviderPolicy>();
                List<int> HospitalID = new List<int>();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                string apiResponse = await response3.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ProviderPolicy>>(apiResponse);

                Boolean flag = false;
                foreach (var x in data)
                {
                    if (x.HospitalID == hospitalID)
                    {
                        flag = true;
                    }
                }

                if ((claimAmount >= claimAmt) && (Benefit.Equals(benefit)) && (flag==true))
                {
                    status = "Pending Action";
                }
                else
                {
                    status = "Claim Rejected";
                }
            }
            return status;
        }
    }
}
