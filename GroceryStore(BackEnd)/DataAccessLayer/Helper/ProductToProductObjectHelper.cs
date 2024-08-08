using BusinessObjectLayer;
using DataAccessLayer.ModelDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class ProductToProductObjectHelper
    {
        public ProductObject ProductToProductObjectMapping(Product product)
        {
            ProductObject p = new ProductObject();
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

        public IEnumerable<ProductObject> GetProductModels(IEnumerable<Product> products)
        {
            List<ProductObject> productModels = new List<ProductObject>();
            foreach(var item in products)
            {
                productModels.Add(ProductToProductObjectMapping(item));
            }
            return productModels;
        }
    }
}
