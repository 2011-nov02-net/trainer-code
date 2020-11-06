using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public class Cat : Mammal
    {
        public Cat(double height, bool canSwim) : base(height)
        {
            CanSwim = canSwim;
        }


        public Cat(double height) : this(height, true)
        {
        }

        // the first step of any constructor is to call
        // one of the parent class's constructors.
        // by default, it calls the zero-parameter one.
        // if there isn't a zero-parameter one, that's a compile error.
        // we use that syntax up there to choose a different one.

        public override int LegCount => 4;

        // c# supports "nullable" versions of all the value types (struct).
        // like "bool?"
        // this is a syntactic sugar for a special generic type: Nullable<bool>
        public override bool CanSwim { get; }
        public override double Height { get; set; }
    }
}
