using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public class PolicyRepo : IPolicyRepo
    {
        private List<Policy> policyList = new List<Policy>
        { new Policy{PolicyID=1,PolicyNO=101,Premium=50000.00,Tenure=3,BenefitId=1},
            new Policy{PolicyID=2,PolicyNO=102,Premium=20000.00,Tenure=5,BenefitId=1},
            new Policy{PolicyID=3,PolicyNO=103,Premium=80000.00,Tenure=7,BenefitId=2}


        };
        private List<MemberPolicy> memberpolicyList = new List<MemberPolicy>
        { new MemberPolicy{MemberID=1,PolicyID=1,PolicyNO=101,BenefitID=1,Tenure=3,SubscriptionDate=DateTime.Parse("15-03-2020"),CapAmountBenefits=100000.00},
           new MemberPolicy{MemberID=2,PolicyID=1,PolicyNO=101,BenefitID=1,Tenure=3,SubscriptionDate=DateTime.Parse("18-04-2019"),CapAmountBenefits=120000.00},
           new MemberPolicy{MemberID=3,PolicyID=2,PolicyNO=102,BenefitID=1,Tenure=5,SubscriptionDate=DateTime.Parse("10-05-2019"),CapAmountBenefits=80000.00}
        };

        private List<ProviderPolicy> providerpolicyList = new List<ProviderPolicy>
        {
            new ProviderPolicy{HospitalID=1,HospitalName="Apollo Hospital",HospitalAddress="Beleghata Road",Location="Kolkata",PolicyID=1},
            new ProviderPolicy{HospitalID=2,HospitalName="Mission Hospital",HospitalAddress="Bidhan Nagar",Location="Durgapur",PolicyID=1},
            new ProviderPolicy{HospitalID=3,HospitalName="AMRI Hospital",HospitalAddress="Salt Lake",Location="Kolkata",PolicyID=2}
        };
        private List<Benefits> benefitlist = new List<Benefits>
        {
            new Benefits{BenefitID=1,BenefitName="Medical Checkup"},
            new Benefits{BenefitID=2,BenefitName="Accidental benefit"}

        };

      

        public IEnumerable<ProviderPolicy> GetChainOfProviders(int PolicyID)
        {
            // return bookingDbContext.Bookings.Where(b => b.UserId == userid).ToList<Booking>();
            return providerpolicyList.Where(p => p.PolicyID == PolicyID).ToList();

        }

        public List<String> GetEligibleBenefits(int PolicyID, int MemberID)
        {
            List<String> _benefitlist = new List<string>();
            var benefitid = memberpolicyList.Where(p => p.PolicyID == PolicyID && p.MemberID == MemberID).FirstOrDefault();
            int id = benefitid.BenefitID;
            string benefitname = benefitlist.FirstOrDefault(b => b.BenefitID == id).BenefitName;
            _benefitlist.Add(benefitname);
            return _benefitlist.ToList();

        }

        public double GetEligibleClaimAmount(int PolicyID, int MemberID, int BenefitID)
            
        {
            double claimamt = memberpolicyList.FirstOrDefault(p => p.PolicyID == PolicyID && p.MemberID == MemberID).CapAmountBenefits;
          //  double claimedamt=Double.Parse(memberpolicyList.Where(p => p.PolicyID == PolicyID && p.MemberID == MemberID && p.BenefitID==BenefitID).Select(m=>m.CapAmountBenefits).ToString());
            return claimamt;
        }



    }
}
