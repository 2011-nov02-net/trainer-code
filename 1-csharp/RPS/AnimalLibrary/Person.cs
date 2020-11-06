using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public class Person : Mammal
    {
        public Person(string name, string occupation, double height)
        {
            Name = name;
            Occupation = occupation;
            Height = height;
        }

        public string Name { get; set; }

        public string Occupation { get; set; }

        public override int LegCount => 2;
        public override bool CanSwim => true;
        public override double Height { get; set; }

        // when overriding, you must use "override" keyword.
    }
}
