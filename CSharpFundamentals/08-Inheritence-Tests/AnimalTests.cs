using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _08_Inheritence_Classes.Aminals;

namespace _08_Inheritence_Tests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cat cat1 = new Cat();
            cat1.MakeSound();

            Liger cat2 = new Liger();
            cat2.MakeSound();

            //Animal animal = new Animal();
            //animal.HasFur = true;
        }
    }
}
