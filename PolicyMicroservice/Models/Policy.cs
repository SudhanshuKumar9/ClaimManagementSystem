using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    /// <summary>
    /// Contributed By Anupam Bhattacharyya(848843)
    /// </summary>
    public class Policy
    {
    
        public int PolicyId { get; set; }
        public int PolicyNo { get; set; }
        public int BenefitId { get; set; }
        public double Premium { get; set; }
        public int Tenure { get; set; }

    }
}
