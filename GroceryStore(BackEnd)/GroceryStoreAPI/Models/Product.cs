 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int AvailableQuantity { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
        public string Specification { get; set; }
    }
}
