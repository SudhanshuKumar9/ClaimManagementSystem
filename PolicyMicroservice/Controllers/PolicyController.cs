using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyMicroservice.Repository;

namespace PolicyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepo _policyRepository;
       static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        public PolicyController(IPolicyRepo policyRepository)
        {
            _policyRepository = policyRepository;
        }

        /// <summary>
        /// To get the List of Chain of Providers
        /// </summary>
        /// <param name="PolicyID"></param>
        /// <returns></returns>


        //https://localhost:44373/api/Policy/GetChainOfProviders/1
        [HttpGet("GetChainOfProviders/{PolicyID}")]
        public IActionResult GetChainOfProviders(int PolicyID)
        {
            try
            {
                 _log4net.Info("GetChainOfProviders Accesed");
                var providerlist = _policyRepository.GetChainOfProviders(PolicyID);
                return new OkObjectResult(providerlist);

            }
            catch(Exception e)
            {
               _log4net.Error("Error in GetChainOfProviders"+e.Message);
                return new NoContentResult();
            }
        }
        /// <summary>
        /// To Get the Benefits list
        /// </summary>
        /// <param name="PolicyID"></param>
        /// <param name="MemberID"></param>
        /// <returns></returns>

      // https://localhost:44373/api/Policy/GetEligibleBenefits?PolicyId=1&MemberID=1 
      [HttpGet("GetEligibleBenefits")]
    
        public IActionResult GetEligibleBenefit([FromQuery]int PolicyID,[FromQuery] int MemberID)
        {
            try
            {
                _log4net.Info("GetEligibleBenefit is accessed");
                var benefitslist = _policyRepository.GetEligibleBenefits(PolicyID, MemberID);
                return new OkObjectResult(benefitslist);

            }
            catch(Exception e)
            {
                 _log4net.Error("Error in GetEligibleBenefit"+e.Message);
                return new NoContentResult();
            }
        }

        /// <summary>
        /// To get the eligible Claim Amount
        /// </summary>
        /// <param name="PolicyId"></param>
        /// <param name="MemberID"></param>
        /// <param name="BenefitId"></param>
        /// <returns></returns>

        [HttpGet("GetEligibleClaimAmount")]
        public IActionResult GetEligibleClaimAmount([FromQuery]int PolicyId,[FromQuery] int MemberID,[FromQuery] int BenefitId)
        {
            try
            {
                _log4net.Info("GetEligibleClaimAmount is accesed");
                var amt = _policyRepository.GetEligibleClaimAmount(PolicyId, MemberID, BenefitId);
                return new OkObjectResult(amt);

            }
            catch(Exception e)
            {
                _log4net.Error("Error in GetEligibleClaimAmount"+e.Message);
                return new NoContentResult();

            }
        }


        
            
    }
}
