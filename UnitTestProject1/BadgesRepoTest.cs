using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class BadgesRepoTest
    {
        private BadgeRepo _repo;
        private List<string> _badgeContent;

        [TestMethod]
        public void AddContent_Test()
        {
            //Arrange
            BadgeRepo content = new BadgeRepo();
            List<string> stuff = new List<string>();
            Dictionary<string, List<string>> testContent = content.GetContent();

            //Act
            content.AddContent("1");

            //Assert
            var expected = 1;
            var actual = testContent.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetContent_Test()
        {
            //Arrange
            BadgeRepo content = new BadgeRepo();
            Dictionary<string, List<string>> testContent = content.GetContent();

            //Act
            content.AddContent("1");

            //Assert
            var expected = 1;
            var actual = Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateExistingContent_Test()
        {
            //Arrange
            BadgeRepo content = new BadgeRepo();
            Dictionary<string, List<string>> testContent = content.GetContent();
            List<string> stuff = new List<string>();

            //Act
            content.AddContent("1");
            content.UpdateExistingContent("1", new List<string>() { "A5" });
            //Assert

        }
        [TestMethod]
        public void GetContentById_Test()
        {
            //Arrange
            BadgeRepo content = new BadgeRepo();
            Dictionary<string, List<string>> testContent = content.GetContent();
            List<string> stuff = new List<string>();

            //Act

            content.AddContent("1");
            content.GetContentById("1");

            //Assert
            var expected = 1;
            var actual = stuff.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
