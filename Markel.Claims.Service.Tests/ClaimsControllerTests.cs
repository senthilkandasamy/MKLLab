using Markel.Claims.Service.Controllers;
using System;
using Xunit;
using Moq;
using Markel.Claims.Service.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Markel.Claims.Service.Tests
{
    public class ClaimsControllerTests
    {
        Mock<IGenericRepository<Markel.Claims.Service.Data.Claims>> claimsRepo;
        public ClaimsControllerTests() 
        {
            
        }

        [Fact]
        public async void AssertClaimsReturnedThen_RespondWithClaims()
        {
            //Arrange
            claimsRepo = new Mock<IGenericRepository<Markel.Claims.Service.Data.Claims>>();
            claimsRepo.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestClaims());

            //Act
            ClaimsController controller = new ClaimsController(claimsRepo.Object);

            var result = controller.Get();
            Assert.IsType<List<Markel.Claims.Service.Data.Claims>>(result.Result);
            List<Markel.Claims.Service.Data.Claims> claimsList = result.Result.ToList();
            Assert.True(claimsList.Count == 2);
        }

        private IReadOnlyList<Markel.Claims.Service.Data.Claims> GetTestClaims()
        {
            List<Markel.Claims.Service.Data.Claims> claimsList = new List<Markel.Claims.Service.Data.Claims>();

            Markel.Claims.Service.Data.Claims claims1 = new Markel.Claims.Service.Data.Claims();
            claims1.ClaimId = 1;
            claims1.AssuredName = "Test1";
            claimsList.Add(claims1);

            Markel.Claims.Service.Data.Claims claims2 = new Markel.Claims.Service.Data.Claims();
            claims1.ClaimId = 2;
            claims1.AssuredName = "Test2";
            claimsList.Add(claims2);

            return claimsList;
        }
    }
}
