using System.Collections;
using System.Collections.Generic;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // separation of concerns
            //     different "concerns" or "considerations" in code shouldn't be tangled together
            // single responsibility principle
            //     a unit of code (e.g. class, method) should have just one responsibility.
            // DRY principle
            //     don't repeat yourself

            // have a list of products
            GetProducts();

            // display them to the user

            // allow for some customization of that display to the user
        }

        static List<Product> GetProducts()
        {
            // built-in collections in C# / .NET

            // most basic: array.
            // low level, less "overhead"
            // fixed-size sequence of a particular data type.
            var numbers = new int[5]; // an array of 5 ints (initial value is the default, 0)
            numbers[3] = 1; // setting the fourth value in the array to 1
            // indexing in most languages, including C#, starts from 0.

            // difficulty with arrays is, the fixed size.

            // System.Collections.ArrayList is an old alternative to arrays in C#.
            var numbers2 = new ArrayList();

            numbers2.Add(1);
            numbers2.Add(2);
            numbers2.Add(3);
            numbers2.Remove(2);

            // c# supports overloading the [] operator (indexing operator)
            int x = numbers2[0]; // get the first item from the arraylist

            Product p = new Product("", "", 1, 1);
            ApplyDiscount(p);
            // if Product was value type, p HERE would not have the discount

            return null;
        }

        static void ApplyDiscount(Product p)
        {
            p.Price *= 0.85; // 15% off
        }
    }
}
