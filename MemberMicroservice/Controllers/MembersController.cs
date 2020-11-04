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
        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //https://localhost:44355/api/Members/viewBills/12345/101
        [HttpGet("viewBills/{PolicyID}/{MemberID}")]
        public ActionResult<MemberPremium> ViewBill(int PolicyID, int MemberID)
        {
            return Ok(_memberRepository.ViewBill(PolicyID, MemberID));
        }


        //https://localhost:44355/api/Members/
        [HttpPost]
        public ActionResult<Member> GetMemberDetail([FromBody] LoginModel model)
        {
            var member = _memberRepository.GetMember(model);

            return Ok(member);

        }

    }

}