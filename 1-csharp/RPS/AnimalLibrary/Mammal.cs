using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public abstract class Mammal : IAnimal
    {
        public Mammal(double height)
        {
            Height = height;
        }

        public Mammal()
        {
        }

        public abstract int LegCount { get; }
        public abstract bool CanSwim { get; }
        public virtual double Height { get; set; }

        public virtual bool LaysEggs => false;

        // in Java, LayEggs could be overridden in a child class.
        // Java allows child classes to override ANYTHING
        // C# disables overriding by default. chlid classes can only add on new stuff, not change what it inherited.
        // virtual members can be overridden in derived types.


        // these things are all mostly equivalent: child class, derived class, subclass

        // how can i share some code that several classes need
        // - direct inheritance between those classes
        //       with inheritance, you have to be careful to follow Liskov substitution principle -
        //              anywhere in your code that you accept a parameter of type X, it should also work correctly
        //              if you pass any derived type of X.
        // - introduce an abstract base class for all of those classes to inherit from.
        //       only on the table if they're not already inheriting from something else
        //       abstract class cannot itself be instantiated.
        // - composition/delegation
        //     instead of using inheritance to share code, put it on a class of its own, and those several classes
        //     that use that code can have an instance of that class. ("is-a" relationship vs "has-a" relationship)
        //         ways to improve this strategy... use interfaces, follow dependency inversion principle.

        // C# does not support multiple inheritance - one class can implement many interfaces,
        //    but one class can only inherit from one other class
    }
}
