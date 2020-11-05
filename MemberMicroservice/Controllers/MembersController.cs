using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberMicroservice.Models;
using MemberMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MembersController));
        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// To get the viewBill Details
        /// </summary>
        /// <param name="ClaimID"></param>
        /// <param name="PolicyID"></param>
        /// <returns></returns>
        
        //https://localhost:44355/api/Members/viewBills?policyID=12345&memberID=101
        [HttpGet]
        [Route("viewBills")]
        public ActionResult<MemberPremium> ViewBill([FromQuery] int policyID, [FromQuery] int memberID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("ViewBills Accesed");
                    return Ok(_memberRepository.ViewBill(policyID, memberID));
                }
                else
                    _log4net.Info("Model is not valid in ViewBills");
                return BadRequest();

            }
            catch (Exception e)
            {
                _log4net.Error("Exception in ViewBills" + e.Message);
                return new NoContentResult();
            }
        }


        //https://localhost:44355/api/Members/
        [HttpPost]
        public ActionResult<Member> GetMemberDetail([FromBody] LoginModel model)
        {
            var member = _memberRepository.GetMember(model);

            return Ok(member);

        }

        /// <summary>
        /// To get the Claim Status
        /// </summary>
        /// <param name="ClaimID"></param>
        /// <param name="PolicyID"></param>
        /// <returns></returns>

        //https://localhost:44355/api/Members/getClaimStatus?claimID=1&policyID=1
        [HttpGet]
        [Route("getClaimStatus")]
        public async Task<ActionResult<string>> GetClaimStatus([FromQuery] int claimID, [FromQuery] int policyID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("GetClaimStatus Accesed");
                    return Ok(_memberRepository.GetClaimStatus(claimID, policyID));
                }
                else
                    _log4net.Info("Model is not valid in GetClaimStatus");
                return BadRequest();
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in GetClaimStatus" + e.Message);
                return new NoContentResult();
            }    
        }

        /// <summary>
        /// To post the New Claim Details
        /// </summary>
        /// <param name="PolicyID"></param>
        /// /// <param name="MemberID"></param>
        /// <param name="BenefitID"></param>
        /// <param name="HospitalID"></param>
        /// <param name="ClaimAmount"></param>
        /// <param name="Benefit"></param>
        /// <returns></returns>

        //https://localhost:44355/api/Members/submitClaim?policyID=1&memberID=1&benefitID=1&hospitalID=1&claimAmt=80000&benefit="MedicalCheckup"
        [HttpPost]
        [Route("submitClaim")]
        public async Task<ActionResult<string>> SubmitClaim([FromQuery] int policyID, [FromQuery] int memberID, [FromQuery] int benefitID, [FromQuery] int hospitalID, [FromQuery] double claimAmt, [FromQuery] string benefit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("SubmitClaim Accesed");
                    return Ok(_memberRepository.SubmitClaim(policyID, memberID, benefitID, hospitalID, claimAmt, benefit));
                }
                else
                    _log4net.Info("Inputs given are not valid");
                return BadRequest();
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in SubmitClaim" + e.Message);
                return new NoContentResult();
            }
        }
    }

}