using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    /// <summary>
    /// Contributed By Anupam Bhattacharyya(848843)
    /// </summary>
    public class MemberPolicy
    {
        
        public int MemberId { get; set; }
        public int PolicyId { get; set; }
        public int PolicyNo { get; set; }
        public int BenefitId { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public int Tenure { get; set; }
        public double CapAmountBenefits { get; set; }
    }
}
