using BusinessObjectLayer;
using DataAccessLayer.ModelDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class ProductObjectToProductHelper
    {
        public Product ProductObjectToProductMapping(ProductObject e)
        {
            Product p = new Product();
            p.ProductName = e.ProductName;
            p.Description = e.Description;
            p.Category = e.Category;
            p.AvailableQuantity = e.AvailableQuantity;
            p.Price = e.Price;
            p.Discount = e.Discount;
            p.Specification = e.Specification;
            return p;
        }
    }
}
