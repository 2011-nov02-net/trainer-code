using System;
using System.Collections.Generic;

#nullable disable

namespace EfDbFirstDemo.DataModel
{
    public partial class SimpleOrderDetail
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }

        public virtual SimpleOrder Order { get; set; }
        public virtual Track Product { get; set; }
    }
}
