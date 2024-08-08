using BusinessLayer.Interfaces;
using BusinessObjectLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class ProductBL : IProductBL
    {
        private readonly IProductDAL _productDAL;

        public ProductBL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public int AddProduct(ProductObject product)
        {
            return _productDAL.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            var product = _productDAL.DeleteProduct(id);
            return product;
        }

        public bool EditProductById(ProductObject value)
        {
            var product = _productDAL.EditProductById(value);
            return product;
        }

        public IEnumerable<ProductObject> GetAllProducts()
        {
            var product = _productDAL.GetAllProducts();
            return product;
        }

        public ProductObject GetProductById(int id)
        {
            var product = _productDAL.GetProductById(id);
            return product;
        }

        public IEnumerable<string> GetAllCategory()
        {
            var result = _productDAL.GetAllCategory();
            return result;
        }

        public bool OrderProduct(int id, IEnumerable<ProductOrderObject> productList)
        {
            return _productDAL.OrderProduct(id, productList);
        }

        public bool UpdateQuantity(int id, int quantity)
        {
            if(_productDAL.UpdateQuantity(id, quantity))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<MyOrders> GetMyOrders(int id)
        {
            return _productDAL.GetMyOrders(id);
        }
    }
}
