using ClaimsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsMicroservice.Repository
{
    public interface IClaimRepository
    {
        public string GetClaimStatus(int claimID, int policyID);
        public Task<string> SubmitClaim(int policyID, int memberID, int benefitID, int hospitalID, double claimAmt, string benefits);
        
    }
}
