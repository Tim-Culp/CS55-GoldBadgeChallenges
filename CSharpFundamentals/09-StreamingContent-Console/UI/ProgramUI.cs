using _07_Repository_Pattern_Repository;
using _08_StreamingContent_Inheritence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _09_StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private IConsole _console;
        private readonly StreamingRepository _streamingRepository = new StreamingRepository();
        private bool _continuing = true;
        public void Run()
        {
            SeedContents();
            while (_continuing)
            {
                RunMenu();
            }

        }
        private void RunMenu()
        {
            _console.Clear();
            _console.WriteLine(
                "Enter the number of the option you would like to select \n" +
                "1. Show all streaming content \n" +
                "2. Search content by title \n" +
                "3. Add new streaming content \n" +
                "4. Remove streaming content by title \n" +
                "5. Remove streaming content from list \n" +
                "6. Exit"
                );
            string response = _console.ReadLine();
            switch (response)
            {
                case "1":
                    ShowAllContent();
                    break;
                case "2":
                    _console.Clear();
                    _console.WriteLine("Please enter content title.");
                    string query = _console.ReadLine();
                    SearchByTitle(query);
                    break;
                case "3":
                    CreateNewContent();
                    break;
                case "4":
                    _console.Clear();
                    _console.WriteLine("Please enter content title.");
                    string deleteQuery = _console.ReadLine();
                    DeleteByTitle(deleteQuery);
                    break;
                case "5":
                    DeleteFromList();
                    break;
                case "6":
                    _continuing = false;
                    break;
                default:
                    _console.WriteLine("Please enter a valid number 1-5.\n" +
                        "Press any key to continue...");
                    _console.ReadKey();
                    break;
            }
        }
        private void CreateNewContent()
        {
            _console.Clear();
            StreamingContent content = new StreamingContent();

            _console.WriteLine("Enter content title:");
            content.Title = _console.ReadLine();

            _console.WriteLine("Enter content description:");
            content.Description = _console.ReadLine();

            _console.WriteLine("Choose content maturity (enter a number 1-6): \n" +
                "1. G \n" +
                "2. PG \n" +
                "3. PG-13 \n" +
                "4. R \n" +
                "5. NC-17 \n" +
                "6. TV-MA");
            string maturityResponse = _console.ReadLine();
            switch (maturityResponse)
            {
                case "1":
                    content.MaturityRating = MaturityRating.G;
                    break;
                case "2":
                    content.MaturityRating = MaturityRating.PG;
                    break;
                case "3":
                    content.MaturityRating = MaturityRating.PG13;
                    break;
                case "4":
                    content.MaturityRating = MaturityRating.R;
                    break;
                case "5":
                    content.MaturityRating = MaturityRating.NC17;
                    break;
                case "6":
                    content.MaturityRating = MaturityRating.TVMA;
                    break;
                default:
                    _console.WriteLine("You have not entered a valid response.");
                    break;
            }

            _console.WriteLine("Enter content star rating (1-5): ");
            content.StarRating = Int32.Parse(_console.ReadLine());


            //Horror = 1,
            //Comedy,
            //SciFi,
            //Drama,
            //Action,
            //Romance,
            //Documentary,
            //Anime
            _console.WriteLine("Enter content genre (enter a number 1-8): \n" +
                "1. Horror \n" +
                "2. Comedy \n" +
                "3. Sci-Fi \n" +
                "4. Drama \n" +
                "5. Action \n" +
                "6. Romance \n" +
                "7. Documentary \n" +
                "8. Anime");
            //converts integer into corresponding genre in enum
            //casts int to Genre type
            content.Genre = (Genre)int.Parse(_console.ReadLine());

            _streamingRepository.AddContentToDirectory(content);
        }
        private void ShowAllContent()
        {
            _console.Clear();
            List<StreamingContent> stuff = _streamingRepository.ReadContentDirectory();
            if (stuff.Count > 0)
            {
                foreach (StreamingContent content in stuff)
                {
                    DisplayContent(content);
                }
            }
            else
            {
                _console.WriteLine("No content found. \n" +
                    "------------------");
            }

            PressAnyKey();
        }

        private void DisplayContent(StreamingContent content)
        {
            _console.WriteLine($"Title: {content.Title} \n" +
                    $"Description: {content.Description} \n" +
                    $"Maturity Rating: {content.MaturityRating} \n" +
                    $"Star Rating: {content.StarRating} \n" +
                    $"Genre: {content.Genre} \n" +
                    $"------------------");
        }

        public double Divide(int a, int b)
        {
            return (Convert.ToDouble(a) / Convert.ToDouble(b));
        }

        private void SeedContents()
        {
            StreamingContent content1 = new StreamingContent("Shrek", "An ogrerated movie.", MaturityRating.PG, 4, Genre.Comedy);
            StreamingContent content2 = new StreamingContent("Avengers", "Loki is unstoppable.", MaturityRating.PG13, 4, Genre.Action);
            StreamingContent content3 = new StreamingContent("Troll 2", "Bizarre 90's Kids Horror", MaturityRating.PG, 1, Genre.Horror);
            StreamingContent content4 = new StreamingContent("One Punch Man", "Overpowered superhero is bored with no rival.", MaturityRating.TVMA, 5, Genre.Anime);
            _streamingRepository.AddContentToDirectory(content1);
            _streamingRepository.AddContentToDirectory(content2);
            _streamingRepository.AddContentToDirectory(content3);
            _streamingRepository.AddContentToDirectory(content4);
        }

        private void PressAnyKey()
        {
            _console.WriteLine("Press any key to continue.");
            _console.ReadKey();
        }

        private void SearchByTitle(string title)
        {
            _console.Clear();
            StreamingContent returned = _streamingRepository.GetContentByTitle(title);
            if (returned is StreamingContent)
            {
                DisplayContent(returned);
            }
            else
            {
                _console.WriteLine("No content found. \n" +
                    "------------------");
            }

            PressAnyKey();
        }

        private void DeleteByTitle(string title)
        {
            _console.Clear();
            StreamingContent oldContent = _streamingRepository.GetContentByTitle(title);
            if (oldContent is StreamingContent)
            {
                bool deleteResult = _streamingRepository.DeleteStreamingContent(title);
                _console.WriteLine($"Delete status: {deleteResult} \n" +
                    $"Content for deletion: ");
                DisplayContent(oldContent);
            }
            else
            {
                _console.WriteLine("No content found. \n" +
                    "------------------");
            }

            PressAnyKey();
        }

        private void DeleteFromList()
        {
            _console.Clear();
            _console.WriteLine("Which item would you like to remove?");
            List<StreamingContent> stuff = _streamingRepository.ReadContentDirectory();
            int count = 0;
            foreach (StreamingContent content in stuff)
            {
                count++;
                _console.WriteLine($"{count}. {content.Title}");
            }

            int targetContentId = int.Parse(_console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < stuff.Count)
            {
                StreamingContent desiredContent = stuff[targetIndex];
                if (_streamingRepository.DeleteStreamingContent(desiredContent))
                {
                    _console.WriteLine($"{desiredContent.Title} removed successfully.");
                }
                else
                {
                    _console.WriteLine("Sorry nothing.");
                }
            }
            PressAnyKey();
        }
        public ProgramUI(IConsole console)
        {
            _console = console;
        }
    }
}
