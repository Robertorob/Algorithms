using System;
using System.Collections.Generic;
using System.Text;

namespace SerializePerson
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person Brother { get; set; }
    }
}
