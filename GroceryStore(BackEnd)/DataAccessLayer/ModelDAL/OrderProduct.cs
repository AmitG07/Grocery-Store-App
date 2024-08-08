using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ModelDAL
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
    }
}
