using System;
using System.Collections.Generic;
using MenuRepositoryClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuRepositoryTests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        MenuItemRepository _repo;
        MenuItem _item1;
        [TestInitialize]
        public void Initialize()
        {
            _repo = new MenuItemRepository();
            List<string> item1Ingredients = new List<string> { "Buns", "Patty", "Lettuce", "Cheese" };
            _item1 = new MenuItem(1, "Burger", "Yummy delicious.", item1Ingredients, 4.99m);
        }
        [TestMethod]
        public void AddItemToRepository_ReturnTrue()
        {
            Initialize();
            bool worked = _repo.AddMenuItem(_item1);
            Assert.IsTrue(worked);
        }
        [TestMethod]
        public void ReadFromRepository_ReturnCorrectItem()
        {
            Initialize();
            _repo.AddMenuItem(_item1);
            Assert.AreEqual(_repo.GetMenuItemByName("Burger").Number, 1);
        }
        [TestMethod]
        public void DeleteFromRepository_ReturnTrue()
        {
            Initialize();
            _repo.AddMenuItem(_item1);
            bool worked = _repo.RemoveMenuItem(_item1);
            Assert.IsTrue(worked);
        }
    }
}
