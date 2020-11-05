using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    public class DelegateBasedAi : IAI
    {
        // C# has a way to pass around functions/methods as though they were just another form of data.
        // (this is an attitude from functional programming, which is quite different from object-oriented programming.)

        // delegates

        // this line defines a type
        public delegate string MoveChooser(string lastPlay);


        // a variable of type "int" can hold any int as its value.
        // a variable of type MoveChooser can hold any function that takes one stirng and returns one string.
        // a variable of a delegate type can contain any delegate that matches the type's signature.
        //    (a little bit like function pointers from a language like C)
        //    (what we're doing here is like callback functions in JS)

        private readonly MoveChooser _chooser;

        public DelegateBasedAi(MoveChooser chooser)
        {
            _chooser = chooser;
        }

        public string ChooseRPS(string lastPlay)
        {
            return _chooser(lastPlay);
        }

        // each instance of this class could do something totally different - depends on what delegate
        // was provided to the constructor.

        // this is one way to do polymorphism -
        static void DelegateStuff(Func<int, int> func)
        {
            func(1); // who knows what this returns, depends on what delegate was passed to this method.
            // we don't need to define delegate types like that if we don't want to;
            //   these days we can use some bulit-in generic ones.

            // Func
            // Action

            // this type represents "two int parameters, returning string."
            Func<int, int, string> add = (a, b) => (a + b).ToString();

            // this type represents "an int and a string parameter, with void return"
            Action<int, string> idk = (a, b) => { Console.WriteLine(a + b); };

            string three = add(1, 2); // "3"
            idk(12, "a"); // prints "12a"
        }
    }
}
