using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _07_Repository_Pattern_Repository;
using System.IO;

namespace _07_Repository_Pattern_Tests
{
    [TestClass]
    public class StreamingContentTests
    {

        [TestMethod]
        public void SetTitle_ShouldSetCorrectString()
        {
            StreamingContent content = new StreamingContent();
            content.Title = "Avengers";

            string expected = "Avengers";
            string actual = content.Title;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(Genre.Comedy)]
        [DataRow(Genre.Horror)]
        [DataRow(Genre.SciFi)]
        public void SetGenre_ShouldSetCorrectGenre(Genre expected)
        {
            //AAA paradigm

            //arrange
            StreamingContent content = new StreamingContent();
            //act (the function being tested)
            content.Genre = expected;
            //assert
            Assert.AreEqual(expected, content.Genre);

        }
    }
}
