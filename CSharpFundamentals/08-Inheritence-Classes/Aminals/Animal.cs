using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Inheritence_Classes.Aminals
{
    public enum DietType
    {
        Herbivore,
        Carnivore,
        Omnivore,
        Insectivore
    }
    public abstract class Animal
    {
        public int NumberOfLegs { get; set; }
        public bool IsMammal { get; set; }
        public bool HasFur { get; set; }
        public bool IsEndangered { get; set; }
        public DietType Diet { get; set; }
        public virtual void Move()
        {
            Console.WriteLine($"This {GetType().Name} Moves");
        }
    }
}
