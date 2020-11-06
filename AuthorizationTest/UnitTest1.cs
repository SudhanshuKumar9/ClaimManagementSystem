using NUnit.Framework;
using Authorization.Controllers;
using Authorization.Models;
using Authorization.Repository;
using System.Collections.Generic;
using Moq;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace AuthorizationTest
{
    public class Tests
    {
        List<Member> loginDetails;
        Mock<IRepository> mockSet;
        Mock<IConfiguration> config;

       [SetUp]
        public void Setup()
        {
            loginDetails= new List<Member>
            {
                new Member{MemberID=1,MemberName="John",MemberPhone=91999999,MemberCity="Kolkata",MemberAddress1="WB",MemberAddress2="Kol",Username="hell",Password="hell"},

            };
            mockSet = new Mock<IRepository>();
            config = new Mock<IConfiguration>();


        }


        [Test]
        public void GenerateJSONWebToken_ValidMember_ReturnsToken()
        {
            //Arrange
            TokenRepository repo = new TokenRepository();
            config.Setup(p => p["Jwt:Key"]).Returns("ThisIsMySecretKey");
            config.Setup(p => p["Jwr:Issuer"]).Returns("https://localhost:44392");
            mockSet.Setup(m => m.GenerateJSONWebToken(config.Object, loginDetails[0]));
            //Act
            var data = repo.GenerateJSONWebToken(config.Object, loginDetails[0]);
            //Assert
            Assert.IsNotNull(data);
            Assert.AreEqual("string".GetType(), data.GetType());
        }

        [Test]
        public void GenerateJSONWebToken_InvalidMember_ThrowsException()
        {
            //Arrange
            TokenRepository repo = new TokenRepository();
            config.Setup(p => p["Jwt:Key"]).Returns("ThisIsMySecretKey");
            config.Setup(p => p["Jwr:Issuer"]).Returns("https://localhost:44392");
            mockSet.Setup(m => m.GenerateJSONWebToken(config.Object, loginDetails[0]));

            var exceptionMessage=Assert.Throws<NullReferenceException>(()=> repo.GenerateJSONWebToken(config.Object, null));

            Assert.AreEqual("Object reference not set to an instance of an object.",exceptionMessage.Message);
            
            
        }
    }
}