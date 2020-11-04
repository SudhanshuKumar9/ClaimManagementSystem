using ClaimsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
