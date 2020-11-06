using MemberMicroservice.Models;
using MemberMicroservice.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MemberServiceTesting
{
    public class Tests
    {

        List<MemberPremium> dataObject = new List<MemberPremium>();
        [SetUp]
        public void Setup()
        {
            dataObject = new List<MemberPremium>()
            {
                new MemberPremium()
                {
                    MemberID = 1,
                    PolicyID = 1,
                    PremiumDue = 43242.0,
                    PaymentDetails = "UPI Mode",
                    DueDate = new DateTime(2020, 12, 20),
                    LastPremiumPaidDate = new DateTime(2019, 12, 21)
                },
                new MemberPremium()
                {
                    MemberID = 2,
                    PolicyID = 1,
                    PremiumDue = 54342.0,
                    PaymentDetails = "Cheque Mode",
                    DueDate = new DateTime(2021, 04, 16),
                    LastPremiumPaidDate = new DateTime(2020, 04, 22)
                }
            };
        }

        [Test]
        public void RepositoryGetStatusTest1()
        {
            MemberPremium memberPremium = new MemberPremium();
            Mock<IMemberRepository> memberContextMock = new Mock<IMemberRepository>();
            var memberRepoObject = new MemberRepository();
            memberContextMock.Setup(x => x.ViewBill(1, 2)).Returns(memberPremium);
            var memberStatus = memberRepoObject.ViewBill(1, 2);
            Assert.IsNotNull(memberStatus);
        }

        [Test]
        public void RepositoryGetStatusTest2()
        {
            MemberPremium memberPremium = new MemberPremium();
            Mock<IMemberRepository> memberContextMock = new Mock<IMemberRepository>();
            var memberRepoObject = new MemberRepository();
            memberContextMock.Setup(x => x.ViewBill(3, 5)).Returns(memberPremium);
            var memberStatus = memberRepoObject.ViewBill(3, 5);
            Assert.IsNotNull(memberStatus);
        }
    }
}