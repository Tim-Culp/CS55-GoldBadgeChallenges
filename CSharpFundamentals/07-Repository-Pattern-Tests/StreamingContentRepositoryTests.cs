using System;
using System.Collections.Generic;
using System.IO;
using _07_Repository_Pattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_Repository_Pattern_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repo = new StreamingContentRepository();

            //act
            bool addResult = repo.AddContentToDirectory(content);

            //assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void ReadDirectory_ShouldReturnCollection()
        {
            //arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repository = new StreamingContentRepository();
            repository.AddContentToDirectory(content);
            //act
            List<StreamingContent> returnedRepo = repository.ReadContentDirectory();

            //assert
            Assert.IsTrue(returnedRepo.Contains(content));
        }

        StreamingContent _content;
        StreamingContentRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _content = new StreamingContent("Avengers", "goode movie", MaturityRating.PG13, 4, Genre.Action);
            _repo = new StreamingContentRepository();
            _repo.AddContentToDirectory(_content);
        }

        [TestMethod]
        public void GetContentByTitle_ShouldReturnNonNullValue()
        {
            //arr
            Arrange();

            //act
            StreamingContent returnedContent = _repo.GetContentByTitle(_content.Title);

            //assert
            Assert.AreEqual(returnedContent, _content);
        }
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //arr
            StreamingContent newContent = new StreamingContent("Avengers", "An intellectual character study", MaturityRating.PG13, 4, Genre.Comedy);
            Arrange();

            //act
            bool updateResult = _repo.UpdateStreamingContent(_content.Title, newContent);
            
            //assert
            Assert.IsTrue(updateResult);
            Assert.AreEqual(Genre.Comedy, newContent.Genre);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //act
            bool deleted = _repo.DeleteStreamingContent(_content.Title);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void GetByMaturityRating_ShouldReturnListOfMovies()
        {
            //arrange
            StreamingContent movie2 = new StreamingContent();
            movie2.Title = "Saw";
            movie2.MaturityRating = MaturityRating.R;
            StreamingContent movie3 = new StreamingContent();
            movie3.Title = "girls gone wild";
            movie3.MaturityRating = MaturityRating.NC17;
            _repo.AddContentToDirectory(movie2);
            _repo.AddContentToDirectory(movie3);

            //act
            List<StreamingContent> pg13result = _repo.GetByMaturityRating(MaturityRating.PG13);
            List<StreamingContent> rResult = _repo.GetByMaturityRating(MaturityRating.R);
            List<StreamingContent> NC17Result = _repo.GetByMaturityRating(MaturityRating.NC17);
            
            //assert
            Assert.AreEqual(pg13result[0].Title, "Avengers");
            Assert.AreEqual(rResult[0].Title, "Saw");
            Assert.AreEqual(NC17Result[0].Title, "girls gone wild");

        }
    }
}
