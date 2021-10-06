using CafeMenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class CafeMenuRepoTest
    {
        private CafeMenuRepo _repo;

        [TestMethod]
        public void CreateNewMenuContent()
        {
            //Arrange
            CafeContent content = new CafeContent();
            CafeMenuRepo repo = new CafeMenuRepo();

            //Act
            bool sucess = repo.CreateNewMenuContent(content);

            //Assert
            Assert.IsTrue(sucess);
        }

        [TestMethod]
        public void GetCafeContents_ShouldReturnContents()
        {
            //Arrange

            /*CafeContent cafeContent = new CafeContent(1, "Chicken Parmesan", "Perfectly baked crusted chicken, smothered in our home - made robust tomato sauce.Served on top of our home - made fettuccine noodles.", "-Ingredients:Chicken breast, parmesan cheese, tomatoes, salt, pepper, flour, baking powder", 16.99);*/
            CafeContent popSalad = new CafeContent(6, "Pop Salad", "Its pop salad.", "Ingredients:Pop and salad.", 10.00);
            CafeMenuRepo repo = new CafeMenuRepo();

            repo.CreateNewMenuContent(popSalad);

            //Action

            List<CafeContent> cafeContent = repo.GetCafeContents();

            bool success = cafeContent.Contains(popSalad);

            //Assert

            Assert.IsTrue(success);

        }

        [TestMethod]
        public void GetContentByMenu_Test()
        {
            //Arrange
            CafeContent popSalad = new CafeContent(6, "Pop Salad", "Its pop salad.", "Ingredients:Pop and salad.", 10.00);

            CafeMenuRepo repository = new CafeMenuRepo();
            _repo = new CafeMenuRepo();

            _repo.CreateNewMenuContent(popSalad);

            //Act
            CafeContent searchResult = _repo.GetContentByMenu("Pop Salad");

            //Assert
            Assert.AreEqual(popSalad.Price, searchResult.Price);


        }

        [TestMethod]
        public void DeleteCafeContent_Test()
        {
            //Must have something added to delete
            CafeContent chocolateCake = new CafeContent(7, "Chocolate Cake", "Its chocolate  cake.", "Ingredients:Chocolate, Cake.", 15.00);
            CafeMenuRepo repo = new CafeMenuRepo();
            _repo = new CafeMenuRepo();

            //Act

            bool removeResult = _repo.DeleteCafeContent("Chocolate Cake");

            //Assert
            Assert.IsTrue(removeResult);



        }
    }
}
