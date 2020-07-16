using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Inheritence_Classes.Aminals
{
    public class Sloth : Animal
    {
        public bool IsSlow
        {
            get
            {
                return true;
            }
        }

        public override void Move()
        {
            Console.WriteLine($"The {GetType().Name} doesn't move at all");
        }
    }
}
