using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Inheritence_Classes
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public string Name
        {
            get
            {
                string fullName = _firstName + " " + _lastName;
                return (!string.IsNullOrEmpty(fullName)) ? fullName : "undefined_name"; 
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void SetFirstName(string name)
        {
            _firstName = name;
        }

        public void SetLastName(string name)
        {
            _lastName = name;
        }
    }
}
