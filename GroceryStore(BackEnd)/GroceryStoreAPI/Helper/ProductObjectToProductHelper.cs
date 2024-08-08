using BusinessObjectLayer;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helper
{
    public class ProductObjectToProductHelper
    {
        public Product ProductObjectToProductMapping(ProductObject product)
        {
            Product p = new Product();
            p.ProductId = product.ProductId;
            p.ProductName = product.ProductName;
            p.Description = product.Description;
            p.Category = product.Category;
            p.AvailableQuantity = product.AvailableQuantity;
            p.Price = product.Price;
            p.Discount = product.Discount;
            p.Specification = product.Specification;
            return p;
        }

        public IEnumerable<Product> GetProduct(IEnumerable<ProductObject> products)
        {
            List<Product> prod = new List<Product>();
            foreach(var items in products)
            {
                prod.Add(ProductObjectToProductMapping(items));
            }
            return prod;
        }
    }
}
