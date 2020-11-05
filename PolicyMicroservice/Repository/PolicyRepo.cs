using Microsoft.AspNetCore.Mvc;
using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

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
            //if (item == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //return item;
            
            if(PolicyData.memberpolicyList.FirstOrDefault(p => p.PolicyId == policyId && p.MemberId == memberId && p.BenefitId == benefitId)==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                double claimAmt = PolicyData.memberpolicyList.FirstOrDefault(p => p.PolicyId == policyId && p.MemberId == memberId && p.BenefitId == benefitId).CapAmountBenefits;
                return claimAmt;
            }
           
           
        }



    }
}
