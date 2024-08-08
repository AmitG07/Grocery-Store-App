using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ModelDAL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int AvailableQuantity { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
        public string Specification { get; set; }
    }
}
