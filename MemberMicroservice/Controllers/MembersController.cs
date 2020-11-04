using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MemberMicroservice.Models;
using MemberMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public static List<Member> members = new List<Member>()
        {
            new Member()
            {
                MemberID = 101,
                MemberName = "John",
                MemberAddress1 = "412 Street",
                MemberAddress2 = "Victorious",
                MemberCity = "California",
                MemberPhone = 0124345454,
                Username = "john@123",
                Password = "Training@123"
            },
            new Member()
            {
                MemberID = 102,
                MemberName = "Jack",
                MemberAddress1 = "4432 main Street",
                MemberAddress2 = "George",
                MemberCity = "Paris",
                MemberPhone = 0432345242,
                Username = "jack432",
                Password = "mypass@123"
            }

        };


        [HttpGet("{PolicyID}/{MemberID}")]
        public async Task<ActionResult<MemberPremium>> viewBill(int PolicyID, int MemberID)
        {
            return Ok(_memberRepository.viewBill(PolicyID, MemberID));
        }

        [HttpGet]
        public async Task<ActionResult<string>> getClaimStatus([FromQuery]int ClaimID,[FromQuery] int PolicyID)
        {  
            return Ok(_memberRepository.getClaimStatus(ClaimID, PolicyID));
        }
    }

}