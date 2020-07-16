using System;
using System.Collections.Generic;
using _09_StreamingContent_Console.UI;
using _10_StreamingContent_UIRefactorTests.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _10_StreamingContent_UIRefactorTests
{
    [TestClass]
    public class ProgramUITest
    {
        [TestMethod]
        public void GetList_ReturnListInOutput()
        {
            //arrange
            List<string> commandList = new List<string> {"1", "6" };
            MockConsole console = new MockConsole(commandList);
            ProgramUI program = new ProgramUI(console);

            //act
            program.Run();
            Console.WriteLine(console.Output);

            //assert
            Assert.IsTrue(console.Output.Contains("Shrek"));
        }
        [TestMethod]
        public void AddToList_ItemReturnedInOutput()
        {
            //arrange
            var customDesc = "customDescription";
            var commandList = new List<string> { "3", "Title", customDesc, "4", "1", "8", "1", "6" };
            var mockConsole = new MockConsole(commandList);
            var program = new ProgramUI(mockConsole);

            //act
            program.Run();
            Console.WriteLine(mockConsole.Output);

            //arrange
            Assert.IsTrue(mockConsole.Output.Contains(customDesc));
        }
        [TestMethod]
        public void RemoveFromList_StringNotFoundInOutput()
        {
            var customDesc = "customDescription";
            var commandList = new List<string> { "5", "1", "1", "6" };
            var mockConsole = new MockConsole(commandList);
            var program = new ProgramUI(mockConsole);

            //act
            program.Run();
            Console.WriteLine(mockConsole.Output);

            //arrange
            Assert.IsFalse(mockConsole.Output.Contains("ogrerated"));

        }
        [TestMethod]
        public void GetByTitle_ReturnContainsTitle()
        {
            var commandList = new List<string> { "2", "Shrek", "6" };
            var mockConsole = new MockConsole(commandList);
            var program = new ProgramUI(mockConsole);

            program.Run();
            Console.WriteLine(mockConsole.Output);

            Assert.IsTrue(mockConsole.Output.Contains("ogrerated"));
        }
    }
}
