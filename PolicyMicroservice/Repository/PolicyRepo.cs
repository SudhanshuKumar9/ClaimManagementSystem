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

            try
            {
                var benefitId = PolicyData.memberpolicyList.Where(p => p.PolicyId == policyId && p.MemberId == memberId).FirstOrDefault();
                if (benefitId == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {

                    int id = benefitId.BenefitId;
                    string benefitName = PolicyData.benefitList.FirstOrDefault(b => b.BenefitId == id).BenefitName;
                    return benefitName;
                }
            }
            catch (Exception e)
            {
                return "Invalid";
            }

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
                return 0.00;
            }
            else
            {
                double claimAmt = PolicyData.memberpolicyList.FirstOrDefault(p => p.PolicyId == policyId && p.MemberId == memberId && p.BenefitId == benefitId).CapAmountBenefits;
                return claimAmt;
            }
           
           
        }



    }
}
