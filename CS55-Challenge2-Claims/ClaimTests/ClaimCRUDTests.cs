using System;
using System.Collections.Generic;
using ClaimClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimTests
{
    [TestClass]
    public class ClaimCRUDTests
    {
        ClaimRepository _repo;
        Claim _claim1;
        Claim _claim2;
        [TestInitialize]
        [TestMethod]
        public void Initialize()
        {
            _repo = new ClaimRepository();
            _claim1 = new Claim(1, ClaimTypes.Car, "Fender Bender", 200m, new DateTime(2018, 01, 31), new DateTime(2018, 02, 15));
            _claim2 = new Claim(2, ClaimTypes.Home, "Broken Window", 2000m, new DateTime(2019, 05, 29), new DateTime(2019, 07, 10));
            Assert.IsTrue(_claim1.IsValid);
        }
        [TestMethod]
        public void AddClaimToDatabase_ReturnTrue()
        {
            Initialize();
            bool success = _repo.AddClaimToDatabase(_claim1);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetClaims_ReturnListOfClaims()
        {
            Initialize();
            _repo.AddClaimToDatabase(_claim1);
            Assert.IsTrue(_repo.GetClaims().Contains(_claim1));
        }
        [TestMethod]
        public void GetClaimByID_ReturnClaim()
        {
            Initialize();
            _repo.AddClaimToDatabase(_claim1);
            Claim returned = _repo.GetClaimByID(1);
            Assert.AreEqual(returned.Description, "Fender Bender");
        }
        [TestMethod]
        public void DeleteClaim_ReturnTrue()
        {
            _repo.AddClaimToDatabase(_claim1);
            _repo.AddClaimToDatabase(_claim2);
            Assert.IsTrue(_repo.GetClaims().Contains(_claim1));
            _repo.DeleteClaim(_claim1);
            Assert.IsTrue(!_repo.GetClaims().Contains(_claim1));
        }
    }
}
