using System;
using System.Collections;
using System.Collections.Generic;
using HelloVisualStudio.ConsoleApp.Display;
using HelloVisualStudio.Library;
using HelloVisualStudio.Library.Sorting;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // separation of concerns
            //     different "concerns" or "considerations" in code shouldn't be tangled together
            // single responsibility principle (S in SOLID)
            //     a unit of code (e.g. class, method) should have just one responsibility.
            // DRY principle
            //     don't repeat yourself
            // KISS
            //     keep it simple stupid (unless it's on codesignal)

            // have a list of products
            List<Product> catalog = GetProducts();

            // allow for some customization of that display to the user
            string input = null;
            while (input != "s" && input != "d")
            {
                Console.WriteLine("Enter s for simple, d for detailed: ");
                input = Console.ReadLine();
            }
            string input2 = null;
            while (input2 != "y" && input2 != "n")
            {
                Console.WriteLine("Sort? y/n: ");
                input2 = Console.ReadLine();
            }

            ISorter sorter;
            if (input2 == "y")
            {
                sorter = new PriceSorter();
            }
            else
            {
                sorter = new NonSorter();
            }

            IWriter writer;

            // display them to the user
            if (input == "s")
            {
                writer = new SimpleWriter(sorter);
            }
            else
            {
                writer = new DetailedWriter(sorter);
            }

            writer.FormatAndDisplay(catalog);

            // dependency inversion principle (D in SOLID)
            // - don't have classes depend on each other directly
            //   instead, have them depend on interfaces
        }

        static List<Product> CollectionDigression()
        {
            // built-in collections in C# / .NET

            // most basic: array.
            // low level, less "overhead"
            // fixed-size sequence of a particular data type.
            var numbers = new int[5]; // an array of 5 ints (initial value is the default, 0)
            numbers[3] = 1; // setting the fourth value in the array to 1
            // indexing in most languages, including C#, starts from 0.

            var objArray = new object[5];

            // difficulty with arrays is, the fixed size.

            // System.Collections.ArrayList is an old alternative to arrays in C#.
            var numbers2 = new ArrayList();

            numbers2.Add(1);
            numbers2.Add(2);
            numbers2.Add(3);
            numbers2.Remove(2);
            numbers2.Add("abc");
            numbers2.Add(true);
            numbers2.Add(new Product("", "", 1, 1));

            if (numbers2[0] is int)
            {
            }
            else
            {
                Product product = numbers2[0] as Product;
                if (product != null)
                {

                }
            }

            // what if i randomized the order right here?

            // c# supports overloading the [] operator (indexing operator)
            //      recent version of c# added reverse indexing into collections with ^, so ^2 is the second from the end.
            int x = (int)numbers2[0]; // get the first item from the arraylist
            x++;
            // who knows what that value's type really is?

            // we use () operator (casting) to inform the compiler we know more about that value's type than it does.
            // that was an example of "downcasting" - the arraylist could only guarantee the value was some descendant of "object"
            //     but we told the compiler it's more specific than that.
            //   this is "explicit" - meaning, i have to type the () cast manually since it's a potentially dangerous operation that could fail.

            // the opposite is upcasting - this is when you take a value of some specific type and store it in a variable of a less specific type.
            //    this is "implicit" - meaning, i don't have to use the () cast manually.

            object o = x;
            // upcasting a value type to "object" boxes the value in a reference type container.
            // downcasting from that object back to the value is called unboxing.

            double pi = 3.14;
            int three = (int)pi; // this is neither downcasting nor upcasting; int and double are both structs, neither inheriting from the other.
            // but it is a conversion that is "dangerous" (could lose data) so it's explicit.

            // a 8-byte size floating point (double) is big enough to store every integer that could fit in a four-byte int
            // this conversion can't lose data, so it's implicit.
            double d = 1000;

            var p = new Product("", "", 1, 1);
            ApplyDiscount(p);
            // if Product was value type, p HERE would not have the discount

            // we don't need to use types like ArrayList anymore, because C# supports generics.

            // enter List<T>

            // List supports flexible size AND specific data type.
            var list = new List<int> { 4, 3, 8, 1 }; // no upcasting
            var z = list[0]; // no downcasting, the compiler knows it must be an int.

            return null;
        }

        // any time you have a method that has only one statement, "return _____;",
        // you can use "expression-body syntax", which looks like this
        static List<Product> GetProducts() => new List<Product>
        {
            new Product("0001", "laptop", 1000.00, 5),
            new Product("0003", "pizza", 10.00, 50),
            new Product("0004", "coffee", 10.00, 20)
        };

        //static int GetThree() => 3;

        static void ApplyDiscount(Product p)
        {
            p.Price *= 0.85; // 15% off
        }
    }
}
