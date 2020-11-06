using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice
{
    public class PolicyData
    {
        public static List<Policy> policyList = new List<Policy>
        {
            new Policy{PolicyId=1,PolicyNo=101,Premium=50000.00,Tenure=3,BenefitId=1},
            new Policy{PolicyId=2,PolicyNo=102,Premium=20000.00,Tenure=5,BenefitId=1},
            new Policy{PolicyId=3,PolicyNo=103,Premium=20000.00,Tenure=5,BenefitId=1}

        };
        public static List<MemberPolicy> memberpolicyList = new List<MemberPolicy>
        { 
           new MemberPolicy{MemberId=1,PolicyId=1,PolicyNo=101,BenefitId=1,Tenure=3,SubscriptionDate=new DateTime(2020, 03, 15),CapAmountBenefits=100000.00},
           new MemberPolicy{MemberId=2,PolicyId=1,PolicyNo=101,BenefitId=1,Tenure=3,SubscriptionDate=new DateTime(2019, 04, 18),CapAmountBenefits=120000.00},
           new MemberPolicy{MemberId=3,PolicyId=2,PolicyNo=102,BenefitId=1,Tenure=5,SubscriptionDate=new DateTime(2019, 05, 10),CapAmountBenefits=80000.00}
        };

        public static List<ProviderPolicy> providerpolicyList = new List<ProviderPolicy>
        {
            new ProviderPolicy{HospitalId=1,HospitalName="Apollo Hospital",HospitalAddress="Beleghata Road",Location="Kolkata",PolicyId=1},
            new ProviderPolicy{HospitalId=2,HospitalName="Mission Hospital",HospitalAddress="Bidhan Nagar",Location="Durgapur",PolicyId=1},
            new ProviderPolicy{HospitalId=3,HospitalName="AMRI Hospital",HospitalAddress="Salt Lake",Location="Kolkata",PolicyId=2}
        };
        public static List<Benefits> benefitList = new List<Benefits>
        {
            new Benefits{BenefitId=1,BenefitName="MedicalCheckup"},
            new Benefits{BenefitId=2,BenefitName="Accidental"}
        };

    }
}
