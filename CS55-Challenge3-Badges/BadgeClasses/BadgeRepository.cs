using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClasses
{
    public class BadgeRepository
    {
        private readonly List<Badge> _repo = new List<Badge>();

        public bool AddBadge(Badge badge)
        {
            int prevCount = _repo.Count;
            _repo.Add(badge);
            return _repo.Count > prevCount;
        }

        public List<Badge> GetBadges()
        {
            return _repo;
        }

        public bool UpdateBadge(int badgeID, List<string> doors)
        {
            foreach(Badge item in _repo)
            {
                if(item.BadgeID == badgeID)
                {
                    item.Doors = doors;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveBadgeByID(int id)
        {
            foreach(Badge item in _repo)
            {
                if (item.BadgeID == id)
                {
                    return _repo.Remove(item);
                }
            }
            return false;
        }
        public Badge GetBadgeByID(int id)
        {
            foreach(Badge item in _repo)
            {
                if (item.BadgeID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
