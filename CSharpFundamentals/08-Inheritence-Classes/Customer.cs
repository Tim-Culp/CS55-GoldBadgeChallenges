using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Inheritence_Classes
{
    public class Customer : Person
    {
        public bool IsPremium { get; set; }
        public bool IsSubScribedToEmails { get; set; }
    }
}
