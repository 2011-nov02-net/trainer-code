using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public abstract class Mammal : IAnimal
    {
        public abstract int LegCount { get; }
        public abstract bool CanSwim { get; }
        public abstract double Height { get; }

        public virtual bool LaysEggs => false;

        // in Java, LayEggs could be overridden in a child class.
        // Java allows child classes to override ANYTHING
        // C# disables overriding by default. chlid classes can only add on new stuff, not change what it inherited.
        // virtual members can be overridden in derived types.


        // these things are all mostly equivalent: child class, derived class, subclass
    }
}
