using BusinessObjectLayer;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helper
{
    public class ProductOrderToProductOrderObjectHelper
    {
        public ProductOrderObject ProductOrderToProductOrderObjectMapping(ProductOrder product)
        {
            ProductOrderObject p = new ProductOrderObject();
            p.ProductId = product.ProductId;
            p.OrderedQuantity = product.OrderedQuantity;
            return p;
        }

        public IEnumerable<ProductOrderObject> GetProductShared(IEnumerable<ProductOrder> products)
        {
            List<ProductOrderObject> productsModels = new List<ProductOrderObject>();
            foreach (var item in products)
            {
                productsModels.Add(ProductOrderToProductOrderObjectMapping(item));
            }
            return productsModels;

        }
    }
}
