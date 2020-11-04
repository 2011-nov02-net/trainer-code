using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp
{
    // access modifiers in C#
    // the default is the most restrictive possible.
    // the default on a *type* (like class)
    //    is "internal"

    // public means - every code can access
    // internal means - only code in the same project/assembly can see it.
    // protected means - code in derived types is allowed, even in other projects
    // private means - code only in this class can access
    // there are two others
    public class Product
    {
        // product id
        public string Id { get; }


        // name
        public string Name { get; set; }

        // price
        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "price must be positive");
                }
                _price = value;
            }
        }

        // quantity in stock
        private int _quantity;
        public int Quantity {
            get { return _quantity; }
            private set
            {
                if (value < 0)
                {
                    // argumentexception is a good one for problems with the arguments to the current method
                    throw new ArgumentException("quantity can't be negative");
                }
                _quantity = value;
            }
        }

        // constructor
        // if you don't write one for your class, it will get a default one that looks like this:
        // public Product()
        // {
        // }

        // if it makes sense that your object requires certain data to even exist,
        // you should probably require that data to be provided in the constructor
        public Product(string id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void AddInventory(int count)
        {
            Quantity += count;
        }
    }
}
