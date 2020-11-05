using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authorization.Models;
using Authorization.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IRepository _repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        public AuthController(IConfiguration config,IRepository repository)
        {
            _config = config;
            _repository = repository;
        }

        /// <summary>
        /// 1.Checking if username and password is valid
        /// 2.Generates jwt token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //https://localhost:44392/api/Auth/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginModel model)
        {

            try
            {
                _log4net.Info(nameof(Login) + " meyhod invoked");
                Member memberDetail;
                var jsonData = JsonConvert.SerializeObject(model);
                var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync("https://localhost:44355/api/Members/", encodedData);
                    var responseData = response.Result.Content.ReadAsStringAsync();
                    memberDetail = JsonConvert.DeserializeObject<Member>(responseData.Result);
                }
                if (memberDetail != null)
                {
                    var tokenString = _repository.GenerateJSONWebToken(memberDetail);
                    return Ok(tokenString);
                }

                return Unauthorized("Invalid Credentials");
            }
            catch(Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(Login) + "Error Message : " + e.Message);
                return BadRequest(e.Message);
            }
        }




        // this function will generate jwt token
        //private string GenerateJSONWebToken(Member memberDetail)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    List<Claim> claims = new List<Claim>() {
        //        new Claim(JwtRegisteredClaimNames.Sub, memberDetail.Username),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };
        //    var token = new JwtSecurityToken(
        //      _config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      claims,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}

