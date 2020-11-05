using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberPortal.Models
{
    public class MockDatabase
    {

        [Range(1,2)]
        public int MemberID { get; set; }

        [Range(1,3)]
        public int PolicyID { get; set; }

        [Range(1,3)]
        public int ClaimID { get; set; }

        [Range(1,2)]
        public int BenefitID { get; set; }

        [Range(1,2)]
        public int HospitalId { get; set; }



        public double ClaimAmount { get; set; }

        public string BenefitName { get; set; }

       

    }
}
