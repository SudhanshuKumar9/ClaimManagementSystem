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
        [HttpGet]
        [Route("GetChainOfProviders/{PolicyID}")]
        public IActionResult GetChainOfProviders(int policyId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("GetChainOfProviders Accesed");
                    var providerlist = _policyRepository.GetChainOfProviders(policyId);

                    return new OkObjectResult(providerlist);
                }
                else
                    _log4net.Info("Model is not valid in GetChainOfProviders");
                    return BadRequest();

            }
            catch(Exception e)
            {
               _log4net.Error("Exception in GetChainOfProviders"+e.Message);
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
      [HttpGet]
      [Route("GetEligibleBenefits")]
    
        public IActionResult GetEligibleBenefit([FromQuery]int policyId,[FromQuery] int memberId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("GetEligibleBenefit is accessed");
                    var benefitslist = _policyRepository.GetEligibleBenefits(policyId, memberId);
                    return new OkObjectResult(benefitslist);
                }
                else
                {
                    _log4net.Info("Model is not valid in GetEligibleBenefit");
                    return BadRequest();
                }

            }
            catch(Exception e)
            {
                 _log4net.Error("Exception in GetEligibleBenefit"+e.Message);
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
        /// 
        //https://localhost:44373/api/Policy/GetEligibleClaimAmount?PolicyId=1&MemberID=1&BenefitId=1
        [HttpGet]
        [Route("GetEligibleClaimAmount")]
        public IActionResult GetEligibleClaimAmount([FromQuery]int policyId,[FromQuery] int memberId,[FromQuery] int benefitId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("GetEligibleClaimAmount is accesed");
                    var amt = _policyRepository.GetEligibleClaimAmount(policyId, memberId, benefitId);
                    return new OkObjectResult(amt);
                }
                else
                    _log4net.Info("ModelState is not valid for GetEligibleAmount");
                    return BadRequest();

            }
            catch(Exception e)
            {
                _log4net.Error("Exception in GetEligibleClaimAmount"+e.Message);
                return new NoContentResult();

            }
        }


        
            
    }
}
