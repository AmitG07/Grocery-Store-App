using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
    }
}
