using BusinessObjectLayer;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helper
{
    public class ProductToProductObjectHelper
    {
        public ProductObject ProductToProductObjectMapping(Product product)
        {
            ProductObject p = new ProductObject();
            p.ProductName = product.ProductName;
            p.Description = product.Description;
            p.Category = product.Category;
            p.AvailableQuantity = product.AvailableQuantity;
            p.Price = product.Price;
            p.Discount = product.Discount;
            p.Specification = product.Specification;
            return p;
        }
    }
}
