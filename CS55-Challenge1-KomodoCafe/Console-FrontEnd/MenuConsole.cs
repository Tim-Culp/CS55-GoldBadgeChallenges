using MenuRepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_FrontEnd
{
    class MenuConsole
    {
        private MenuItemRepository _repo = new MenuItemRepository();
        private bool _running = true;
        public MenuConsole()
        {

        }
        public MenuConsole(List<MenuItem> content)
        {
            foreach (MenuItem item in content)
            {
                _repo.AddMenuItem(item);
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
                "1. View all Menu items \n" +
                "2. Search Menu item by name \n" +
                "3. Search Menu item by number \n" +
                "4. Add new Menu item \n" +
                "5. Remove Menu item\n" +
                "6. Exit");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    ViewAllMenuItems();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter name of item:");
                    string input = Console.ReadLine();
                    GetMenuItemByName(input);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter item number:");
                    string numinput = Console.ReadLine();
                    if (Int32.TryParse(numinput, out int inputint))
                    {
                        GetMenuItemByNumber(inputint);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                        PressAnyKey();
                    }

                    break;
                case "4":
                    AddNewMenuItem();
                    break;
                case "5":
                    DeleteMenuItemByName();
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
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> contents = _repo.GetMenuItems();
            foreach (MenuItem item in contents)
            {
                PrintMenuItem(item);
            }
            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void PrintMenuItem(MenuItem item)
        {
            Console.WriteLine($"-----\n" +
                    $"Name: {item.Name}\n" +
                    $"Number: {item.Number}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: ");
            foreach (string ingredient in item.Ingredients)
            {
                Console.WriteLine($"    {ingredient},");
            }
            Console.WriteLine($"Price: ${item.Price}");

        }
        private void GetMenuItemByName(string name)
        {
            MenuItem item = _repo.GetMenuItemByName(name);
            if (item != null)
            {
                PrintMenuItem(item);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
            
            PressAnyKey();
        }

        private void GetMenuItemByNumber(int number)
        {
            MenuItem item = _repo.GetMenuItemByNumber(number);
            if (item != null)
            {
                PrintMenuItem(item);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }

            PressAnyKey();
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter item name:");
            string name = Console.ReadLine();

            bool numberSuccess = false;
            int parsedNumber;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter item number:");
                string numberstr = Console.ReadLine();
                if (Int32.TryParse(numberstr, out parsedNumber))
                {
                    numberSuccess = true;
                }
                else
                {
                    Console.WriteLine("-----\n" +
                        "Please enter a valid number.");
                    PressAnyKey();
                }

            } while (!numberSuccess);

            Console.Clear();
            Console.WriteLine("Enter item description:");
            string description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter item ingredients (type 'q' when done):");

            bool ingredientDone = false;
            List<string> ingredients = new List<string>();
            do
            {

                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    ingredientDone = true;
                }
                else
                {
                    ingredients.Add(input);
                    Console.Clear();
                    Console.WriteLine("Enter item ingredients (type 'q' when done):");
                    Console.WriteLine("Ingredients:");
                    foreach (string item in ingredients)
                    {
                        Console.WriteLine($"    {item},");
                    }
                }
            } while (!ingredientDone);

            bool priceDone = false;
            decimal parsedPrice;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter item price:");
                string input = Console.ReadLine();
                if (Decimal.TryParse(input, out parsedPrice))
                {
                    priceDone = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid decimal number.");
                    PressAnyKey();
                }

            } while (!priceDone);

            Console.Clear();
            MenuItem newItem = new MenuItem(parsedNumber, name, description, ingredients, parsedPrice);
            bool success = _repo.AddMenuItem(newItem);
            if (success)
            {
                Console.WriteLine($"Item added successfully!");
                PrintMenuItem(_repo.GetMenuItemByName(newItem.Name));
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }

            PressAnyKey();

        }
        private void DeleteMenuItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter name of item to delete:");
            string name = Console.ReadLine();
            MenuItem item = _repo.GetMenuItemByName(name);
            bool success = _repo.RemoveMenuItem(item);
            if (success)
            {
                Console.WriteLine("Successfully removed item:");
                PrintMenuItem(item);
            }
            else
            {
                Console.WriteLine($"Could not remove {name}.");
            }

            PressAnyKey();

        }

    }
}
