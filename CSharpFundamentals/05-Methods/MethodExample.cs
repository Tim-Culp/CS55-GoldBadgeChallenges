using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Methods
{
    [TestClass]
    public class MethodExample
    {
        
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        [TestMethod]
        public void MethodExecution()
        {
            //Console.WriteLine("hi");
            SayHello("Jimbob");
        }
    }
}
