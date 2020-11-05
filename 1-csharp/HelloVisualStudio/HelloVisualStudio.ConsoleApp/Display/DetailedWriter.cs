using System;
using System.Collections.Generic;
using System.Text;
using HelloVisualStudio.Library;
using HelloVisualStudio.Library.Sorting;

namespace HelloVisualStudio.ConsoleApp.Display
{
    public class DetailedWriter : IWriter
    {
        private readonly ISorter _sorter;

        public DetailedWriter(ISorter sorter)
        {
            _sorter = sorter;
        }

        public void FormatAndDisplay(List<Product> catalog)
        {
            foreach (var product in _sorter.SortProducts(catalog))
            {
                // string interpolation syntax $"{}"
                Console.WriteLine($"{product.Id}  {product.Name}  {product.Price:c}  ({product.Quantity})");
            }
        }
    }
}
