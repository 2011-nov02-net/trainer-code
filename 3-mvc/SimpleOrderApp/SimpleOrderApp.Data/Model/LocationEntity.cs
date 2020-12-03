using System.Collections.Generic;

namespace SimpleOrderApp.Data.Model
{
    public class LocationEntity
    {
        // automatically become the primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public List<OrderEntity> Orders { get; set; } // navigation property
    }
}
