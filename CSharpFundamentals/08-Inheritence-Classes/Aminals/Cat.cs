using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Inheritence_Classes.Aminals
{
    public class Cat : Animal
    {
        public double ClawLength { get; set; }
        public virtual void MakeSound()
        {
            Console.WriteLine("MEOW");
        }
        public override void Move()
        {
            Console.WriteLine($"The {GetType().Name} Sprintes");
        }
    }

    public class Liger : Cat
    {
        public override void MakeSound()
        {
            Console.WriteLine("Rawr :3");
        }
    }
}
