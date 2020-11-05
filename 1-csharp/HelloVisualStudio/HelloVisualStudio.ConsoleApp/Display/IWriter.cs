using System;
using System.Collections.Generic;
using System.Text;
using HelloVisualStudio.Library;

namespace HelloVisualStudio.ConsoleApp.Display
{
    public interface IWriter
    {
        // interfaces can contain methods and properties (but not their implementations,
        //     just their "signatures")

        // they can't contain constructors or fields.

        void FormatAndDisplay(List<Product> catalog);
        // in an interface, all members use the same access modifier as the whole interface.
        // (it would never make sense to have it be different)
    }
}
