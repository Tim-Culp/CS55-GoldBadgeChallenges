using MenuRepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_FrontEnd
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<MenuItem> items = new List<MenuItem>();
            List<string> item1ing = new List<string>() { "buns", "patty", "cheese" };
            MenuItem item1 = new MenuItem(1, "Burger", "Yummy in ya tummy.", item1ing, 3.25m);
            List<string> item2ing = new List<string>() { "potato", "salt", "asbestos" };
            MenuItem item2 = new MenuItem(2, "Fries", "Salty goode.", item2ing, 1.01m);
            items.Add(item1);
            items.Add(item2);
            MenuConsole console = new MenuConsole(items);
            console.Run();
        }
    }
}
