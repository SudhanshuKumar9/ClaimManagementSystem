using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class Policy
    {
    
        public int PolicyID { get; set; }
        public int PolicyNO { get; set; }
        public int BenefitId { get; set; }
        public double Premium { get; set; }
        public int Tenure { get; set; }

    }
}
