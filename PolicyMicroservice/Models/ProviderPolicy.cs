using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    /// <summary>
    /// Contributed By Anupam Bhattacharyya(848843)
    /// </summary>
    public class ProviderPolicy
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public int PolicyId { get; set; }
        public string Location { get; set; }
        
    }
}
