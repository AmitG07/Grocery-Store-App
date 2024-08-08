using BusinessObjectLayer;
using DataAccessLayer.Helper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.ModelDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class ProductDAL : IProductDAL
    {
        private readonly ApplicationDbContext _context;

        public ProductDAL(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public int AddProduct(ProductObject product)
        {
            Product productDAL = new ProductObjectToProductHelper().ProductObjectToProductMapping(product);
            if(productDAL != null)
            {
                _context.Products.Add(productDAL);
                _context.SaveChanges();
                int id = productDAL.ProductId;
                return id;
            }
            else
            {
                return 0;
            }
        }

        public bool DeleteProduct(int id)
        {
            var query = from product in _context.Products where product.ProductId == id select product;
            if (query != null)
            {
                var product = query.ToList().FirstOrDefault();
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditProductById(ProductObject product)
        {
            Product productDAL = new ProductObjectToProductHelper().ProductObjectToProductMapping(product);
            productDAL.ProductId = product.ProductId;
            _context.Products.Update(productDAL);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ProductObject> GetAllProducts()
        {
            var p = _context.Products.ToList();
            var product = new ProductToProductObjectHelper().GetProductModels(p);
            return product;
        }

        public ProductObject GetProductById(int id)
        {
            ProductObject productGet = null;
            var query = from product in _context.Products where product.ProductId == id select product;

            if(query != null)
            {
                var product = new ProductToProductObjectHelper().ProductToProductObjectMapping(query.ToList().FirstOrDefault());
                productGet = product;
            }
            return productGet;
        }

        public IEnumerable<string> GetAllCategory()
        {
            var query = (from product in _context.Products select product.Category).Distinct().ToList();
            return query;
        }

        public bool OrderProduct(int id, IEnumerable<ProductOrderObject> productList)
        {
            try
            {
                Order o = new Order();
                o.CustomerId = id;
                _context.Orders.Add(o);
                _context.SaveChanges();
                var ordId = o.OrderId;

                foreach(var product in productList)
                {
                    OrderProduct op = new OrderProduct();
                    op.OrderId = ordId;
                    op.CustomerId = id;
                    op.ProductId = product.ProductId;
                    op.OrderDate = DateTime.Now;
                    op.OrderedQuantity = product.OrderedQuantity;
                    _context.OrderProducts.Add(op);
                    _context.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        public bool UpdateQuantity(int id, int quantity)
        {
            var query = from product in _context.Products where product.ProductId == id select product;

            if(query != null)
            {
                var product = query.ToList().FirstOrDefault();
                product.AvailableQuantity = product.AvailableQuantity - quantity;
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<MyOrders> GetMyOrders(int id)
        {
            var query = from op in _context.OrderProducts join p in _context.Products on op.CustomerId equals id where op.ProductId == p.ProductId select new { op.OrderId, p.ProductId, p.ProductName, op.OrderedQuantity, op.OrderDate };
            if (query != null)
            {
                var productList = query.ToList();
                List<MyOrders> myOrders = new List<MyOrders>();
                foreach (var product in productList)
                {
                    var myOrder = new MyOrders();
                    myOrder.OrderId = product.OrderId;
                    myOrder.ProductId = product.ProductId;
                    myOrder.ProductName = product.ProductName;
                    myOrder.OrderedQuantity = product.OrderedQuantity;
                    myOrder.OrderDate = product.OrderDate;
                    myOrders.Add(myOrder);
                }
                return myOrders;
            }
            return null;
        }
    }
}
