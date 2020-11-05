using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    /// <summary>
    /// Contributed By Anupam Bhattacharyya(848843)
    /// </summary>
    public interface IPolicyRepo
    {
        public IEnumerable<ProviderPolicy> GetChainOfProviders(int policyNo);
        public string GetEligibleBenefits(int policyId,int memberId);
        public double GetEligibleClaimAmount(int policyId, int memberId, int benefitId);
    }
}
