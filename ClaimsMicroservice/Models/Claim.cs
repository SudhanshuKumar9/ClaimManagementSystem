using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsMicroservice.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string ClaimStatus { get; set; }
        public string Remarks { get; set; }
        public int PolicyID { get; set; }
        public string HospitalID { get; set; }
        public string BenefitsAvailed { get; set; }
        public Decimal AmountClaimed { get; set; }
        public string Settled { get; set; }

    }
}
