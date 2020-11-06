using System;
using System.Collections.Generic;
using System.Text;
using HelloVisualStudio.Library;
using HelloVisualStudio.Library.Sorting;

namespace HelloVisualStudio.ConsoleApp.Display
{
    /// <summary>
    /// Responsible for formatting and printing a collection of Products.
    /// (General purpose of class)
    /// </summary>
    /// <remarks>
    /// More detailed info, like implementation decisions
    /// </remarks>
    public class SimpleWriter : IWriter
    {
        private readonly ISorter _sorter;

        public SimpleWriter(ISorter sorter)
        {
            _sorter = sorter;
        }

        public void FormatAndDisplay(IEnumerable<Product> catalog)
        {
            // in C#, if it implements IEnumerable<T>, then you can use foreach with it.
            foreach (var product in _sorter.SortProducts(catalog))
            {
                Console.WriteLine(product.Id);
            }
        }
    }
}
