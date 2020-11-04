using MemberMicroservice.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberMicroservice.Repository
{
    public interface IMemberRepository
    {
        public MemberPremium viewBill(int PolicyID, int MemberID);
        public string getClaimStatus(int ClaimID, int PolicyID);
      }
}
