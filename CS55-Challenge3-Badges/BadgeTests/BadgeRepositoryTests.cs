using System;
using System.Collections.Generic;
using BadgeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        public BadgeRepository _repo = new BadgeRepository();
        public Badge _badge1;
        [TestInitialize]
        [TestMethod]
        public void Initialize()
        {
            _repo = new BadgeRepository();
            List<string> badge1stuff = new List<string>() {"A1", "A2" };
            _badge1 = new Badge(12321, badge1stuff);
        }
        [TestMethod]
        public void AddBadge_ReturnTrue()
        {
            Initialize();
            bool success = _repo.AddBadge(_badge1);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetBadges_ReturnBadges()
        {
            Initialize();
            _repo.AddBadge(_badge1);
            Assert.IsTrue(_repo.GetBadges().Contains(_badge1));
        }
        [TestMethod]
        public void UpdateBadge_ReturnTrue()
        {
            Initialize();
            _repo.AddBadge(_badge1);
            List<string> newList = new List<string> { "Shrek" };
            _repo.UpdateBadge(_badge1.BadgeID, newList);
            Console.WriteLine($"{_repo.GetBadges()}");
            Assert.IsTrue(_repo.GetBadges()[0].Doors.Contains("Shrek"));
        }
        [TestMethod]
        public void RemoveBadge_ReturnTrue()
        {
            Initialize();
            _repo.AddBadge(_badge1);
            Assert.IsTrue(_repo.GetBadges().Contains(_badge1));
            _repo.RemoveBadgeByID(_badge1.BadgeID);
            Assert.IsTrue(!_repo.GetBadges().Contains(_badge1));
        }
        [TestMethod]
        public void GetBadgeByID_ReturnsBadge()
        {
            Initialize();
            _repo.AddBadge(_badge1);
            Badge newBadge = _repo.GetBadgeByID(_badge1.BadgeID);
            Assert.AreEqual(newBadge, _badge1);

        }
    }
}
