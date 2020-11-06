
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
    /// <summary>
    /// Contributed By Anupam Bhattacharyya(848843)
    /// </summary>
    public class PolicyRepo : IPolicyRepo
    {
        /// <summary>
        /// Repository Method for returning chain of Providers
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns>List of Providers</returns>
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyRepo));
        public IEnumerable<ProviderPolicy> GetChainOfProviders(int policyId)
        {
            try
            {
                if (PolicyData.providerpolicyList.Where(p => p.PolicyId == policyId).ToList() == null)
                {
                    
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                }
                else
                {
                    _log4net.Info("Data Fetched for PolicyId :" + policyId);

                    return PolicyData.providerpolicyList.Where(p => p.PolicyId == policyId).ToList();

                }
            }
            catch (Exception e)
            {
                _log4net.Info("Data not found  in GetChainOfProviders while checking for PolicyId: " + policyId);
                return (IEnumerable<ProviderPolicy>)e.ToString().ToList(); ;

            }
        }
        /// <summary>
        /// Return the Benefits available Under each policy for each member
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="memberId"></param>
        /// <returns>Benefit Name</returns>

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
                    _log4net.Info("Data fetched in GetEligibleBenefit for the entered MemberId :" + memberId + " PolicyId :" + policyId);


                    int id = benefitId.BenefitId;
                    string benefitName = PolicyData.benefitList.FirstOrDefault(b => b.BenefitId == id).BenefitName;
                    return benefitName;
                }
            }
            catch (Exception)
            {
                _log4net.Info("Data not found in GetEligibleBenefit for the entered MemberId :" + memberId + " PolicyId :" + policyId);

                return "Invalid Data";
            }

        }


    /// <summary>
    /// Returns the Eligible Claim Amount for each policy,member and benefit
    /// </summary>
    /// <param name="policyId"></param>
    /// <param name="memberId"></param>
    /// <param name="benefitId"></param>
    /// <returns>Eligible claim Amount</returns>

    public double GetEligibleClaimAmount(int policyId, int memberId, int benefitId)
            
        {
            try
            {
                if (PolicyData.memberpolicyList.FirstOrDefault(p => p.PolicyId == policyId && p.MemberId == memberId && p.BenefitId == benefitId) == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    _log4net.Info("Data fetched for GetEligibleAmount for the entered PolicyId :" + policyId + " MemberId :" + memberId + " BenefitId :" + benefitId);
                    double claimAmt = PolicyData.memberpolicyList.FirstOrDefault(p => p.PolicyId == policyId && p.MemberId == memberId && p.BenefitId == benefitId).CapAmountBenefits;
                    return claimAmt;
                }
            }
            catch(Exception)
            {
                _log4net.Info("Data not found for GetEligibleClaimAmount for the entered PolicyId :" + policyId + " MemberId :" + memberId + " BenefitId :" + benefitId);
                double errorValue = -1;
                return errorValue;

            }


        }



    }
}
