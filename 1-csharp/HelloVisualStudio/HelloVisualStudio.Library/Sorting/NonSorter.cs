using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloVisualStudio.Library;

namespace HelloVisualStudio.Library.Sorting
{
    public class NonSorter : ISorter
    {
        public List<Product> SortProducts(List<Product> catalog)
        {
            return catalog.ToList();
        }
    }
}
