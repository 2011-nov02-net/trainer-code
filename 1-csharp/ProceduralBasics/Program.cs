using System;

namespace ProceduralBasics
{
    // in a console application project (which is the template that we made with "dotnet new")
    // the runtime looks for a static method named Main, and that's what it runs.

    // projects contain classes
    //    (a class is a blueprint for creating an object, which combines related functions/behavior and data)
    // classes contain members, e.g. methods
    //    (a method is a sequence of statements that run one after the other;
    //       it can have inputs (parameters), and one output (return value))

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // variables in C# with types
            // a variable is a slot that can contain a value
            // the type of value it can contain is set when the variable is created
            //    and can't be changed thereafter.

            // simple types in c#:

            // numeric types -
            //   for whole numbers
            //       int     (4 bytes (max ~2 billion))   (use this one almost all the time)
            //       short   (2 bytes)
            //       byte    (1 byte)
            //       long    (8 bytes)                    (use this for numbers that could be > 2 billion)

            //   for fractional (floating-point) numbers
            //       double  (8 bytes)        (use this one most of the time)
            //       float   (4 bytes)
            //       decimal (16 bytes)       (for storing financial stuff)

            //   for true/false
            //       bool

            //   for text    (in .NET, strings are Unicode)
            //       char      one character (like a, 3, 😎)
            //       string    any number of characters

            // declaring a variable named "x" of type "double",
            //    and giving it an initial value (initializing) of 1/3.
            double x = 1.0 / 3;
            // reassigning x based on its initial value minus 5.
            x = x - 5;

            // arithmetic + - * / %
            // comparison > < >= <= == !=
            // boolean && ||

            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            bool negative = (number < 0);

            // control flow (loops, conditionals, etc)
            if (negative)
            {
                Console.WriteLine("this prints if input was negative");
            }
            else if (number == 0)
            {
                Console.WriteLine("the number was 0");
            }
            else
            {
                Console.WriteLine("the number must have been positive then");
            }
            Console.WriteLine("this prints regardless");

            // for loops, while loops

            // initial setup ; test condition ; update statement
            // (start at 0, check if still <10, increment by 1)
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i % 3);
            }

            switch (number)
            {
                case 4:
                    x = 8;
                    break;
                case 7:
                    x = 1;
                    break;
            }
            // C# supports something fancy called "switch expression" uses
            // "pattern matching"


            // in C#, there's no "primitives" that aren't objects, everything's an object
            3.ToString();
            true.CompareTo(false);

            // (possible exception of null, null is the default value for reference type variables)

            // -------------------

            // print out triangle of size "number" (based on user input)
            //  #
            //  ##
            //  ###  (size 3)
            for (int i = 0; i < number; i++)
            {
                // each iteration of this loop prints one whole line.
                for (int j = 0; j < i + 1; j++)
                {
                    // each iteration of this loop just prints one character
                    Console.Write("#");
                }
                Console.WriteLine(); // just a line break
                // i could also just have printed this, without the inner loop:
                string line = new string('#', i + 1);
            }

            // "literal"
        }
    }
}
