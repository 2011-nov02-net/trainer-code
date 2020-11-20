using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.DataModel.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Location Location { get; set; }
    }
}
