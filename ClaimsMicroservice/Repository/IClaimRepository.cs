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
    }
}
