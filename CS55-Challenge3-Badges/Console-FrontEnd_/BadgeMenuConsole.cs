using BadgeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_FrontEnd_
{
    class BadgeMenuConsole
    {
        private BadgeRepository _repo = new BadgeRepository();
        private bool _running = true;
        public BadgeMenuConsole()
        {

        }
        public BadgeMenuConsole(List<Badge> content)
        {
            foreach (Badge item in content)
            {
                _repo.AddBadge(item);
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
                "1. View all badges \n" +
                "2. Edit badge\n" +
                "3. Remove badge\n" +
                "4. Add badge\n" +
                "5. Exit\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    ViewAllBadges();
                    break;
                case "2":
                    Console.Clear();
                    EditBadge();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter item number:");
                    string numinput = Console.ReadLine();
                    if (Int32.TryParse(numinput, out int inputint))
                    {
                        GetBadgeByNumber(inputint);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                        PressAnyKey();
                    }

                    break;
                case "4":
                    AddNewBadge();
                    break;
                case "5":
                    DeleteBadgeByName();
                    break;
                case "6":
                    _running = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-6.");
                    PressAnyKey();
                    Console.ReadKey();

                    break;
            }
        }
        private void ViewAllBadges()
        {
            Console.Clear();
            List<Badge> contents = _repo.GetBadges();
            foreach (Badge item in contents)
            {
                PrintBadge(item);
            }
            PressAnyKey();
        }

        public void EditBadge()
        {
            int id = 0;
            bool idPassed = false;
            while (!idPassed)
            {
                Console.Clear();
                Console.WriteLine("Please enter badge ID.");
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out id))
                {
                    idPassed = true;
                } else
                {
                    Console.WriteLine("Please enter a valid ID integer.");
                    PressAnyKey();
                }

                Badge item = _repo.GetBadgeByID(id);
                PrintBadge(item);
                Console.WriteLine("Which?\n" +
                    "1. Add door" +
                    "2. Remove door");
                string Dinput = Console.ReadLine();
                switch (Dinput)
                {
                    case "1":
                            break;
                    case "2":
                            break;
                    default:
                        Console.WriteLine("You done goofed. Try again.");
                        PressAnyKey();
                        break;
                }
            }
        }

        private void PressAnyKey()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void PrintBadge(Badge item)
        {
            Console.WriteLine($"-----\n" +
                    $"ID: {item.BadgeID}\n");
            Console.WriteLine("Doors:");
            foreach (string door in item.Doors)
            {
                Console.WriteLine($"    {door},");
            }

        }
        //private void GetBadgeByID(int id)
        //{
        //    Badge item = _repo.GetBadges(name);
        //    if (item != null)
        //    {
        //        PrintBadge(item);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Item not found.");
        //    }

        //    PressAnyKey();
        //}

        //private void GetBadgeByNumber(int number)
        //{
        //    Badge item = _repo.GetBadgeByNumber(number);
        //    if (item != null)
        //    {
        //        PrintBadge(item);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Item not found.");
        //    }

        //    PressAnyKey();
        //}

        private void AddNewBadge()
        {
            int id = 0;
            bool idPassed = false;
            while (!idPassed)
            {
                Console.Clear();
                Console.WriteLine("Enter badge ID:");
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out id))
                {
                    idPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer ID.");
                    PressAnyKey();
                }

            }

            List<string> doors = new List<string>();
            bool doorsDone = false;
            while (!doorsDone)
            {
                Console.Clear();
                Console.WriteLine($"Doors:\n");
                foreach (string item in doors)
                {
                    Console.WriteLine($"    {item}");
                }
                Console.WriteLine("Add door name:");
                doors.Add(Console.ReadLine());
                Console.WriteLine("Add another door? (y/n):");
                ConsoleKeyInfo done = Console.ReadKey();
                switch (done.Key)
                {
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.N:
                        doorsDone = true;
                        break;
                    default:
                        Console.WriteLine("Please press either y or n");
                        PressAnyKey();
                        break;
                }
            }


            Console.Clear();
            Badge newItem = new Badge(id, doors);
            bool success = _repo.AddBadge(newItem);
            if (success)
            {
                Console.WriteLine($"Item added successfully!");
                PrintBadge(newItem);
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

            PressAnyKey();

        }
        private void DeleteBadgeById()
        {
            bool idPassed = false;
            int id = 0;
            string name = "";
            while (!idPassed)
            {
                Console.Clear();
                Console.WriteLine("Enter ID of item to delete:");
                name = Console.ReadLine();
                if (Int32.TryParse(name, out id))
                {
                    idPassed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer");
                    PressAnyKey();
                }
            }
            bool success = _repo.RemoveBadgeByID(id);
            if (success)
            {
                Console.WriteLine("Successfully removed item:");
            }
            else
            {
                Console.WriteLine($"Could not remove {name}.");
            }

            PressAnyKey();

        }
    }
}
