using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloVisualStudio.Library;

namespace HelloVisualStudio.Library.Sorting
{
    public class NonSorter : ISorter
    {
        public IEnumerable<Product> SortProducts(IEnumerable<Product> catalog)
        {
            return catalog.ToList();
        }
    }
}
