using ClaimsMicroservice.Controllers;
using ClaimsMicroservice.Models;
using ClaimsMicroservice.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClaimServiceTesting
{
    public class Tests
    {
        List<Claim> dataObject = new List<Claim>();
        [SetUp]
        public void Setup()
        {
            dataObject = new List<Claim>()
            {
                new Claim()
                {
                    ClaimID = 1,
                    ClaimStatus = "Pending",
                    PolicyID = 1,
                    AmountClaimed = 45300,
                    BenefitsAvailed = "Medicine & Checkup",
                    HospitalID = 1,
                    Remarks = "Verified",
                    Settled = "False"
                },
                new Claim()
                {
                    ClaimID = 2,
                    ClaimStatus = "Rejected",
                    PolicyID = 1,
                    AmountClaimed = 54340,
                    BenefitsAvailed = "Medicine & Checkup",
                    HospitalID = 1,
                    Remarks = "Verified",
                    Settled = "False"
                }
            };
        }

        [Test]
        public void RepositoryGetStatusTest1()
        {
            string p = "";
            Mock<IClaimRepository> claimContextMock = new Mock<IClaimRepository>();
            var claimRepoObject = new ClaimRepository();
            claimContextMock.Setup(x => x.GetClaimStatus(1, 1)).Returns(p);
            var claimStatus = claimRepoObject.GetClaimStatus(1, 1);
            Assert.IsNotNull(claimStatus);
            Assert.AreEqual("Pending", claimStatus);
        }

        [Test]
        public void RepositoryGetStatusTest2()
        {
            string p = "";
            Mock<IClaimRepository> claimContextMock = new Mock<IClaimRepository>();
            var claimRepoObject = new ClaimRepository();
            claimContextMock.Setup(x => x.GetClaimStatus(2, 2)).Returns(p);
            var claimStatus = claimRepoObject.GetClaimStatus(2, 2);
            Assert.IsNotNull(claimStatus);
            Assert.AreEqual("Pending", claimStatus);
        }

        [Test]
        public void ControllerGetStatusTest1()
        {
            string p = "";
            IClaimRepository claimContextMock = new Mock<IClaimRepository>();
            var claimRepoObject = new ClaimsController(claimContextMock);
            claimContextMock.Setup(x => x.GetClaimStatus(1, 1)).Returns(p);
            var claimStatus = claimRepoObject.GetClaimStatus(1, 1);
            Assert.IsNotNull(claimStatus);
            Assert.AreEqual("Pending", claimStatus);
        }
    }
}