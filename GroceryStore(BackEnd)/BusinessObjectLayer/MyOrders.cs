using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer
{
    public class MyOrders
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
    }
}
