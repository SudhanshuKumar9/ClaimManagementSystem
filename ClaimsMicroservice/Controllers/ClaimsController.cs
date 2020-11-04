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


        [HttpGet]
        public async Task<ActionResult<string>> GetClaimStatus([FromQuery]int claimID, [FromQuery]int policyID)
        {
            _log4net.Info("GetClaimStatus Method Called");
            return Ok(_claimRepository.GetClaimStatus(claimID, policyID));
        }

    }
}
