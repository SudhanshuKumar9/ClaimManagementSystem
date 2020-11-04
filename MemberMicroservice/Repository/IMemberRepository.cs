using MemberMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberMicroservice.Repository
{
    public interface IMemberRepository
    {
        public MemberPremium ViewBill(int PolicyID,  int MemberID);
        Member GetMember(LoginModel model);
        public string GetClaimStatus(int ClaimID, int PolicyID);
        public string SubmitClaim(int policyID, int memberID, int benefitID, int hospitalID, double claimAmt, string benefit);
    }
}
