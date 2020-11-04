using System;
using System.Collections.Generic;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Product("a", "b", 1, 1).AddInventory(4);
        }
    }
}
