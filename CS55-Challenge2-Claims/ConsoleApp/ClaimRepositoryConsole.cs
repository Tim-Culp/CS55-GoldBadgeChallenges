using ClaimClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ClaimRepositoryConsole
    {
        private ClaimRepository _repo = new ClaimRepository();
        private bool _running = true;
        public ClaimRepositoryConsole()
        {

        }
        public ClaimRepositoryConsole(List<Claim> content)
        {
            foreach (Claim item in content)
            {
                _repo.AddClaimToDatabase(item);
            }
        }
        public void Run()
        {
            while (_running)
            {
                MainMenu();
            }
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Komodo Cafe Menu System. \n" +
                "Please select an option. \n" +
                "1. View all claims \n" +
                "2. Handle pending claims \n" +
                "3. Create claim \n" +
                "4. Exit");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    ViewAllClaims();
                    break;
                case "2":
                    HandleClaim();
                    break;
                case "3":
                    AddNewClaim();
                    break;
                case "4":
                    _running = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-4.");
                    PressAnyKey();
                    Console.ReadKey();

                    break;
            }
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            List<Claim> contents = _repo.GetClaims();
            foreach (Claim item in contents)
            {
                PrintClaim(item);
            }
            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void PrintClaim(Claim item)
        {
            Console.WriteLine($"-----\n" +
                    $"ID: {item.ClaimID}\n" +
                    $"Claim Type: {item.ClaimType}\n" +
                    $"Description: {item.Description}\n" +
                    $"Amount: {item.ClaimAmount}\n" +
                    $"DateOfIncident: {item.DateOfIncident}\n" +
                    $"DateOfClaim: {item.DateOfClaim}\n" +
                    $"IsValid?: {item.IsValid}");

        }

        private void AddNewClaim()
        {
            bool idPassed = false;
            int ID = 0;
            while (!idPassed)
            {
                Console.Clear();
                Console.WriteLine("Enter claim ID:");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out ID))
                {
                    idPassed = true;
                } else
                {
                    Console.WriteLine("Please enter a valid ID integer.");
                    PressAnyKey();
                }

            }

            bool typePassed = false;
            ClaimTypes type = ClaimTypes.Car;
            while (!typePassed)
            {
                Console.Clear();
                Console.WriteLine("-----\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");
                Console.WriteLine("Select claim type:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        type = ClaimTypes.Car;
                        typePassed = true;
                        break;
                    case "2":
                        type = ClaimTypes.Home;
                        typePassed = true;
                        break;
                    case "3":
                        type = ClaimTypes.Theft;
                        typePassed = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-3.");
                        PressAnyKey();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Please enter claim description:");
            string description = Console.ReadLine();

            bool amountPassed = false;
            decimal amount = 0m;
            while(!amountPassed)
            {
                Console.Clear();
                Console.WriteLine("Enter claim payment amount.");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out amount))
                {
                    amountPassed = true;
                } else
                {
                    Console.WriteLine("Please enter a valid decimal number.");
                    PressAnyKey();
                }
            }

            int year = 0;
            bool yearPassed = false ;
            while (!yearPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter incident's date.\n" +
                    "Enter Year (YYYY):");
                string input = Console.ReadLine();
                if (input.Length == 4 && Int32.TryParse(input, out year))
                {
                    yearPassed = true;
                } else
                {
                    Console.WriteLine("Please enter a valid year number.");
                    PressAnyKey();
                }
            }
            int month = 0;
            bool monthPassed = false;
            while (!monthPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter incident's date.\n" +
                    "Enter Month (MM):");
                string input = Console.ReadLine();
                if ((input.Length == 1 || input.Length == 2) && Int32.TryParse(input, out month) && month <= 12)
                {
                    monthPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid month number 1-12.");
                    PressAnyKey();
                }

            }

            int day = 0;
            bool dayPassed = false;
            while (!dayPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter incident's date.\n" +
                    "Enter Day (DD):");
                string input = Console.ReadLine();
                if ((input.Length == 1 || input.Length == 2) && Int32.TryParse(input, out day) && day <= 31)
                {
                    dayPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid day number 1-31.");
                    PressAnyKey();
                }
            }

            DateTime dateOfIncident = new DateTime(year, month, day);

            year = 0;
            day = 0;
            month = 0;

            yearPassed = false;
            monthPassed = false;
            dayPassed = false;

            while (!yearPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter claim's date.\n" +
                    "Enter Year (YYYY):");
                string input = Console.ReadLine();
                if (input.Length == 4 && Int32.TryParse(input, out year))
                {
                    yearPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid year number.");
                    PressAnyKey();
                }
            }
            while (!monthPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter claim's date.\n" +
                    "Enter Month (MM):");
                string input = Console.ReadLine();
                if ((input.Length == 1 || input.Length == 2) && Int32.TryParse(input, out month) && month <= 12)
                {
                    monthPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid month number 1-12.");
                    PressAnyKey();
                }

            }

            while (!dayPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter claim's date.\n" +
                    "Enter Day (DD):");
                string input = Console.ReadLine();
                if ((input.Length == 1 || input.Length == 2) && Int32.TryParse(input, out day) && day <= 31)
                {
                    dayPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid day number 1-31.");
                    PressAnyKey();
                }
            }

            DateTime dateOfClaim = new DateTime(year, month, day);

            Console.Clear();
            Claim newItem = new Claim(ID, type, description, amount, dateOfIncident, dateOfClaim);
            bool success = _repo.AddClaimToDatabase(newItem);
            if (success)
            {
                Console.WriteLine($"Item added successfully!");
                PrintClaim(_repo.GetClaimByID(newItem.ClaimID));
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

            PressAnyKey();

        }
        private void HandleClaim()
        {
            bool handling = true;
            while(handling)
            {
                Console.Clear();
                List<Claim> claims = _repo.GetClaims();
                if (claims.Count > 0)
                {
                    PrintClaim(claims[0]);
                    Console.WriteLine("Handle this claim? press y/n:");
                    ConsoleKeyInfo input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.Y:
                            _repo.DeleteClaim(claims[0]);
                            break;
                        case ConsoleKey.N:
                            handling = false;
                            break;
                        default:
                            Console.WriteLine("Please press either y or n.");
                            break;
                    }
                } else
                {
                    Console.WriteLine("No current claims to handle.");
                    handling = false;
                    PressAnyKey();
                }
                
            }
        }
    }
}
