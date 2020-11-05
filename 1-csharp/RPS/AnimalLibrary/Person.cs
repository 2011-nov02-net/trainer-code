using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public class Person : Mammal
    {
        public string Name { get; set; }

        public string Occupation { get; set; }

        public override int LegCount => 2;
        public override bool CanSwim { get; }
        public override double Height { get; }

        // when overriding, you must use "override" keyword.
    }
}
