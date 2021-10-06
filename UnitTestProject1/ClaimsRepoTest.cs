using Claims_Department_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class ClaimsRepoTest
    {
        [TestMethod]
        public void AddClaimsContent()
        {
            //Arrange
            ClaimsContent content = new ClaimsContent();
            ClaimsRepo repo = new ClaimsRepo();

            //Act
            bool sucess = repo.AddClaimContent(content);

            //Assert
            Assert.IsTrue(sucess);
        }

        [TestMethod]
        public void GetClaimsContents()
        {
            //Arrange

            /*
                        ClaimsContent claimsContent = new ClaimsContent(1, ClaimType.Car, "Turned into transformer, took out a bridge.", 1000.50m, new DateTime(2021, 09, 25), new DateTime(2021, 09, 28), true);*/
            ClaimsContent claimType = new ClaimsContent(4, ClaimsContent.ClaimType.Car, "Blew up engine while hopping railroad tracks.", 2500.00m, new DateTime(2021, 09, 01), new DateTime(2021, 10, 01), false);
            ClaimsRepo repo = new ClaimsRepo();

            repo.AddClaimContent(claimType);

            //Action

            Queue<ClaimsContent> claimsContent = repo.GetClaimsContents();

            bool success = claimsContent.Contains(claimType);

            //Assert

            Assert.IsTrue(success);



        }
    }
}
