using System.Collections;
using System.Collections.Generic;

namespace SimpleStore.DataModel.Model
{
    public class Location
    {
        public int Id { get; set; } // will become PK by convention

        public string Name { get; set; }

        public int Stock { get; set; }

        public ICollection<Order> Orders { get; set; }

        // in EF, an n-to-1 relationship between entities is represented with
        // up to 3 properties... the FK property, the navigation property, and the other
        // navigation property (collection)

        // at runtime, the context gets its configuration from three "places":
        // 1. conventions (assumed defaults)
        // 2. data annotations (attributes on the entity class properties)
        //       not as flexible
        // 3. fluent API (calls in DbContext OnModelCreating override)
        //       flexible
    }
}