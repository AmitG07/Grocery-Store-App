using BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IProductBL
    {
        public int AddProduct(ProductObject product);
        public IEnumerable<ProductObject> GetAllProducts();
        public ProductObject GetProductById(int id);
        public bool EditProductById(ProductObject value);
        public bool DeleteProduct(int id);
        public IEnumerable<string> GetAllCategory();
        public bool UpdateQuantity(int id, int quantity);
        public bool OrderProduct(int id, IEnumerable<ProductOrderObject> proList);
        public IEnumerable<MyOrders> GetMyOrders(int id);
    }
}
