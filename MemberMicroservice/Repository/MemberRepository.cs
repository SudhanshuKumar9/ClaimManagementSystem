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
        public static List<Member> members = new List<Member>()
        {
            new Member()
            {
                MemberID = 101,
                MemberName = "John",
                MemberAddress1 = "412 Street",
                MemberAddress2 = "Victorious",
                MemberCity = "California",
                MemberPhone = 0124345454,
                Username = "john@123",
                Password = "Training@123"
            },
            new Member()
            {
                MemberID = 102,
                MemberName = "Jack",
                MemberAddress1 = "4432 main Street",
                MemberAddress2 = "George",
                MemberCity = "Paris",
                MemberPhone = 0432345242,
                Username = "jack432",
                Password = "mypass@123"
            }

        };
        public static List<MemberPremium> premiumDetails = new List<MemberPremium>()
        {
            new MemberPremium()
            {
                MemberID = 101,
                PolicyID = 12345,
                PremiumDue = 43242.0,
                PaymentDetails = "UPI Mode",
                DueDate = new DateTime(2020, 12, 20),
                LastPremiumPaidDate = new DateTime(2019, 12, 21)
            },
            new MemberPremium()
            {
                MemberID = 102,
                PolicyID = 54321,
                PremiumDue = 54342.0,
                PaymentDetails = "Cheque Mode",
                DueDate = new DateTime(2021, 04, 16),
                LastPremiumPaidDate = new DateTime(2020, 04, 22)
            }

        };
        public MemberPremium ViewBill( int PolicyID, int MemberID)
        {
            MemberPremium member = (from p in premiumDetails where (p.MemberID == MemberID && p.PolicyID == PolicyID) select p).FirstOrDefault();
            return member;
        }

        public Member GetMember(LoginModel model)
        {
            return members.Where(m => m.Username == model.Username && m.Password == model.Password).FirstOrDefault();
        }

        public string GetClaimStatus(int ClaimID, int PolicyID)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44387/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Claims?claimID=" + ClaimID + "&policyID=" + PolicyID).Result;
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
                response = client.GetAsync("Claims?policyID="+policyID+"&memberID="+memberID+"&benefitID="+benefitID+"&hospitalID="+hospitalID+"&claimAmt="+claimAmt+"&benefit="+benefit).Result;
                string claimStatus = response.Content.ReadAsStringAsync().Result;
                return claimStatus;
            }
        }
    }
}
