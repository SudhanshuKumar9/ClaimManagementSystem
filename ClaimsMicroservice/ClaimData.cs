using ClaimsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsMicroservice
{
    public class ClaimData
    {
        public static List<Claim> claims = new List<Claim>()
        {
            new Claim()
            {
                ClaimID = 1,
                ClaimStatus = "Pending",
                PolicyID = 1,
                AmountClaimed = 12300,
                BenefitsAvailed = "Medicine & Checkup",
                HospitalID = 1,
                Remarks = "Verified",
                Settled = "False"
            },
            new Claim()
            {
                ClaimID = 2,
                ClaimStatus = "Rejected",
                PolicyID = 1,
                AmountClaimed = 12300,
                BenefitsAvailed = "Medicine & Checkup",
                HospitalID = 1,
                Remarks = "Verified",
                Settled = "False"
            },
            new Claim()
            {
                ClaimID = 3,
                ClaimStatus = "Invalid Details",
                PolicyID = 3,
                AmountClaimed = 12300,
                BenefitsAvailed = "Medicine & Checkup",
                HospitalID = 1,
                Remarks = "Verified",
                Settled = "False"
            }
        };
    }
}
