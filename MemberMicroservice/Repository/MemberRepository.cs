using MemberMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MemberMicroservice.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberPremium ViewBill( int policyID, int memberID)
        {
            MemberPremium member = (from p in MemberData.premiumDetails where (p.MemberID == memberID && p.PolicyID == policyID) select p).FirstOrDefault();
            return member;
        }

        public Member GetMember(LoginModel model)
        {
            return MemberData.members.Where(m => m.Username == model.Username && m.Password == model.Password).FirstOrDefault();
        }

        public string GetClaimStatus(int claimID, int policyID)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Claims?claimID=" + claimID + "&policyID=" + policyID).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                return stringData;
            }
        }

        public string SubmitClaim(int policyID, int memberID, int benefitID, int hospitalID, double claimAmt, string benefit)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Claims/SubmitClaim?policyID=" + policyID+"&memberID="+memberID+"&benefitID="+benefitID+"&hospitalID="+hospitalID+"&claimAmt="+claimAmt+"&benefit="+benefit).Result;
                string claimStatus = response.Content.ReadAsStringAsync().Result;
                return claimStatus;
            }
        }
    }
}
