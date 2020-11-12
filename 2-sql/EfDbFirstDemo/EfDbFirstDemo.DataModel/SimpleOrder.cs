using System;
using System.Collections.Generic;

#nullable disable

namespace EfDbFirstDemo.DataModel
{
    public partial class SimpleOrder
    {
        public SimpleOrder()
        {
            SimpleOrderDetails = new HashSet<SimpleOrderDetail>();
        }

        public int Orderid { get; set; }
        public int Custid { get; set; }
        public int Empid { get; set; }
        public DateTime Orderdate { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual ICollection<SimpleOrderDetail> SimpleOrderDetails { get; set; }
    }
}
