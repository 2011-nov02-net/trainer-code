using System;
using System.Collections.Generic;
using System.Text;
using HelloVisualStudio.Library;

namespace HelloVisualStudio.Library.Sorting
{
    public interface ISorter
    {
        IEnumerable<Product> SortProducts(IEnumerable<Product> catalog);
    }
}
