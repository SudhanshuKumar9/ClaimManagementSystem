using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public class PolicyRepo : IPolicyRepo
    {
        
       
       public IEnumerable<ProviderPolicy> GetChainOfProviders(int policyId)
        {
            
            return PolicyData.providerpolicyList.Where(p => p.PolicyId == policyId).ToList();
           

        }

        public string GetEligibleBenefits(int policyId, int memberId)
        {
            var benefitId = PolicyData.memberpolicyList.Where(p => p.PolicyId == policyId && p.MemberId == memberId).FirstOrDefault();
            int id = benefitId.BenefitId;
            string benefitName = PolicyData.benefitList.FirstOrDefault(b => b.BenefitId == id).BenefitName;
            return benefitName;

        }

        public double GetEligibleClaimAmount(int policyId, int memberId, int benefitId)
            
        {
            double claimAmt = PolicyData.memberpolicyList.FirstOrDefault(p => p.PolicyId == policyId && p.MemberId == memberId && p.BenefitId==benefitId).CapAmountBenefits;
            return claimAmt;
        }



    }
}
