using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuRepositoryClasses
{
    
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _database = new List<MenuItem>();

        public bool AddMenuItem(MenuItem item)
        {
            int prevCount = _database.Count;
            _database.Add(item);
            return (_database.Count > prevCount);

        }

        public List<MenuItem> GetMenuItems()
        {
            return _database;
        }

        public MenuItem GetMenuItemByName(string name)
        {
            foreach(MenuItem item in _database)
            {
                if(item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public MenuItem GetMenuItemByNumber(int number)
        {
            foreach(MenuItem item in _database)
            {
                if(item.Number == number)
                {
                    return item;
                }
            }
            return null;
        }

        public bool RemoveMenuItem(MenuItem item)
        {
            return _database.Remove(item);
        }
    }
}
