using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public interface IPolicyRepo
    {
        public IEnumerable<ProviderPolicy> GetChainOfProviders(int PolicyNO);
       public List<String> GetEligibleBenefits(int PolicyID,int MemberID);
        public double GetEligibleClaimAmount(int PolicyID, int MemberID, int BenefitID);
    }
}
