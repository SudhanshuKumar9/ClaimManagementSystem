using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsMicroservice.Models;
using ClaimsMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ClaimsController));

        private readonly IClaimRepository _claimRepository;
        public ClaimsController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }


        [HttpGet("GetClaimStatus")]
        public async Task<ActionResult<string>> GetClaimStatus([FromQuery] int claimID, [FromQuery] int policyID)
        {
            _log4net.Info("GetClaimStatus Method Called");
            return Ok(_claimRepository.GetClaimStatus(claimID, policyID));
        }

        [HttpGet("SubmitClaim")]
        public async Task<ActionResult<string>> SubmitClaim([FromQuery] int policyID, [FromQuery] int memberID, [FromQuery] int benefitID, [FromQuery] int hospitalID, [FromQuery] double claimAmt, [FromQuery] string benefit)
        {
            _log4net.Info("SubmitClaim Method Called");
            return Ok(_claimRepository.submitClaim(policyID, memberID, benefitID, hospitalID, claimAmt, benefit).Result);
        }
    }
}
